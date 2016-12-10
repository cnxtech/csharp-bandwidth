using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to SipPeer Api (IRIS)
  /// </summary>
  public interface ISipPeer
  {
    /// <summary>
    ///   Create a sip peer
    /// </summary>
    /// <param name="siteId">Site Id</param>
    /// <param name="data">data of new sip peer</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created sip peer</returns>
    Task<string> CreateAsync(string siteId, SipPeer data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get a  sip peer
    /// </summary>
    /// <param name="siteId">Site Id</param>
    /// <param name="id">SipPeer Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>SipPeer data</returns>
    Task<SipPeer> GetAsync(string siteId, string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List sip peers
    /// </summary>
    /// <param name="siteId">Site Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of sip peers data</returns>
    Task<SipPeer[]> ListAsync(string siteId, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Remove a sip peer
    /// </summary>
    /// <param name="siteId">Site Id</param>
    /// <param name="id">SipPeer Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    Task DeleteAsync(string siteId, string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get phone number data of sip peer
    /// </summary>
    /// <param name="siteId">Site Id</param> 
    /// <param name="id">SipPeer Id</param>
    /// <param name="number">Phone number</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Phone number data</returns>
    Task<SipPeerTelephoneNumber> GetTnAsync(string siteId, string id, string number,
      CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get phone numbers data for sip peer
    /// </summary>
    /// <param name="siteId">Site Id</param>
    /// <param name="id">SipPeer Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of phone number data</returns>
    Task<SipPeerTelephoneNumber[]> GetTnsAsync(string siteId, string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Update sip peer phone number data
    /// </summary>
    /// <param name="siteId">Site Id</param>
    /// <param name="id">SipPeer Id</param>
    /// <param name="number">Phone number</param>
    /// <param name="data">Changed phone number data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Async task</returns>
    Task UpdateTnAsync(string siteId, string id, string number, SipPeerTelephoneNumber data,
      CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Move phone numbers to the sip peer
    /// </summary>
    /// <param name="siteId">Site Id</param>
    /// <param name="id">SipPeer Id</param>
    /// <param name="numbers"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task MoveTnsAsync(string siteId, string id, string[] numbers, CancellationToken? cancellationToken = null);
  }

  /// <summary>
  ///   SipPeer
  /// </summary>
  public class SipPeer
  {
    /// <summary>
    ///   SiteId
    /// </summary>
    public string SiteId { get; set; }

    /// <summary>
    ///   Id
    /// </summary>
    public string Id => PeerId;

    /// <summary>
    ///   PeerId
    /// </summary>
    public string PeerId { get; set; }

    /// <summary>
    ///   Name
    /// </summary>
    [XmlElement("PeerName")]
    public string Name { get; set; }

    /// <summary>
    ///   Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///   IsDefaultPeer
    /// </summary>
    public bool IsDefaultPeer { get; set; }

    /// <summary>
    ///   ShortMessagingProtocol
    /// </summary>
    public string ShortMessagingProtocol { get; set; }

    /// <summary>
    ///   VoiceHosts
    /// </summary>
    [XmlArrayItem("Host")]
    public HostData[] VoiceHosts { get; set; }

    /// <summary>
    ///   SmsHosts
    /// </summary>
    [XmlArrayItem("Host")]
    public HostData[] SmsHosts { get; set; }

    /// <summary>
    ///   TerminationHosts
    /// </summary>
    public TerminationHost[] TerminationHosts { get; set; }

    /// <summary>
    ///   CallingName
    /// </summary>
    public CallingName CallingName { get; set; }

    /// <summary>
    ///   FinalDestinationUri
    /// </summary>
    public string FinalDestinationUri { get; set; }
  }

  /// <summary>
  ///   CallingName
  /// </summary>
  public class CallingName
  {
    /// <summary>
    ///   Display
    /// </summary>
    public bool Display { get; set; }

    /// <summary>
    ///   Enforced
    /// </summary>
    public bool Enforced { get; set; }
  }

  /// <summary>
  ///   TerminationHost
  /// </summary>
  public class TerminationHost
  {
    /// <summary>
    ///   HostName
    /// </summary>
    public string HostName { get; set; }

    /// <summary>
    ///   Port
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    ///   CustomerTrafficAllowed
    /// </summary>
    public string CustomerTrafficAllowed { get; set; }

    /// <summary>
    ///   DataAllowed
    /// </summary>
    public bool DataAllowed { get; set; }
  }

  /// <summary>
  ///   SipPeerTelephoneNumbers
  /// </summary>
  public class SipPeerTelephoneNumbers : IXmlSerializable
  {
    /// <summary>
    ///   Numbers
    /// </summary>
    public string[] Numbers { get; set; }

    XmlSchema IXmlSerializable.GetSchema()
    {
      return null;
    }

    void IXmlSerializable.ReadXml(XmlReader reader)
    {
      throw new NotImplementedException();
    }

    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
      foreach (var number in Numbers ?? new string[0])
      {
        writer.WriteElementString("FullNumber", number);
      }
    }
  }

  /// <summary>
  ///   SipPeerTelephoneNumber
  /// </summary>
  public class SipPeerTelephoneNumber
  {
    /// <summary>
    ///   FullNumber
    /// </summary>
    public string FullNumber { get; set; }

    /// <summary>
    ///   CallForward
    /// </summary>
    public string CallForward { get; set; }

    /// <summary>
    ///   NumberFormat
    /// </summary>
    public string NumberFormat { get; set; }

    /// <summary>
    ///   RewriteUser
    /// </summary>
    public string RewriteUser { get; set; }

    /// <summary>
    ///   RpidFormat
    /// </summary>
    [XmlElement("RPIDFormat")]
    public string RpidFormat { get; set; }
  }

  /// <summary>
  ///   SipPeerTelephoneNumberResponse
  /// </summary>
  public class SipPeerTelephoneNumberResponse
  {
    /// <summary>
    ///   SipPeerTelephoneNumber
    /// </summary>
    public SipPeerTelephoneNumber SipPeerTelephoneNumber { get; set; }
  }

  /// <summary>
  ///   SipPeerTelephoneNumbersResponse
  /// </summary>
  public class SipPeerTelephoneNumbersResponse
  {
    /// <summary>
    ///   SipPeerTelephoneNumbers
    /// </summary>
    public SipPeerTelephoneNumber[] SipPeerTelephoneNumbers { get; set; }
  }

  /// <summary>
  ///   SipPeerResponse
  /// </summary>
  public class SipPeerResponse
  {
    /// <summary>
    ///   SipPeer
    /// </summary>
    public SipPeer SipPeer { get; set; }
  }

  /// <summary>
  ///   SipPeersResponse
  /// </summary>
  [XmlType("TNSipPeersResponse")]
  public class SipPeersResponse
  {
    /// <summary>
    ///   SipPeers
    /// </summary>
    public SipPeer[] SipPeers { get; set; }
  }

  internal class SipPeerApi : ApiBase, ISipPeer
  {
    public Task<string> CreateAsync(string siteId, SipPeer data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/sites/{siteId}/sippeers", cancellationToken, data);
    }

    public Task<SipPeer> GetAsync(string siteId, string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<SipPeer>(HttpMethod.Get, $"/accounts/{Api.AccountId}/sites/{siteId}/sippeers/{id}",
        cancellationToken);
    }

    public async Task<SipPeer[]> ListAsync(string siteId, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<SipPeersResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}/sites/{siteId}/sippeers",
            cancellationToken)).SipPeers;
    }

    public Task DeleteAsync(string siteId, string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Delete,
        $"/accounts/{Api.AccountId}/sites/{siteId}/sippeers/{id}", cancellationToken);
    }

    public async Task<SipPeerTelephoneNumber> GetTnAsync(string siteId, string id, string number,
      CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<SipPeerTelephoneNumberResponse>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/sites/{siteId}/sippeers/{id}/tns/{Uri.EscapeUriString(number)}",
            cancellationToken)).SipPeerTelephoneNumber;
    }

    public async Task<SipPeerTelephoneNumber[]> GetTnsAsync(string siteId, string id,
      CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<SipPeerTelephoneNumbersResponse>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/sites/{siteId}/sippeers/{id}/tns",
            cancellationToken)).SipPeerTelephoneNumbers;
    }

    public Task UpdateTnAsync(string siteId, string id, string number, SipPeerTelephoneNumber data,
      CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Put,
        $"/accounts/{Api.AccountId}/sites/{siteId}/sippeers/{id}/tns/{Uri.EscapeUriString(number)}", cancellationToken, null, data);
    }

    public Task MoveTnsAsync(string siteId, string id, string[] numbers, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Post,
        $"/accounts/{Api.AccountId}/sites/{siteId}/sippeers/{id}/movetns", cancellationToken, null,
        new SipPeerTelephoneNumbers
        {
          Numbers = numbers
        });
    }
  }
}
