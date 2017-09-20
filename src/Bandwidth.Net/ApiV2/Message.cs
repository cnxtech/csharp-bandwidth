using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Bandwidth.Net.ApiV2
{
  /// <summary>
  ///   Access to Message Api
  /// </summary>
  public interface IMessage
  {

    Task<MessagingApplication> CreateMessagingApplicationAsync(IrisAuthData authData, CreateMessagingApplicationData data, CancellationToken? cancellationToken = null);
    Task<string[]> SearchAndOrderNumbersAsync(IrisAuthData authData, MessagingApplication application, SearchAndOrderNumbersQuery query, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Send a message.
    /// </summary>
    /// <param name="data">Parameters of new message</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Created message</returns>
    /// <example>
    ///   <code>
    /// var message = await client.V2.Message.SendAsync(new MessageData{ From = "from", To = new[] {"to"}, Text = "Hello"});
    /// </code>
    /// </example>
    Task<Message> SendAsync(MessageData data, CancellationToken? cancellationToken = null);

  }

  internal class MessageApi : ApiBase, IMessage
  {
    private HttpRequestMessage CreateIrisRequest(IrisAuthData authData, HttpMethod method, string path, object query = null)
    {
      var url = new UriBuilder($"https://dashboard.bandwidth.com/api/accounts/{authData.AccountId}")
      {
        Path = path,
        Query = Client.BuildQueryString(query)
      };
      var message = new HttpRequestMessage(method, url.Uri);
      message.Headers.UserAgent.Add(Client.UserAgent);
      message.Headers.Authorization = new AuthenticationHeaderValue("Basic",
        Convert.ToBase64String(Encoding.UTF8.GetBytes($"{authData.UserName}:{authData.Password}")));
      return message;
    }

    private async Task<XDocument> CheckResponse(HttpResponseMessage response)
    {
        try
        {
            var xml = await response.Content.ReadAsStringAsync();
            if (xml.Length > 0)
            {
                var doc = XDocument.Parse(xml);
                var code = doc.Descendants("ErrorCode").FirstOrDefault();
                var description = doc.Descendants("Description").FirstOrDefault();
                if (code == null)
                {
                    var error = doc.Descendants("Error").FirstOrDefault();
                    if (error == null)
                    {
                        var exceptions =
                            (from item in doc.Descendants("Errors")
                                select
                                    (Exception) new BandwidthIrisException(item.Element("Code").Value,
                                        item.Element("Description").Value, response.StatusCode)).ToArray();
                        if (exceptions.Length > 0)
                        {
                            throw new AggregateException(exceptions);
                        }
                        code = doc.Descendants("resultCode").FirstOrDefault();
                        description = doc.Descendants("resultMessage").FirstOrDefault();
                    }
                    else
                    {
                        code = error.Element("Code");
                        description = error.Element("Description");    
                    }
                }
                if (code != null && description != null && !string.IsNullOrEmpty(code.Value) && code.Value != "0")
                {
                    throw new BandwidthIrisException(code.Value, description.Value, response.StatusCode);
                }
                return doc;
            }
        }
        catch (Exception ex)
        {
            if (ex is BandwidthIrisException || ex is AggregateException) throw;
            Debug.WriteLine(ex.Message);
        }
        if (!response.IsSuccessStatusCode)
        {
            throw new BandwidthIrisException("", string.Format("Http code {0}", response.StatusCode), response.StatusCode);
        }
        return new XDocument();
    }

    internal async Task<(XDocument, HttpResponseMessage)> MakeRequestAsync(IrisAuthData authData, HttpMethod method, string path, XDocument doc, bool disposeResponse = false, CancellationToken? cancellationToken = null)
    {
        var request = CreateIrisRequest(authData, method, path);
        if (doc != null)
        {
          var xml = doc.ToString();
          request.Content = new StringContent(xml, Encoding.UTF8, "application/xml");
        }
        var response = await Client.Http.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);
        try
        {
          return  (await CheckResponse(response), response);
        }
        finally
        {
          if(disposeResponse)
          {
            response.Dispose();
          }
        }
    }

    internal async Task<string> CreateApplication(IrisAuthData authData, CreateMessagingApplicationData data, CancellationToken? cancellationToken = null)
    {
      var xml = new XDocument(
        new XElement("Application", 
          new XElement("AppName", data.Name),
          new XElement("CallbackUrl", data.CallbackUrl),
          new XElement("CallBackCreds", data.CallbackAuthData == null ? null : new[] {new XElement("UserId", data.CallbackAuthData.UserName), new XElement("Password", data.CallbackAuthData.Password)})
        )
      );
      var (doc, _) = await MakeRequestAsync(authData, HttpMethod.Post, "/applications", xml, true, cancellationToken);
      return doc.Descendants("ApplicationId").First().Value;
    }

    internal async Task<string> CreateLocation(IrisAuthData authData, CreateMessagingApplicationData data, CancellationToken? cancellationToken = null)
    {
      var xml = new XDocument(
        new XElement("SipPeer", 
          new XElement("PeerName", data.PeerName),
          new XElement("IsDefaultPeer", data.IsDefaultPeer)
        )
      );
      var (_, response) = await MakeRequestAsync(authData, HttpMethod.Post, $"/sites/{authData.SubaccountId}/sippeers", xml, false, cancellationToken);
      using (response) 
      {
        return (response.Headers.Location ?? new Uri("http://localhost")).AbsolutePath.Split('/').LastOrDefault();
      }
    }

    internal async Task EnableSms(IrisAuthData authData, SmsOptions options, MessagingApplication application, CancellationToken? cancellationToken = null)
    {
      if (options == null || !options.Enabled) {
        return;
      }
      var xml = new XDocument(
        new XElement("SipPeerSmsFeature",
          new XElement("SipPeerSmsFeatureSettings", 
            new XElement("TollFree", options.TollFreeEnabled),
            new XElement("ShortCode", options.ShortCodeEnabled),
            new XElement("Protocol", "HTTP"),
            new XElement("Zone1", true),
            new XElement("Zone2", false),
            new XElement("Zone3", false),
            new XElement("Zone4", false),
            new XElement("Zone5", false)
          ),
          new XElement("HttpSettings",
            new XElement("ProxyPeerId", "539692")
          )
        )
      );
      await MakeRequestAsync(authData, HttpMethod.Post, $"/sites/{authData.SubaccountId}/sippeers/{application.LocationId}/products/messaging/features/sms", xml, true, cancellationToken);
    }

    internal async Task EnableMms(IrisAuthData authData, MmsOptions options, MessagingApplication application, CancellationToken? cancellationToken = null)
    {
      if (options == null || !options.Enabled) {
        return;
      }
      var xml = new XDocument(
        new XElement("MmsFeature",
          new XElement("MmsSettings", 
            new XElement("protocol", "HTTP")
          ),
          new XElement("Protocols",
            new XElement("HTTP",
              new XElement("HttpSettings",
                new XElement("ProxyPeerId", "539692")
              )
            )
          )
        )
      );
      await MakeRequestAsync(authData, HttpMethod.Post, $"/sites/{authData.SubaccountId}/sippeers/{application.LocationId}/products/messaging/features/mms", xml, true, cancellationToken);
    }

    internal async Task AssignApplicationToLocation(IrisAuthData authData, MessagingApplication application, CancellationToken? cancellationToken = null)
    {
      var xml = new XDocument(
        new XElement("ApplicationsSettings",
          new XElement("HttpMessagingV2AppId", application.ApplicationId)
        )
      );
      await MakeRequestAsync(authData, HttpMethod.Put, $"/sites/{authData.SubaccountId}/sippeers/{application.LocationId}/products/messaging/applicationSettings", xml, true, cancellationToken);
    }
    
    public async Task<MessagingApplication> CreateMessagingApplicationAsync(IrisAuthData authData, CreateMessagingApplicationData data, CancellationToken? cancellationToken = null)
    {
        var app = new MessagingApplication {
          ApplicationId = await CreateApplication(authData, data, cancellationToken),
          LocationId = await CreateLocation(authData, data, cancellationToken)
        };
        await EnableSms(authData, data.SmsOptions, app, cancellationToken);
        await EnableMms(authData, data.MmsOptions, app, cancellationToken);
        await AssignApplicationToLocation(authData, app, cancellationToken);
        return app;
    }

    public async  Task<string[]> SearchAndOrderNumbersAsync(IrisAuthData authData, MessagingApplication application, SearchAndOrderNumbersQuery query, CancellationToken? cancellationToken = null)
    {
        var xml = new XDocument(
          new XElement("Order", query.ToXElement()),
          new XElement("SiteId", authData.SubaccountId),
          new XElement("PeerId", application.LocationId)
        );
        var (doc, _) = await MakeRequestAsync(authData, HttpMethod.Post, "/orders", xml, true, cancellationToken);
        var orderId = doc.Descendants("Order").First().Element("id").Value;
        //TODO add timeout support
        while(true) 
        {
          await Task.Delay(500, cancellationToken ?? default(CancellationToken));
          var (result, _) = await MakeRequestAsync(authData, HttpMethod.Get, $"/orders/{orderId}", null, true, cancellationToken);
          if(result.Descendants("OrderStatus").First().Value == "COMPLETE")
          {
            return result.Descendants("FullNumber").Select(n => n.Value).ToArray();
          }
        }
    }

    public Task<Message> SendAsync(MessageData data,
      CancellationToken? cancellationToken = null)
    {
      return Client.MakeJsonRequestAsync<Message>(HttpMethod.Post, $"/users/{Client.UserId}/messages", cancellationToken, null, data, "v2");
    }
  }

  /// <summary>
  ///   Parameters to send an message
  /// </summary>
  public class MessageData
  {
    /// <summary>
    /// The message sender's telephone number (or short code).
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Message recipient telephone number (or short code).
    /// </summary>
    public string[] To { get; set; }

    /// <summary>
    /// The message contents.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Array containing list of media urls to be sent as content for an mms.
    /// </summary>
    public string[] Media { get; set; }

    /// <summary>
    /// The complete URL where the events related to the outgoing message will be sent.
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// Messaging application id
    /// </summary>
    public string ApplicationId { get; set; }
  }

  /// <summary>
  /// Rsult of batch send of some messages
  /// </summary>
  public class Message
  {
    /// <summary>
    /// Id of the message
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The message sender's telephone number (or short code).
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Message recipient telephone number (or short code).
    /// </summary>
    public string[] To { get; set; }

    /// <summary>
    /// The message contents.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Array containing list of media urls to be sent as content for an mms.
    /// </summary>
    public string[] Media { get; set; }

    /// <summary>
    /// The complete URL where the events related to the outgoing message will be sent.
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// The message owner
    /// </summary>
    public string Owner { get; set; }

    /// <summary>
    /// Direction of the message
    /// </summary>
    public MessageDirection Direction { get; set; }

    /// <summary>
    /// The message creation time
    /// </summary>
    public DateTime Time { get; set; }
  }

  /// <summary>
  /// Directions of message
  /// </summary>
  public enum MessageDirection
  {
    /// <summary>
    /// A message that came from the telephone network to one of your numbers (an "inbound" message)
    /// </summary>
    In,

    /// <summary>
    /// A message that was sent from one of your numbers to the telephone network (an "outbound" message)
    /// </summary>
    Out
  }

  public class MessagingApplication 
  {
    public string ApplicationId {get; set;}
    public string LocationId {get; set;}
  }

  public class CreateMessagingApplicationData
  {
    public string Name {get; set;}

    public string CallbackUrl {get; set;}

    public CallbackAuthData CallbackAuthData {get; set;}

    public string PeerName {get; set;}

    public bool IsDefaultPeer {get; set;}

    public SmsOptions SmsOptions {get; set;}

    public MmsOptions MmsOptions {get; set;}
  }

  public class IrisAuthData
  {
    public string AccountId {get; set;}

    public string SubaccountId {get; set;}

    public string UserName {get; set;}

    public string Password {get; set;}
  }

  public class CallbackAuthData
  {
    public string UserName {get; set;}
    public string Password {get; set;}
  }

  public class SmsOptions
  {
    public bool Enabled {get; set;} = true;
    public bool TollFreeEnabled {get; set;}

    public bool ShortCodeEnabled {get; set;}
  }
  public class MmsOptions
  {
    public bool Enabled {get; set;} = true;
  }

  public abstract class SearchAndOrderNumbersQuery
  {
    public int Quantity {get; set;} = 10;
    public abstract XElement ToXElement();
  }

  public class AreaCodeSearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string AreaCode {get; set;}

    public override XElement ToXElement()
    {
      return new XElement("AreaCodeSearchAndOrderType", 
        new XElement("AreaCode", this.AreaCode),
        new XElement("Quantity", this.Quantity)
      );
    }
  }

  public class RateCenterSearchAndOrdeNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string RateCenter {get; set;}
    public string State {get; set;}
  }

  public class NpaNxxSearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string NpaNxx {get; set;}
    public bool EnableTnDetail {get; set;}
    public bool EnableLca {get; set;}
  }

  public class TollFreeVanitySearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string TollFreeVanity {get; set;}
  }

  public class TollFreeWildCharSearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string TollFreeWildCardPattern {get; set;}
  }

  public class StateSearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string State {get; set;}
  }

  public class CitySearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string State {get; set;}
    public string City {get; set;}
  }

  public class ZipSearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string Zip {get; set;}
  }

  public class LataSearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string Lata {get; set;}
  }

  public class CombinedSearchAndOrderNumbersQuery: SearchAndOrderNumbersQuery
  {
    public string AreaCode {get; set;}
    public string RateCenter {get; set;}
    public string NpaNxx {get; set;}
    public bool EnableTnDetail {get; set;}
    public bool EnableLca {get; set;}
    public string TollFreeVanity {get; set;}
    public string TollFreeWildCardPattern {get; set;}
    public string State {get; set;}
    public string City {get; set;}
    public string Zip {get; set;}
    public string Lata {get; set;}
  }
}
