using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Catapult Api
  /// </summary>
  public class IrisApi : IIrisApi
  {
    private readonly IHttp _http;

    internal readonly AuthenticationHeaderValue AuthenticationHeader;
    internal readonly string BaseUrl;
    internal readonly string AccountId;

    /// <summary>
    ///   Contructor
    /// </summary>
    /// <param name="authData">Auth data</param>
    /// <param name="http">object which implements http requests handling (usefull for tests)</param>
    /// <example>
    ///   <code>
    /// var api = new IrisApi(new IrisAuthData{AccountId = "id", UserName = "name", Password = "password"}, new YourMockHttp());
    /// </code>
    /// </example>
    public IrisApi(IrisAuthData authData, IHttp http)
    {
      _http = http;
      if (authData == null)
      {
        throw new ArgumentNullException(nameof(authData));
      }
      if (http == null)
      {
        throw new ArgumentNullException(nameof(http));
      }
      if (string.IsNullOrEmpty(authData.AccountId) || string.IsNullOrEmpty(authData.UserName) ||
          string.IsNullOrEmpty(authData.Password))
      {
        throw new MissingCredentialsException("Catapult");
      }
      if (string.IsNullOrEmpty(authData.BaseUrl))
      {
        throw new InvalidBaseUrlException();
      }
      AuthenticationHeader = new AuthenticationHeaderValue("Basic",
        Convert.ToBase64String(Encoding.UTF8.GetBytes($"{authData.UserName}:{authData.Password}")));
      BaseUrl = authData.BaseUrl;
      AccountId = authData.AccountId;

      Account = new AccountApi { Api = this };
      AvailableNpaNxx = new AvailableNpaNxxApi {Api = this};
      AvailableNumber = new AvailableNumberApi {Api = this};
      City = new CityApi {Api = this};
      CoveredRateCenter = new CoveredRateCenterApi { Api = this };
      DiscNumber = new DiscNumberApi { Api = this };
    }

    /// <summary>
    ///   Contructor
    /// </summary>
    /// <param name="authData">Auth data</param>
    /// <example>
    ///   <code>
    /// var api = new IrisApi(new IrisAuthData{AccountId = "id", UserName = "name", Password = "password"});
    /// </code>
    /// </example>
    public IrisApi(IrisAuthData authData) : this(authData, new Http<HttpClientHandler>())
    {
    }

    /// <summary>
    /// Access to Account Api
    /// </summary>
    public IAccount Account { get;}

    /// <summary>
    /// Access to AvailableNpaNxx Api
    /// </summary>
    public IAvailableNpaNxx AvailableNpaNxx { get; }

    /// <summary>
    /// Access to AvailableNumber Api
    /// </summary>
    public IAvailableNumber AvailableNumber { get;}

    /// <summary>
    /// Access to City Api
    /// </summary>
    public ICity City { get; }

    /// <summary>
    /// Access to CoveredRateCenter Api
    /// </summary>
    public ICoveredRateCenter CoveredRateCenter { get; }

    /// <summary>
    /// Access to DiscNumber Api
    /// </summary>
    public IDiscNumber DiscNumber { get; }

    internal async Task<HttpResponseMessage> MakeXmlRequestAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
    {
      var response = await _http.SendAsync(request, completionOption, cancellationToken);
      await response.CheckXmlResponseAsync();
      return response;
    }

    internal async Task<T> MakeXmlRequestAsync<T>(HttpMethod method, string path, CancellationToken? cancellationToken = null, object query = null, object body = null)
    {
      using (var response = await MakeXmlRequestAsync(method, path, cancellationToken, query, body))
      {
        return await response.Content.ReadAsXmlAsync<T>();
      }
    }

    internal async Task<HttpResponseMessage> MakeXmlRequestAsync(HttpMethod method, string path, CancellationToken? cancellationToken = null, object query = null, object body = null)
    {
      var request = RequestHelpers.CreateRequest(method, path, BaseUrl, AuthenticationHeader, query);
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
      if (body != null)
      {
        request.SetXmlContent(body);
      }
      return await MakeXmlRequestAsync(request, cancellationToken);
    }


    internal async Task MakeXmlRequestWithoutResponseAsync(HttpMethod method, string path, 
      CancellationToken? cancellationToken = null, object query = null, object body = null)
    {
      using (await MakeXmlRequestAsync(method, path, cancellationToken, query, body))
      {
      }
    }


    internal async Task<string> MakePostXmlRequestAsync(string path, CancellationToken? cancellationToken = null, object body = null)
    {
      using (var response = await MakeXmlRequestAsync(HttpMethod.Post, path, cancellationToken, null, body))
      {
        return (response.Headers.Location ?? new Uri("http://localhost")).AbsolutePath.Split('/').LastOrDefault();
      }
    }
  }
}
