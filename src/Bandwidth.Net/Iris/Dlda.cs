using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Dlda Api (IRIS)
  /// </summary>
  public interface IDlda
  {
    /// <summary>
    ///   Create a Dlda
    /// </summary>
    /// <param name="data">data of new Dlda order</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created Dlda</returns>
    /// <example>
    /// <code>
    /// var id = await client.Dlda.CreateAsync(new Dlda{DldaTnGroups = new[]{new DldaTnGroup{TelephoneNumbers = new TelephoneNumbers{Numbers = new[]{"+1234567890"}}}}});
    /// </code>
    /// </example>
    Task<string> CreateAsync(Dlda data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get a Dlda
    /// </summary>
    /// <param name="id">Dlda Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Dlda data</returns>
    /// <example>
    /// <code>
    /// var data = await client.Dlda.GetAsync("id");
    /// </code>
    /// </example>
    Task<Dlda> GetAsync(string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List orders
    /// </summary>
    /// <returns>Array of orders data</returns>
    /// <example>
    /// <code>
    /// var list = await client.Dlda.ListAsync();
    /// </code>
    /// </example>
    Task<OrderIdUserIdDate[]> ListAsync(DldaQuery query = null, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Update a Dlda
    /// </summary>
    /// <param name="id">Dlda Id</param>
    /// <param name="data">data to change</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <example>
    /// <code>
    /// await client.Dlda.UpdateAsync("id", new Dlda{DldaTnGroups = new[]{new DldaTnGroup{TelephoneNumbers = new TelephoneNumbers{Numbers = new[]{"+1234567890"}}}}});
    /// </code>
    /// </example>
    Task UpdateAsync(string id, Dlda data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return orders history
    /// </summary>
    /// <param name="id">Dlda Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of orders</returns>
    /// <example>
    /// <code>
    /// var list = await client.Dlda.GetHistoryAsync("id");
    /// </code>
    /// </example>
    Task<OrderHistoryItem[]> GetHistoryAsync(string id, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  /// Query parameters for Dlda
  /// </summary>
  public class DldaQuery
  {
    /// <summary>
    /// LastModifiedAfter
    /// </summary>
    public DateTime? LastModifiedAfter { get; set; }

    /// <summary>
    /// ModifiedDateFrom
    /// </summary>
    public DateTime? ModifiedDateFrom { get; set; }

    /// <summary>
    /// ModifiedDateTo
    /// </summary>
    public DateTime? ModifiedDateTo { get; set; }

    /// <summary>
    /// Tn
    /// </summary>
    public string Tn { get; set; }
  }

  /// <summary>
  ///   DLDA
  /// </summary>
  public class Dlda
  {
    /// <summary>
    ///   Id
    /// </summary>
    public string Id => OrderId;

    /// <summary>
    /// CustomerOrderId
    /// </summary>
    public string CustomerOrderId { get; set; }

    /// <summary>
    /// OrderCreateDate
    /// </summary>
    public DateTime OrderCreateDate { get; set; }

    /// <summary>
    /// AccountId
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    /// CreatedByUser
    /// </summary>
    public string CreatedByUser { get; set; }

    /// <summary>
    /// OrderId
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// LastModifiedDate
    /// </summary>
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// ProcessingStatus
    /// </summary>
    public string ProcessingStatus { get; set; }

    /// <summary>
    /// DldaTnGroups
    /// </summary>
    public DldaTnGroup[] DldaTnGroups { get; set; }
  }

  /// <summary>
  /// DldaOrderResponse
  /// </summary>
  public class DldaOrderResponse
  {
    /// <summary>
    /// DldaOrder
    /// </summary>
    public Dlda DldaOrder { get; set; }
  }


  /// <summary>
  /// DldaTnGroup
  /// </summary>
  public class DldaTnGroup
  {
    /// <summary>
    /// TelephoneNumbers
    /// </summary>
    public TelephoneNumbers TelephoneNumbers { get; set; }

    /// <summary>
    /// AccountType
    /// </summary>
    public string AccountType { get; set; }

    /// <summary>
    /// ListingType
    /// </summary>
    public string ListingType { get; set; }

    /// <summary>
    /// ListingName
    /// </summary>
    public ListingName ListingName { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// SubscriberType
    /// </summary>
    public string SubscriberType { get; set; }

    /// <summary>
    /// ListAddress
    /// </summary>
    public bool ListAddress { get; set; }
  }


  /// <summary>
  /// ListingName
  /// </summary>
  public class ListingName
  {
    /// <summary>
    /// FirstName
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    public string LastName { get; set; }
  }

  /// <summary>
  /// ResponseSelectWrapper
  /// </summary>
  public class ResponseSelectWrapper
  {
    /// <summary>
    /// ListOrderIdUserIdDate
    /// </summary>
    public OrderIdUserIdDate[] ListOrderIdUserIdDate { get; set; }
  }

  /// <summary>
  /// OrderIdUserIdDate
  /// </summary>
  public class OrderIdUserIdDate
  {
    /// <summary>
    /// AccountId
    /// </summary>
    [XmlElement("accountId")]
    public string AccountId { get; set; }

    /// <summary>
    /// OrderId
    /// </summary>
    [XmlElement("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// UserId
    /// </summary>
    [XmlElement("userId")]
    public string UserId { get; set; }

    /// <summary>
    /// OrderType
    /// </summary>
    public string OrderType { get; set; }

    /// <summary>
    /// OrderStatus
    /// </summary>
    public string OrderStatus { get; set; }

    /// <summary>
    /// OrderDate
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// CountOfTns
    /// </summary>
    [XmlElement("CountOfTNs")]
    public int CountOfTns { get; set; }


    /// <summary>
    /// LastModifiedDate
    /// </summary>
    [XmlElement("lastModifiedDate")]
    public DateTime LastModifiedDate { get; set; }
  }

  /// <summary>
  /// OrderHistoryWrapper
  /// </summary>
  public class OrderHistoryWrapper
  {
    /// <summary>
    /// Items
    /// </summary>
    [XmlElement("OrderHistory")]
    public OrderHistoryItem[] Items { get; set; }
  }

  /// <summary>
  /// OrderHistoryItem
  /// </summary>
  public class OrderHistoryItem
  {
    /// <summary>
    /// OrderData
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Note
    /// </summary>
    public string Note { get; set; }

    /// <summary>
    /// Author
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public string Status { get; set; }
  }


  internal class DldaApi : ApiBase, IDlda
  {
    public Task<string> CreateAsync(Dlda data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/dldas", cancellationToken, data);
    }

    public async Task<Dlda> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<DldaOrderResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}/dldas/{id}",
            cancellationToken)).DldaOrder;
    }

    public async Task<OrderIdUserIdDate[]> ListAsync(DldaQuery query = null, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<ResponseSelectWrapper>(HttpMethod.Get, $"/accounts/{Api.AccountId}/dldas",
            cancellationToken, query)).ListOrderIdUserIdDate;
    }

    public Task UpdateAsync(string id, Dlda data, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Post, $"/accounts/{Api.AccountId}/dldas/{id}",
        cancellationToken, null, data);
    }

    public async Task<OrderHistoryItem[]> GetHistoryAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<OrderHistoryWrapper>(HttpMethod.Get, $"/accounts/{Api.AccountId}/dldas/{id}/history",
            cancellationToken)).Items;
    }
  }
}
