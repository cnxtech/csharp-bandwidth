using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to LsrOrder Api (IRIS)
  /// </summary>
  public interface ILsrOrder
  {
    /// <summary>
    ///   Create a LsrOrder
    /// </summary>
    /// <param name="data">data of new LsrOrder order</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created LsrOrder</returns>
    Task<string> CreateAsync(LsrOrder data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get a LsrOrder
    /// </summary>
    /// <param name="id">LsrOrder Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>LsrOrder data</returns>
    Task<LsrOrder> GetAsync(string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List orders
    /// </summary>
    /// <returns>Array of orders data</returns>
    Task<LsrOrderSummary[]> ListAsync(LsrOrderQuery query = null, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Update a LsrOrder
    /// </summary>
    /// <param name="id">LsrOrder Id</param>
    /// <param name="data">data to change</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    Task UpdateAsync(string id, LsrOrder data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return orders history
    /// </summary>
    /// <param name="id">LsrOrder Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of orders</returns>
    Task<OrderHistoryItem[]> GetHistoryAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Add note to the order
    /// </summary>
    /// <param name="id">Order Id</param>
    /// <param name="note">Note data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created note</returns>
    Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return list of notes of the order
    /// </summary>
    /// <param name="id">Order id</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Array of notes</returns>
    Task<Note[]> GetNotes(string id, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  ///   Query parameters for LsrOrder
  /// </summary>
  public class LsrOrderQuery
  {
    /// <summary>
    ///   CreatedDateFrom
    /// </summary>
    public DateTime? CreatedDateFrom { get; set; }

    /// <summary>
    ///   CreatedDateTo
    /// </summary>
    public DateTime? CreatedDateTo { get; set; }

    /// <summary>
    ///   CustomerOrderId
    /// </summary>
    public DateTime? CustomerOrderId { get; set; }

    /// <summary>
    ///   OrderIdFragment
    /// </summary>
    public DateTime? OrderIdFragment { get; set; }

    /// <summary>
    ///   Pon
    /// </summary>
    public string Pon { get; set; }

    /// <summary>
    ///   Status
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    ///   Tn
    /// </summary>
    public string Tn { get; set; }
  }

  /// <summary>
  ///   LsrOrder
  /// </summary>
  public class LsrOrder
  {
    /// <summary>
    ///   Id
    /// </summary>
    public string Id => OrderId;

    /// <summary>
    ///   OrderId
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    ///   CustomerOrderId
    /// </summary>
    public string CustomerOrderId { get; set; }

    /// <summary>
    ///   LastModifiedBy
    /// </summary>
    public string LastModifiedBy { get; set; }

    /// <summary>
    ///   OrderCreateDate
    /// </summary>
    public DateTime OrderCreateDate { get; set; }

    /// <summary>
    ///   LastModifiedDate
    /// </summary>
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    ///   AccountId
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    ///   OrderStatus
    /// </summary>
    public string OrderStatus { get; set; }

    /// <summary>
    ///   Spid
    /// </summary>
    [XmlElement("SPID")]
    public string Spid { get; set; }

    /// <summary>
    ///   BillingTelephoneNumber
    /// </summary>
    public string BillingTelephoneNumber { get; set; }

    /// <summary>
    ///   Pon
    /// </summary>
    public string Pon { get; set; }

    /// <summary>
    ///   PonVersion
    /// </summary>
    public string PonVersion { get; set; }

    /// <summary>
    ///   RequestedFocDate
    /// </summary>
    public DateTime RequestedFocDate { get; set; }

    /// <summary>
    ///   AuthorizingPerson
    /// </summary>
    public string AuthorizingPerson { get; set; }

    /// <summary>
    ///   Subscriber
    /// </summary>
    public Subscriber Subscriber { get; set; }


    /// <summary>
    ///   ListOfTelephoneNumbers
    /// </summary>
    [XmlArrayItem("TelephoneNumber")]
    public string[] ListOfTelephoneNumbers { get; set; }

    /// <summary>
    ///   CountOfTns
    /// </summary>
    [XmlElement("CountOfTNs")]
    public int CountOfTns { get; set; }
  }

  /// <summary>
  ///   Subscriber
  /// </summary>
  public class Subscriber
  {
    /// <summary>
    ///   SubscriberType
    /// </summary>
    public string SubscriberType { get; set; }

    /// <summary>
    ///   BusinessName
    /// </summary>
    public string BusinessName { get; set; }

    /// <summary>
    ///   AccountNumber
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    ///   PinNumber
    /// </summary>
    public string PinNumber { get; set; }

    /// <summary>
    ///   ServiceAddress
    /// </summary>
    public Address ServiceAddress { get; set; }
  }

  /// <summary>
  ///   LsrOrders
  /// </summary>
  public class LsrOrders
  {
    /// <summary>
    ///   Orders
    /// </summary>
    [XmlElement("LsrOrderSummary")]
    public LsrOrderSummary[] Orders { get; set; }
  }

  /// <summary>
  ///   LsrOrderSummary
  /// </summary>
  public class LsrOrderSummary
  {
    /// <summary>
    ///   Id
    /// </summary>
    public string Id => OrderId;

    /// <summary>
    ///   AccountId
    /// </summary>
    [XmlElement("accountId")]
    public string AccountId { get; set; }

    /// <summary>
    ///   CountOfTns
    /// </summary>
    [XmlElement("CountOfTNs")]
    public int CountOfTns { get; set; }

    /// <summary>
    ///   CustomerOrderId
    /// </summary>
    public string CustomerOrderId { get; set; }

    /// <summary>
    ///   LastModifiedDate
    /// </summary>
    [XmlElement("lastModifiedDate")]
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    ///   UserId
    /// </summary>
    [XmlElement("userId")]
    public string UserId { get; set; }

    /// <summary>
    ///   OrderDate
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    ///   OrderType
    /// </summary>
    public string OrderType { get; set; }

    /// <summary>
    ///   OrderStatus
    /// </summary>
    public string OrderStatus { get; set; }

    /// <summary>
    ///   BillingTelephoneNumber
    /// </summary>
    public string BillingTelephoneNumber { get; set; }

    /// <summary>
    ///   ActualFocDate
    /// </summary>
    public DateTime ActualFocDate { get; set; }

    /// <summary>
    ///   CreatedByUser
    /// </summary>
    public string CreatedByUser { get; set; }

    /// <summary>
    ///   OrderId
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    ///   Pon
    /// </summary>
    public string Pon { get; set; }

    /// <summary>
    ///   PonVersion
    /// </summary>
    public string PonVersion { get; set; }

    /// <summary>
    ///   RequestedFocDate
    /// </summary>
    public DateTime RequestedFocDate { get; set; }
  }


  internal class LsrOrderApi : ApiBase, ILsrOrder
  {
    public Task<string> CreateAsync(LsrOrder data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/lsrorders", cancellationToken, data);
    }

    public Task<LsrOrder> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<LsrOrder>(HttpMethod.Get, $"/accounts/{Api.AccountId}/lsrorders/{id}",
        cancellationToken);
    }

    public async Task<LsrOrderSummary[]> ListAsync(LsrOrderQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<LsrOrders>(HttpMethod.Get, $"/accounts/{Api.AccountId}/lsrorders",
            cancellationToken, query)).Orders;
    }

    public Task UpdateAsync(string id, LsrOrder data, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Post, $"/accounts/{Api.AccountId}/lsrorders/{id}",
        cancellationToken, null, data);
    }

    public async Task<OrderHistoryItem[]> GetHistoryAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<OrderHistoryWrapper>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/lsrorders/{id}/history",
            cancellationToken)).Items;
    }

    public Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/lsrorders/{id}/notes", cancellationToken, note);
    }

    public async Task<Note[]> GetNotes(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<Notes>(HttpMethod.Get, $"/accounts/{Api.AccountId}/lsrorders/{id}/notes",
            cancellationToken)).List;
    }
  }
}
