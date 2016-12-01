using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to City Api (IRIS)
  /// </summary>
  public interface ICity
  {
    /// <summary>
    /// Get information about cities
    /// </summary>
    /// <param name="query">Optional query</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of cities data</returns>
    Task<City[]> ListAsync(CityQuery query = null, CancellationToken? cancellationToken = null);
  }

  internal class CityApi : ApiBase, ICity
  {
    public async Task<City[]> ListAsync(CityQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<CityResponse>(HttpMethod.Get,
        "/cities", cancellationToken, query)).Cities;
    }
  }

  /// <summary>
  ///   Query parameters for city request
  /// </summary>
  public class CityQuery
  {
    /// <summary>
    ///   State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    ///   Supported
    /// </summary>
    public bool? Supported { get; set; }

    /// <summary>
    ///   Available
    /// </summary>
    public bool? Available { get; set; }
  }

  /// <summary>
  /// City
  /// </summary>
  public class City
  {
    /// <summary>
    /// RcAbbreviation
    /// </summary>
    public string RcAbbreviation { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
  }

  /// <summary>
  /// CityResponse
  /// </summary>
  public class CityResponse
  {
    /// <summary>
    /// Cities
    /// </summary>
    public City[] Cities { get; set; }
  }
}