using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Site Api (IRIS)
  /// </summary>
  public interface ISite
  {
    /// <summary>
    ///   Create a site
    /// </summary>
    /// <param name="data">data of new  site</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created sip site</returns>
    /// <example>
    /// <code>
    /// var id = await client.Site.CreateAsync(new Site{Name = "site"});
    /// </code>
    /// </example>
    Task<string> CreateAsync(Site data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get a  site data
    /// </summary>
    /// <param name="id">Site Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Site data</returns>
    /// <example>
    /// <code>
    /// var site = await client.Site.GetAsync("id");
    /// </code>
    /// </example>
    Task<Site> GetAsync(string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List sites
    /// </summary>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of sites data</returns>
    /// <example>
    /// <code>
    /// var sites = await client.Site.ListAsync();
    /// </code>
    /// </example>
    Task<Site[]> ListAsync(CancellationToken? cancellationToken = null);


    /// <summary>
    ///   Update a site
    /// </summary>
    /// <param name="id">Site Id</param>
    /// <param name="data">Changed site data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <example>
    /// <code>
    /// await client.Site.UpdateAsync("id", new Site{Description = "test"});
    /// </code>
    /// </example>
    Task UpdateAsync(string id, Site data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Remove a site
    /// </summary>
    /// <param name="id">Site Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <example>
    /// <code>
    /// await client.Site.DeleteAsync("id"});
    /// </code>
    /// </example>
    Task DeleteAsync(string id, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  /// Site
  /// </summary>
  public class Site
  {
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    public Address Address { get; set; }
  }

  /// <summary>
  /// SitesResponse
  /// </summary>
  public class SitesResponse
  {
    /// <summary>
    /// Sites
    /// </summary>
    public Site[] Sites { get; set; }
  }

  /// <summary>
  /// SiteResponse
  /// </summary>
  public class SiteResponse
  {
    /// <summary>
    /// Site
    /// </summary>
    public Site Site { get; set; }
  }


  internal class SiteApi : ApiBase, ISite
  {
    public Task<string> CreateAsync(Site data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/sites", cancellationToken, data);
    }

    public async Task<Site> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<SiteResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}/sites/{id}",
        cancellationToken)).Site;
    }

    public async Task<Site[]> ListAsync(CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<SitesResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}/sites",
            cancellationToken)).Sites;
    }

    public Task UpdateAsync(string id, Site data, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Put,
        $"/accounts/{Api.AccountId}/sites/{id}", cancellationToken, null, data);
    }


    public Task DeleteAsync(string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Delete,
        $"/accounts/{Api.AccountId}/sites/{id}", cancellationToken);
    }
  }
}
