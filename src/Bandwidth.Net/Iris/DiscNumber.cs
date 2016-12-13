using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to DiscNumber Api (IRIS)
  /// </summary>
  public interface IDiscNumber
  {
    /// <summary>
    ///   Get information about dicovered numbers
    /// </summary>
    /// <param name="query">Optional query</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of data about numbers</returns>
    /// <example>
    /// <code>
    /// var list = await client.DiscNumber.ListAsync();
    /// </code>
    /// </example>
    Task<string[]> ListAsync(CityQuery query = null, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get totals about dicovered numbers
    /// </summary>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Totals data</returns>
    /// <example>
    /// <code>
    /// var totals = await client.DiscNumber.GetTotalsAsync();
    /// </code>
    /// </example>
    Task<Quantity> GetTotalsAsync(CancellationToken? cancellationToken = null);
  }

  internal class DiscNumberApi : ApiBase, IDiscNumber
  {
    public async Task<string[]> ListAsync(CityQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<DiscNumberResponse>(HttpMethod.Get,
        $"/accounts/{Api.AccountId}/discnumbers", cancellationToken, query)).TelephoneNumbers.Numbers;
    }

    public async Task<Quantity> GetTotalsAsync(CancellationToken? cancellationToken = null)
    {
      return await Api.MakeXmlRequestAsync<Quantity>(HttpMethod.Get,
        $"/accounts/{Api.AccountId}/discnumbers/totals", cancellationToken);
    }
  }

  /// <summary>
  /// DiscNumberResponse
  /// </summary>
  [XmlRoot("TNs")]
  public class DiscNumberResponse
  {
    /// <summary>
    /// TelephoneNumbers
    /// </summary>
    public TelephoneNumbers TelephoneNumbers { get; set; }
  }

  /// <summary>
  /// TelephoneNumbers
  /// </summary>
  public class TelephoneNumbers
  {
    /// <summary>
    /// Numbers
    /// </summary>
    [XmlElement("TelephoneNumber")]
    public string[] Numbers { get; set; }
  }


  /// <summary>
  /// Quantity
  /// </summary>
  public class Quantity
  {
    /// <summary>
    /// Count
    /// </summary>
    public int Count { get; set; }
  }
}
