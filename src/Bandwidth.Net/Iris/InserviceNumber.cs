using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to InserviceNumber Api (IRIS)
  /// </summary>
  public interface IInserviceNumber
  {
    /// <summary>
    ///   Return list of inservice numbers
    /// </summary>
    /// <param name="query">Query parameters</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>List of numbers</returns>
    /// <example>
    /// <code>
    /// var list = await client.InserviceNumber.ListAsync();
    /// </code>
    /// </example>
    Task<string[]> ListAsync(InserviceNumberQuery query = null, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return totals data for numbers
    /// </summary>
    /// <returns>Total data</returns>
    /// <example>
    /// <code>
    /// var totals = await client.InserviceNumber.GetTotalsAsync();
    /// </code>
    /// </example>
    Task<Quantity> GetTotalsAsync(CancellationToken? cancellationToken = null);
  }

  internal class InserviceNumberApi : ApiBase, IInserviceNumber
  {
    public async Task<string[]> ListAsync(InserviceNumberQuery query = null, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<InServiceNumberTns>(HttpMethod.Get, $"/accounts/{Api.AccountId}/inserviceNumbers",
            cancellationToken)).TelephoneNumbers.Numbers;
    }

    public Task<Quantity> GetTotalsAsync(CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<Quantity>(HttpMethod.Get, $"/accounts/{Api.AccountId}/inserviceNumbers/totals",
        cancellationToken);
    }
  }

  /// <summary>
  /// Query parameters to get inservice numbers
  /// </summary>
  public class InserviceNumberQuery
  {
    /// <summary>
    /// Areacode
    /// </summary>
    public string Areacode { get; set; }

    /// <summary>
    /// Enddate
    /// </summary>
    public DateTime? Enddate { get; set; }

    /// <summary>
    /// Lata
    /// </summary>
    public string Lata { get; set; }

    /// <summary>
    /// Npanxx
    /// </summary>
    public string Npanxx { get; set; }

    /// <summary>
    /// Ratecenter
    /// </summary>
    public string Ratecenter { get; set; }

    /// <summary>
    /// Startdate
    /// </summary>
    public DateTime? Startdate { get; set; }

    /// <summary>
    /// State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Page
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Size
    /// </summary>
    public int? Size { get; set; }    
  }


  /// <summary>
  /// InServiceNumberTns
  /// </summary>
  [XmlRoot("TNs")]
  public class InServiceNumberTns
  {
    /// <summary>
    /// TelephoneNumbers
    /// </summary>
    public TelephoneNumbers TelephoneNumbers { get; set; }
  }
}
