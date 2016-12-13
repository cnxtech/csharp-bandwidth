using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to CoveredRateCenter Api (IRIS)
  /// </summary>
  public interface ICoveredRateCenter
  {
    /// <summary>
    ///   Get information about covered rate centers
    /// </summary>
    /// <param name="query">Optional query</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of data about rate centers</returns>
    /// <example>
    /// <code>
    /// var list = await client.CoveredRateCenter.ListAsync();
    /// </code>
    /// </example>
    Task<CoveredRateCenter[]> ListAsync(CityQuery query = null, CancellationToken? cancellationToken = null);
  }

  internal class CoveredRateCenterApi : ApiBase, ICoveredRateCenter
  {
    public async Task<CoveredRateCenter[]> ListAsync(CityQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<CoveredRateCenters>(HttpMethod.Get,
        "/coveredRateCenters", cancellationToken, query)).CoveredRateCenter;
    }
  }

  /// <summary>
  ///   Query parameters for covered rate center request
  /// </summary>
  public class CoveredRateCenters
  {
    /// <summary>
    /// CoveredRateCenter
    /// </summary>
    [XmlElement("CoveredRateCenter")]
    public CoveredRateCenter[] CoveredRateCenter { get; set; }

    /// <summary>
    /// Links
    /// </summary>
    public Links Links { get; set; }
  }

  /// <summary>
  /// CoveredRateCenter
  /// </summary>
  public class CoveredRateCenter
  {
    /// <summary>
    /// Abbreviation
    /// </summary>
    public string Abbreviation { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
  }

  /// <summary>
  /// Links
  /// </summary>
  public class Links
  {
    /// <summary>
    /// First
    /// </summary>
    public string First { get; set; }

    /// <summary>
    /// Last
    /// </summary>
    public string Last { get; set; }
  }
}
