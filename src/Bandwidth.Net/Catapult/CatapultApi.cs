using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Catapult
{
  /// <summary>
  ///   Catapult Api
  /// </summary>
  public class CatapultApi : ICatapultApi
  {
    private readonly IHttp _http;

    /// <summary>
    /// Contructor
    /// </summary>
    /// <param name="authData">Auth data</param>
    /// <param name="http">object which implements http requests handling (usefull for tests)</param>
    /// <example>
    /// <code>
    /// var api = new CatapultApi(new CatapultAuthData{UserId = "userId", ApiToken = "token", ApiSecret = "secret"}, new YourMockHttp());
    /// </code>
    /// </example>
    public CatapultApi(CatapultAuthData authData, IHttp http)
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
      if (string.IsNullOrEmpty(authData.UserId) || string.IsNullOrEmpty(authData.ApiToken) ||
          string.IsNullOrEmpty(authData.ApiSecret))
      {
        throw new MissingCredentialsException("Catapult");
      }
      if (string.IsNullOrEmpty(authData.BaseUrl))
      {
        throw new InvalidBaseUrlException();
      }
      AuthenticationHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{authData.ApiToken}:{authData.ApiSecret}")));
      BaseUrl = authData.BaseUrl;
      UserId = authData.UserId;
      Error = new ErrorApi {Api = this};
      Account = new AccountApi {Api = this};
      Application = new ApplicationApi {Api = this};
      AvailableNumber = new AvailableNumberApi {Api = this};
      Bridge = new BridgeApi {Api = this};
      Domain = new DomainApi {Api = this};
      Call = new CallApi {Api = this};
      Conference = new ConferenceApi {Api = this};
      Message = new MessageApi {Api = this};
      NumberInfo = new NumberInfoApi {Api = this};
      PhoneNumber = new PhoneNumberApi {Api = this};
      Recording = new RecordingApi {Api = this};
      Transcription = new TranscriptionApi {Api = this};
      Media = new MediaApi {Api = this};
      Endpoint = new EndpointApi {Api = this};
    }

    /// <summary>
    /// Contructor
    /// </summary>
    /// <param name="authData">Auth data</param>
    /// <example>
    /// <code>
    /// var api = new CatapultApi(new CatapultAuthData{UserId = "userId", ApiToken = "token", ApiSecret = "secret"});
    /// </code>
    /// </example>
    public CatapultApi(CatapultAuthData authData) : this(authData, new Http<HttpClientHandler>())
    {
    }

    internal readonly AuthenticationHeaderValue AuthenticationHeader;
    internal readonly string BaseUrl;
    internal readonly string UserId;

    /// <summary>
    ///   Access to Error Api
    /// </summary>
    public IError Error { get; }

    /// <summary>
    ///   Access to Account Api
    /// </summary>
    public IAccount Account { get; }

    /// <summary>
    ///   Access to Application Api
    /// </summary>
    public IApplication Application { get; }

    /// <summary>
    ///   Access to AvailableNumber Api
    /// </summary>
    public IAvailableNumber AvailableNumber { get; }

    /// <summary>
    ///   Access to Bridge Api
    /// </summary>
    public IBridge Bridge { get; }

    /// <summary>
    ///   Access to Domain Api
    /// </summary>
    public IDomain Domain { get; }

    /// <summary>
    ///   Access to Call Api
    /// </summary>
    public ICall Call { get; }


    /// <summary>
    ///   Access to Conference Api
    /// </summary>
    public IConference Conference { get; }

    /// <summary>
    ///   Access to Message Api
    /// </summary>
    public IMessage Message { get; }

    /// <summary>
    ///   Access to NumberInfo Api
    /// </summary>
    public INumberInfo NumberInfo { get; }

    /// <summary>
    ///   Access to PhoneNumber Api
    /// </summary>
    public IPhoneNumber PhoneNumber { get; }

    /// <summary>
    ///   Access to Recording Api
    /// </summary>
    public IRecording Recording { get; }

    /// <summary>
    ///   Access to Transcription Api
    /// </summary>
    public ITranscription Transcription { get; }

    /// <summary>
    ///   Access to Media Api
    /// </summary>
    public IMedia Media { get; }

    /// <summary>
    ///   Access to Endpoint Api
    /// </summary>
    public IEndpoint Endpoint { get; }

    internal async Task<HttpResponseMessage> MakeJsonRequestAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null, HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
    {
      var response = await _http.SendAsync(request, completionOption, cancellationToken);
      await response.CheckJsonResponseAsync();
      return response;
    }

    internal async Task<T> MakeJsonRequestAsync<T>(HttpMethod method, string path,  CancellationToken? cancellationToken = null, object query = null, object body = null)
    {
      using (var response = await MakeJsonRequestAsync(method, path, cancellationToken, query, body))
      {
        return await response.Content.ReadAsJsonAsync<T>();
      }
    }

    internal async Task<HttpResponseMessage> MakeJsonRequestAsync(HttpMethod method, string path, CancellationToken? cancellationToken = null, object query = null, object body = null)
    {
      var request = RequestHelpers.CreateRequest(method, path, BaseUrl, AuthenticationHeader, query);
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      if (body != null)
      {
        request.SetJsonContent(body);
      }
      return await MakeJsonRequestAsync(request,  cancellationToken);
    }

    internal async Task MakeJsonRequestWithoutResponseAsync(HttpMethod method, string path,
      CancellationToken? cancellationToken = null, object query = null, object body = null)
    {
      using (await MakeJsonRequestAsync(method, path, cancellationToken, query, body))
      {
      }
    }

    internal async Task<string> MakePostJsonRequestAsync(string path, CancellationToken? cancellationToken = null, object body = null)
    {
      using (var response = await MakeJsonRequestAsync(HttpMethod.Post, path, cancellationToken, null, body))
      {
        return (response.Headers.Location ?? new Uri("http://localhost")).AbsolutePath.Split('/').LastOrDefault();
      }
    }

  }
}
