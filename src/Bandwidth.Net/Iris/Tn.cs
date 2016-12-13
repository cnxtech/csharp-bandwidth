using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Tn Api (IRIS)
  /// </summary>
  public interface ITn
  {
    /// <summary>
    ///   Get a  tn data
    /// </summary>
    /// <param name="number">phone number</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Tn data</returns>
    /// <example>
    /// <code>
    /// var tn = await client.Tn.GetAsync("id");
    /// </code>
    /// </example>
    Task<Tn> GetAsync(string number, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List tns
    /// </summary>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of tns data</returns>
    /// <example>
    /// <code>
    /// var response = await client.Tn.ListAsync();
    /// </code>
    /// </example>
    Task<TelephoneNumbersResponse> ListAsync(CancellationToken? cancellationToken = null);

    /// <summary>
    /// Return sites of phone number
    /// </summary>
    /// <param name="number">phone number</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Sites data</returns>
    /// <example>
    /// <code>
    /// var response = await client.Tn.GetSitesAsync("1324567890");
    /// </code>
    /// </example>
    Task<TelephoneNumberSite> GetSitesAsync(string number, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Return sip peers of phone number
    /// </summary>
    /// <param name="number">phone number</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Peers data</returns>
    /// <example>
    /// <code>
    /// var response = await client.Tn.GetSipPeersAsync("1324567890");
    /// </code>
    /// </example>
    Task<TelephoneNumberSipPeer> GetSipPeersAsync(string number, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Return rate center data of phone number
    /// </summary>
    /// <param name="number">phone number</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Rate center data</returns>
    /// <example>
    /// <code>
    /// var response = await client.Tn.GetRateCenter("1324567890");
    /// </code>
    /// </example>
    Task<TelephoneNumberRateCenter> GetRateCenter(string number, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Return phone number details
    /// </summary>
    /// <param name="number">phone number</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Details data</returns>
    /// <example>
    /// <code>
    /// var response = await client.Tn.GetDetailsAsync("1324567890");
    /// </code>
    /// </example>
    Task<TelephoneNumberDetails> GetDetailsAsync(string number, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Return LATA of phone number
    /// </summary>
    /// <param name="number">phone number</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>LATA data</returns>
    /// <example>
    /// <code>
    /// var lata = await client.Tn.GetLataAsync("1234567890");
    /// </code>
    /// </example>
    Task<string> GetLataAsync(string number, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  ///   Tn
  /// </summary>
  public class Tn
  {
    /// <summary>
    /// TelephoneNumber
    /// </summary>
    public string TelephoneNumber { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// LastModifiedDate
    /// </summary>
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// OrderCreateDate
    /// </summary>
    public DateTime OrderCreateDate { get; set; }

    /// <summary>
    /// OrderId
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// OrderType
    /// </summary>
    public string OrderType { get; set; }

    /// <summary>
    /// SiteId
    /// </summary>
    public string SiteId { get; set; }

    /// <summary>
    /// AccountId
    /// </summary>
    public string AccountId { get; set; }
  }

  /// <summary>
  /// TelephoneNumberSipPeer
  /// </summary>
  [XmlType("SipPeer")]
  public class TelephoneNumberSipPeer
  {
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
  }

  /// <summary>
  /// TelephoneNumberSite
  /// </summary>
  [XmlType("Site")]
  public class TelephoneNumberSite
  {
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
  }

  /// <summary>
  /// TelephoneNumberRateCenter
  /// </summary>
  public class TelephoneNumberRateCenter
  {
    /// <summary>
    /// State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// RateCenter
    /// </summary>
    public string RateCenter { get; set; }
  }

  /// <summary>
  /// TelephoneNumberResponse
  /// </summary>
  public class TelephoneNumberResponse
  {
    /// <summary>
    /// TelephoneNumberDetails
    /// </summary>
    public TelephoneNumberDetails TelephoneNumberDetails { get; set; }
  }

  /// <summary>
  /// TelephoneNumberDetails
  /// </summary>
  public class TelephoneNumberDetails
  {
    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Lata
    /// </summary>
    public string Lata { get; set; }

    /// <summary>
    /// RateCenter
    /// </summary>
    public string RateCenter { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// AccountId
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    /// FullNumber
    /// </summary>
    public string FullNumber { get; set; }

    /// <summary>
    /// Tier
    /// </summary>
    public string Tier { get; set; }

    /// <summary>
    /// VendorId
    /// </summary>
    public string VendorId { get; set; }

    /// <summary>
    /// VendorName
    /// </summary>
    public string VendorName { get; set; }

    /// <summary>
    /// LastModified
    /// </summary>
    public DateTime LastModified { get; set; }


    /// <summary>
    /// State
    /// </summary>
    public string State { get; set; }
  }

  /// <summary>
  /// TelephoneNumbersResponse
  /// </summary>
  public class TelephoneNumbersResponse
  {
    /// <summary>
    /// TelephoneNumbers
    /// </summary>
    public TelephoneNumber[] TelephoneNumbers { get; set; }

    /// <summary>
    /// TelephoneNumberCount
    /// </summary>
    public int TelephoneNumberCount { get; set; }

    /// <summary>
    /// Links
    /// </summary>
    public Links Links { get; set; }
  }


  internal class TnApi : ApiBase, ITn
  {
    public Task<Tn> GetAsync(string number, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<Tn>(HttpMethod.Get, $"/accounts/{Api.AccountId}/tns/{Uri.EscapeDataString(number)}",
        cancellationToken);
    }

    public Task<TelephoneNumberDetails> GetDetailsAsync(string number, CancellationToken? cancellationToken = default(CancellationToken?))
    {
      return Api.MakeXmlRequestAsync<TelephoneNumberDetails>(HttpMethod.Get, $"/accounts/{Api.AccountId}/tns/{Uri.EscapeDataString(number)}/tndetails",
        cancellationToken);
    }

    public async Task<string> GetLataAsync(string number, CancellationToken? cancellationToken = default(CancellationToken?))
    {
      using (var response = await Api.MakeXmlRequestAsync(HttpMethod.Get, $"/accounts/{Api.AccountId}/tns/{Uri.EscapeDataString(number)}/lata", cancellationToken))
      {
        var xml = XDocument.Parse(await response.Content.ReadAsStringAsync());
        return xml.Descendants("Lata").First().Value;
      }
    }

    public async Task<TelephoneNumberRateCenter> GetRateCenter(string number, CancellationToken? cancellationToken = default(CancellationToken?))
    {
      using (var response = await Api.MakeXmlRequestAsync(HttpMethod.Get, $"/accounts/{Api.AccountId}/tns/{Uri.EscapeDataString(number)}/ratecenter", cancellationToken))
      {
        var text = await response.Content.ReadAsStringAsync();
        var xml = XDocument.Parse(text);
        return new TelephoneNumberRateCenter
        {
          RateCenter = xml.Descendants("RateCenter").First().Value,
          State = xml.Descendants("State").First().Value
        };
      }
    }

    public Task<TelephoneNumberSipPeer> GetSipPeersAsync(string number, CancellationToken? cancellationToken = default(CancellationToken?))
    {
      return Api.MakeXmlRequestAsync<TelephoneNumberSipPeer>(HttpMethod.Get, $"/accounts/{Api.AccountId}/tns/{Uri.EscapeDataString(number)}/sippeers",
        cancellationToken);
    }

    public Task<TelephoneNumberSite> GetSitesAsync(string number, CancellationToken? cancellationToken = default(CancellationToken?))
    {
      return Api.MakeXmlRequestAsync<TelephoneNumberSite>(HttpMethod.Get, $"/accounts/{Api.AccountId}/tns/{Uri.EscapeDataString(number)}/sites",
        cancellationToken);
    }

    public Task<TelephoneNumbersResponse> ListAsync(CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<TelephoneNumbersResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}/tns",
        cancellationToken);
    }
  }
}
