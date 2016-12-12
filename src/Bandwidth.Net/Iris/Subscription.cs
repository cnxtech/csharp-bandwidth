using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Subscription Api (IRIS)
  /// </summary>
  public interface ISubscription
  {
    /// <summary>
    ///   Create a subscription
    /// </summary>
    /// <param name="data">data of new subscription</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created subscription</returns>
    Task<string> CreateAsync(Subscription data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get a  subscription data
    /// </summary>
    /// <param name="id">Subscription Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Subscription data</returns>
    Task<Subscription> GetAsync(string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List subscriptions
    /// </summary>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of subscriptions data</returns>
    Task<Subscription[]> ListAsync(CancellationToken? cancellationToken = null);


    /// <summary>
    ///   Update a subscription
    /// </summary>
    /// <param name="id">Subscription Id</param>
    /// <param name="data">Changed subscription data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    Task UpdateAsync(string id, Subscription data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Remove a subscription
    /// </summary>
    /// <param name="id">Subscription Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    Task DeleteAsync(string id, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  ///   Subscription
  /// </summary>
  public class Subscription
  {
    /// <summary>
    ///   Id
    /// </summary>
    public string Id => SubscriptionId;

    /// <summary>
    ///   SubscriptionId
    /// </summary>
    public string SubscriptionId { get; set; }

    /// <summary>
    ///   OrderType
    /// </summary>
    public string OrderType { get; set; }

    /// <summary>
    ///   OrderId
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    ///   EmailSubscription
    /// </summary>
    public EmailSubscription EmailSubscription { get; set; }

    /// <summary>
    ///   CallbackSubscription
    /// </summary>
    public CallbackSubscription CallbackSubscription { get; set; }
  }

  /// <summary>
  ///   CallbackSubscription
  /// </summary>
  public class CallbackSubscription
  {
    /// <summary>
    ///   Url
    /// </summary>
    [XmlElement("URL")]
    public string Url { get; set; }

    /// <summary>
    ///   User
    /// </summary>
    public string User { get; set; }

    /// <summary>
    ///   Expiry
    /// </summary>
    public int Expiry { get; set; }
  }

  /// <summary>
  ///   EmailSubscription
  /// </summary>
  public class EmailSubscription
  {
    /// <summary>
    ///   Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///   DigestRequested
    /// </summary>
    public string DigestRequested { get; set; }
  }

  /// <summary>
  ///   SubscriptionsResponse
  /// </summary>
  public class SubscriptionsResponse
  {
    /// <summary>
    ///   Subscriptions
    /// </summary>
    public Subscription[] Subscriptions { get; set; }
  }


  internal class SubscriptionApi : ApiBase, ISubscription
  {
    public Task<string> CreateAsync(Subscription data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/subscriptions", cancellationToken, data);
    }

    public async Task<Subscription> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        ((await
          Api.MakeXmlRequestAsync<SubscriptionsResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}/subscriptions/{id}",
            cancellationToken)).Subscriptions ?? new Subscription[0]).FirstOrDefault();
    }

    public async Task<Subscription[]> ListAsync(CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<SubscriptionsResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}/subscriptions",
            cancellationToken)).Subscriptions;
    }

    public Task UpdateAsync(string id, Subscription data, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Put,
        $"/accounts/{Api.AccountId}/subscriptions/{id}", cancellationToken, null, data);
    }


    public Task DeleteAsync(string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Delete,
        $"/accounts/{Api.AccountId}/subscriptions/{id}", cancellationToken);
    }
  }
}
