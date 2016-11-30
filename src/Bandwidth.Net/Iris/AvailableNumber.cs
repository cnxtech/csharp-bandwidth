using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  public interface IAvailableNumber
  {
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

  public class AvailableNumberQuery
  {
    public string AreaCode { get; set; }
    public int? Quantity { get; set; }
    public bool? EnableTNDetail { get; set; }
  }

  [XmlType("SearchResult")]
  public class AvailableNumbersResult
  {
    public int ResultCount { get; set; }

    [XmlArrayItem("TelephoneNumber")]
    public string[] TelephoneNumberList { get; set; }

    public TelephoneNumberDetail[] TelephoneNumberDetailList { get; set; }
  }

  public class TelephoneNumberDetail
  {
    public string City { get; set; }

    [XmlElement("LATA")]
    public string Lata { get; set; }

    public string RateCenter { get; set; }
    public string State { get; set; }
    public string TelephoneNumber { get; set; }
    public string Tier { get; set; }
    public string VendorId { get; set; }
    public string VendorName { get; set; }
  }
}
