using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to AvailableNumber Api (IRIS)
  /// </summary>
  public interface IAvailableNumber
  {
    /// <summary>
    /// Returns available numbers to order
    /// </summary>
    /// <param name="query">Optional query</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of data with numbers</returns>
    Task<AvailableNumbersResult> ListAsync(AvailableNumberQuery query = null,
      CancellationToken? cancellationToken = null);
  }

  internal class AvailableNumberApi : ApiBase, IAvailableNumber
  {
    public async Task<AvailableNumbersResult> ListAsync(AvailableNumberQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return await Api.MakeXmlRequestAsync<AvailableNumbersResult>(HttpMethod.Get,
        $"/accounts/{Api.AccountId}/availableNumbers", cancellationToken, query);
    }
  }

  /// <summary>
  /// Query parameters to list available numbers
  /// </summary>
  public class AvailableNumberQuery
  {
    /// <summary>
    /// AreaCode
    /// </summary>
    public string AreaCode { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// EnableTNDetail
    /// </summary>
    public bool? EnableTNDetail { get; set; }
  }


  /// <summary>
  /// SearchResult
  /// </summary>
  [XmlType("SearchResult")]
  public class AvailableNumbersResult
  {
    /// <summary>
    /// ResultCount
    /// </summary>
    public int ResultCount { get; set; }

    /// <summary>
    /// TelephoneNumber
    /// </summary>
    [XmlArrayItem("TelephoneNumber")]
    public string[] TelephoneNumberList { get; set; }

    /// <summary>
    /// TelephoneNumberDetailList
    /// </summary>
    public TelephoneNumberDetail[] TelephoneNumberDetailList { get; set; }
  }

  /// <summary>
  /// TelephoneNumberDetail
  /// </summary>
  public class TelephoneNumberDetail
  {
    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Lata
    /// </summary>
    [XmlElement("LATA")]
    public string Lata { get; set; }

    /// <summary>
    /// RateCenter
    /// </summary>
    public string RateCenter { get; set; }

    /// <summary>
    /// State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// TelephoneNumber
    /// </summary>
    public string TelephoneNumber { get; set; }

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
  }
}
