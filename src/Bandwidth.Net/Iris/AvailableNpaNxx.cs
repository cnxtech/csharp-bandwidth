using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  /// Access to AvailableNpaNxx Api (IRIS)
  /// </summary>
  public interface IAvailableNpaNxx
  {
    /// <summary>
    ///  Get information about available NpaNxxs 
    /// </summary>
    /// <param name="query">Optional query parameters</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Aray of data with available NpaNxxs</returns>
    Task<AvailableNpaNxx[]> ListAsync(AvailableNpaNxxQuery query = null, CancellationToken? cancellationToken = null);
  }

  internal class AvailableNpaNxxApi : ApiBase, IAvailableNpaNxx
  {
    public async Task<AvailableNpaNxx[]> ListAsync(AvailableNpaNxxQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<AvailableNpaNxxResult>(HttpMethod.Get, $"/accounts/{Api.AccountId}/availableNpaNxx", cancellationToken, query))
        .AvailableNpaNxxList;
    }
  }

  /// <summary>
  /// Query parameters to get available NpaNxx
  /// </summary>
  public class AvailableNpaNxxQuery
  {
    /// <summary>
    /// AreaCode
    /// </summary>
    public string AreaCode { get; set; }
  }

  /// <summary>
  /// SearchResultForAvailableNpaNxx
  /// </summary>
  [XmlType("SearchResultForAvailableNpaNxx")]
  public class AvailableNpaNxxResult
  {
    /// <summary>
    /// AvailableNpaNxxList
    /// </summary>
    public AvailableNpaNxx[] AvailableNpaNxxList { get; set; }
  }

  /// <summary>
  /// AvailableNpaNxx
  /// </summary>
  public class AvailableNpaNxx
  {
    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Npa
    /// </summary>
    public string Npa { get; set; }

    /// <summary>
    /// Nxx
    /// </summary>
    public string Nxx { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public int Quantity { get; set; }
  }
}
