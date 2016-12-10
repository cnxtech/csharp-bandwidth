using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to RateCenter Api (IRIS)
  /// </summary>
  public interface IRateCenter
  {
    /// <summary>
    ///   List rate centers
    /// </summary>
    /// <returns>Array of orders data</returns>
    Task<RateCenter[]> ListAsync(RateCenterQuery query = null, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  ///   Query parameters for rate centers
  /// </summary>
  public class RateCenterQuery
  {
    /// <summary>
    /// State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Supported
    /// </summary>
    public bool? Supported { get; set; }
  }

  /// <summary>
  /// Rate center
  /// </summary>
  public class RateCenter
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
  /// RateCenterResponse
  /// </summary>
  public class RateCenterResponse
  {
    /// <summary>
    /// RateCenters
    /// </summary>
    public RateCenter[] RateCenters { get; set; }
  }


  internal class RateCenterApi : ApiBase, IRateCenter
  {
    public async Task<RateCenter[]> ListAsync(RateCenterQuery query = null, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<RateCenterResponse>(HttpMethod.Get, "/rateCenters", cancellationToken, query))
          .RateCenters;
    }
  }
}
