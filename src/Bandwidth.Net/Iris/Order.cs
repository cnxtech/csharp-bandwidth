using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Order Api (IRIS)
  /// </summary>
  public interface IOrder
  {
    /// <summary>
    ///   Create an order
    /// </summary>
    /// <param name="data">data of new Order order</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created Order</returns>
    /// <example>
    /// <code>
    /// var id = await client.Order.CreateAsync(new Order{Name = "order"}});
    /// </code>
    /// </example>
    Task<string> CreateAsync(Order data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get an order
    /// </summary>
    /// <param name="id">Order Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Order data</returns>
    /// <example>
    /// <code>
    /// var order = await client.Order.GetAsync("id");
    /// </code>
    /// </example>
    Task<OrderResult> GetAsync(string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List orders
    /// </summary>
    /// <returns>Array of orders data</returns>
    /// <example>
    /// <code>
    /// var list = await client.Order.ListAsync();
    /// </code>
    /// </example>
    Task<OrderResult[]> ListAsync(OrderQuery query = null, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Update a Order
    /// </summary>
    /// <param name="id">Order Id</param>
    /// <param name="data">data to change</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <example>
    /// <code>
    /// await client.Order.UpdateAsync("id", new Order{Name= "my order"});
    /// </code>
    /// </example>
    Task UpdateAsync(string id, Order data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return orders history
    /// </summary>
    /// <param name="id">Order Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of orders</returns>
    /// <example>
    /// <code>
    /// var list = await client.Order.GetHistoryAsync("orderId");
    /// </code>
    /// </example>
    Task<OrderHistoryItem[]> GetHistoryAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Add note to the order
    /// </summary>
    /// <param name="id">Order Id</param>
    /// <param name="note">Note data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created note</returns>
    /// <example>
    /// <code>
    /// var id = await client.Order.AddNoteAsync("orderId", new Note {Description = "description"});
    /// </code>
    /// </example>
    Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return list of notes of the order
    /// </summary>
    /// <param name="id">Order id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of notes</returns>
    /// <example>
    /// <code>
    /// var list = await client.Order.GetNotesAsync("orderId");
    /// </code>
    /// </example>
    Task<Note[]> GetNotesAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get area codes of an order
    /// </summary>
    /// <param name="id">Order id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Area codes data</returns>
    /// <example>
    /// <code>
    /// var codes = await client.Order.GetAreaCodesAsync("orderId");
    /// </code>
    /// </example>
    Task<AreaCode[]> GetAreaCodesAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get Npa-Nxx of the phone numbers of an order
    /// </summary>
    /// <param name="id">Order id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Npa-Nxx data</returns>
    /// <example>
    /// <code>
    /// var list = await client.Order.GetNpaNxxAsync("orderId");
    /// </code>
    /// </example>
    Task<NpaNxx[]> GetNpaNxxAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Retrieves the total quantity of phone numbers from the specified order.
    /// </summary>
    /// <param name="id">Order id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Totals data</returns>
    /// <example>
    /// <code>
    /// var totals = await client.Order.GetTotalsAsync("orderId");
    /// </code>
    /// </example>
    Task<object[]> GetTotalsAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get telephone numbers of an order
    /// </summary>
    /// <param name="id">Order id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Phone nnumbers data</returns>
    /// <example>
    /// <code>
    /// var numbers = await client.Order.GetTnsAsync("orderId");
    /// </code>
    /// </example>
    Task<string[]> GetTnsAsync(string id, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  ///   Query parameters to get orders
  /// </summary>
  public class OrderQuery
  {
    /// <summary>
    ///   Enddate
    /// </summary>
    public DateTime? Enddate { get; set; }

    /// <summary>
    ///   Startdate
    /// </summary>
    public DateTime? Startdate { get; set; }

    /// <summary>
    ///   CustomerOrderId
    /// </summary>
    public string CustomerOrderId { get; set; }

    /// <summary>
    ///   Page
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    ///   Size
    /// </summary>
    public int? Size { get; set; }

    /// <summary>
    ///   Status
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    ///   UserId
    /// </summary>
    public string UserId { get; set; }
  }

  /// <summary>
  ///   Order
  /// </summary>
  public class Order
  {
    /// <summary>
    ///   Id
    /// </summary>
    public string Id => OrderId;

    /// <summary>
    ///   OrderId
    /// </summary>
    [XmlElement("id")]
    public string OrderId { get; set; }

    /// <summary>
    ///   Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   SiteId
    /// </summary>
    public string SiteId { get; set; }

    /// <summary>
    ///   BackOrderRequested
    /// </summary>
    [DefaultValue(false)]
    public bool BackOrderRequested { get; set; }

    /// <summary>
    ///   OrderCreateDate
    /// </summary>
    [DefaultDateTime]
    public DateTime OrderCreateDate { get; set; }

    /// <summary>
    ///   CustomerOrderId
    /// </summary>
    public string CustomerOrderId { get; set; }

    /// <summary>
    ///   PartialAllowed
    /// </summary>
    [DefaultValue(true)]
    public bool PartialAllowed { get; set; }

    /// <summary>
    ///   CloseOrder
    /// </summary>
    [DefaultValue(false)]
    public bool CloseOrder { get; set; }

    /// <summary>
    ///   ExistingTelephoneNumberOrderType
    /// </summary>
    public ExistingTelephoneNumberOrderType ExistingTelephoneNumberOrderType { get; set; }

    /// <summary>
    ///   AreaCodeSearchAndOrderType
    /// </summary>
    public AreaCodeSearchAndOrderType AreaCodeSearchAndOrderType { get; set; }

    /// <summary>
    ///   RateCenterSearchAndOrderType
    /// </summary>
    public RateCenterSearchAndOrderType RateCenterSearchAndOrderType { get; set; }

    /// <summary>
    ///   NpaNxxSearchAndOrderType
    /// </summary>
    [XmlElement("NPANXXSearchAndOrderType")]
    public NpaNxxSearchAndOrderType NpaNxxSearchAndOrderType { get; set; }

    /// <summary>
    ///   TollFreeVanitySearchAndOrderType
    /// </summary>
    public TollFreeVanitySearchAndOrderType TollFreeVanitySearchAndOrderType { get; set; }

    /// <summary>
    ///   TollFreeWildCharSearchAndOrderType
    /// </summary>
    public TollFreeWildCharSearchAndOrderType TollFreeWildCharSearchAndOrderType { get; set; }

    /// <summary>
    ///   StateSearchAndOrderType
    /// </summary>
    public StateSearchAndOrderType StateSearchAndOrderType { get; set; }

    /// <summary>
    ///   CitySearchAndOrderType
    /// </summary>
    public CitySearchAndOrderType CitySearchAndOrderType { get; set; }

    /// <summary>
    ///   ZipSearchAndOrderType
    /// </summary>
    [XmlElement("ZIPSearchAndOrderType")]
    public ZipSearchAndOrderType ZipSearchAndOrderType { get; set; }

    /// <summary>
    ///   LataSearchAndOrderType
    /// </summary>
    [XmlElement("LATASearchAndOrderType")]
    public LataSearchAndOrderType LataSearchAndOrderType { get; set; }
  }

  /// <summary>
  ///   LataSearchAndOrderType
  /// </summary>
  public class LataSearchAndOrderType
  {
    /// <summary>
    ///   Lata
    /// </summary>
    public string Lata { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   ZipSearchAndOrderType
  /// </summary>
  public class ZipSearchAndOrderType
  {
    /// <summary>
    ///   Zip
    /// </summary>
    public string Zip { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   CitySearchAndOrderType
  /// </summary>
  public class CitySearchAndOrderType
  {
    /// <summary>
    ///   City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///   State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   StateSearchAndOrderType
  /// </summary>
  public class StateSearchAndOrderType
  {
    /// <summary>
    ///   State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   TollFreeWildCharSearchAndOrderType
  /// </summary>
  public class TollFreeWildCharSearchAndOrderType
  {
    /// <summary>
    ///   TollFreeWildCardPattern
    /// </summary>
    public string TollFreeWildCardPattern { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   TollFreeVanitySearchAndOrderType
  /// </summary>
  public class TollFreeVanitySearchAndOrderType
  {
    /// <summary>
    ///   TollFreeVanity
    /// </summary>
    public string TollFreeVanity { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   NpaNxxSearchAndOrderType
  /// </summary>
  public class NpaNxxSearchAndOrderType
  {
    /// <summary>
    ///   NpaNxx
    /// </summary>
    public string NpaNxx { get; set; }

    /// <summary>
    ///   EnableTnDetail
    /// </summary>
    [XmlElement("EnableTNDetail")]
    public bool EnableTnDetail { get; set; }


    /// <summary>
    ///   EnableLca
    /// </summary>
    [XmlElement("EnableLCA")]
    public bool EnableLca { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   RateCenterSearchAndOrderType
  /// </summary>
  public class RateCenterSearchAndOrderType
  {
    /// <summary>
    ///   AreaCode
    /// </summary>
    public string AreaCode { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   AreaCodeSearchAndOrderType
  /// </summary>
  public class AreaCodeSearchAndOrderType
  {
    /// <summary>
    ///   RateCenter
    /// </summary>
    public string RateCenter { get; set; }

    /// <summary>
    ///   State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    ///   Quantity
    /// </summary>
    public int Quantity { get; set; }
  }

  /// <summary>
  ///   ExistingTelephoneNumberOrderType
  /// </summary>
  public class ExistingTelephoneNumberOrderType
  {
    /// <summary>
    ///   TelephoneNumberList
    /// </summary>
    [XmlArrayItem("TelephoneNumber")]
    public string[] TelephoneNumberList { get; set; }


    /// <summary>
    ///   ReservationIdList
    /// </summary>
    [XmlArrayItem("ReservationId")]
    public string[] ReservationIdList { get; set; }
  }

  /// <summary>
  ///   OrderResult
  /// </summary>
  [XmlType("OrderResponse")]
  public class OrderResult
  {
    /// <summary>
    ///   Order
    /// </summary>
    public Order Order { get; set; }

    /// <summary>
    ///   CreatedByUser
    /// </summary>
    public string CreatedByUser { get; set; }

    /// <summary>
    ///   CompletedQuantity
    /// </summary>
    public int CompletedQuantity { get; set; }

    /// <summary>
    ///   FailedQuantity
    /// </summary>
    public int FailedQuantity { get; set; }

    /// <summary>
    ///   PendingQuantity
    /// </summary>
    public int PendingQuantity { get; set; }

    /// <summary>
    ///   OrderCompleteDate
    /// </summary>
    public DateTime OrderCompleteDate { get; set; }

    /// <summary>
    ///   OrderStatus
    /// </summary>
    public string OrderStatus { get; set; }

    /// <summary>
    ///   CompletedNumbers
    /// </summary>
    public TelephoneNumber[] CompletedNumbers { get; set; }
  }

  /// <summary>
  ///   TelephoneNumber
  /// </summary>
  public class TelephoneNumber
  {
    /// <summary>
    ///   FullNumber
    /// </summary>
    public string FullNumber { get; set; }
  }

  /// <summary>
  ///   Orders
  /// </summary>
  public class Orders
  {
    /// <summary>
    ///   List
    /// </summary>
    [XmlElement("Order")]
    public OrderResult[] List { get; set; }
  }

  /// <summary>
  ///   TelephoneDetailsReportsWithAreaCodes
  /// </summary>
  [XmlRoot("TelephoneDetailsReports")]
  public class TelephoneDetailsReportsWithAreaCodes
  {
    /// <summary>
    ///   Codes
    /// </summary>
    [XmlElement("TelephoneDetailsReport")]
    public AreaCode[] Codes { get; set; }
  }

  /// <summary>
  ///   AreaCode
  /// </summary>
  public class AreaCode
  {
    /// <summary>
    ///   Code
    /// </summary>
    [XmlElement("AreaCode")]
    public string Code { get; set; }

    /// <summary>
    ///   Count
    /// </summary>
    public int Count { get; set; }
  }

  /// <summary>
  ///   TelephoneDetailsReportsWithNpaNxx
  /// </summary>
  [XmlRoot("TelephoneDetailsReports")]
  public class TelephoneDetailsReportsWithNpaNxx
  {
    /// <summary>
    ///   TelephoneDetailsReport
    /// </summary>
    [XmlElement("TelephoneDetailsReport")]
    public NpaNxx[] List { get; set; }
  }

  /// <summary>
  ///   NpaNxx
  /// </summary>
  public class NpaNxx
  {
    /// <summary>
    ///   Value
    /// </summary>
    [XmlElement("NPA-NXX")]
    public string Value { get; set; }

    /// <summary>
    ///   Count
    /// </summary>
    public int Count { get; set; }
  }

  /// <summary>
  ///   TelephoneDetailsReportsWithTotals
  /// </summary>
  [XmlRoot("TelephoneDetailsReports")]
  public class TelephoneDetailsReportsWithTotals
  {
    /// <summary>
    ///   TelephoneDetailsReport
    /// </summary>
    [XmlElement("TelephoneDetailsReport")]
    public object[] List { get; set; }
  }


  internal class OrderApi : ApiBase, IOrder
  {
    public Task<string> CreateAsync(Order data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/orders", cancellationToken, data);
    }

    public Task<OrderResult> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<OrderResult>(HttpMethod.Get, $"/accounts/{Api.AccountId}/orders/{id}",
        cancellationToken);
    }

    public async Task<OrderResult[]> ListAsync(OrderQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<Orders>(HttpMethod.Get, $"/accounts/{Api.AccountId}/orders",
            cancellationToken, query)).List;
    }

    public Task UpdateAsync(string id, Order data, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Post, $"/accounts/{Api.AccountId}/orders/{id}",
        cancellationToken, null, data);
    }

    public async Task<OrderHistoryItem[]> GetHistoryAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<OrderHistoryWrapper>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/orders/{id}/history",
            cancellationToken)).Items;
    }

    public Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/orders/{id}/notes", cancellationToken, note);
    }

    public async Task<Note[]> GetNotesAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<Notes>(HttpMethod.Get, $"/accounts/{Api.AccountId}/orders/{id}/notes",
            cancellationToken)).List;
    }


    public async Task<AreaCode[]> GetAreaCodesAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<TelephoneDetailsReportsWithAreaCodes>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/orders/{id}/areaCodes",
            cancellationToken)).Codes;
    }

    public async Task<NpaNxx[]> GetNpaNxxAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<TelephoneDetailsReportsWithNpaNxx>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/orders/{id}/npaNxx",
            cancellationToken)).List;
    }

    public async Task<object[]> GetTotalsAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<TelephoneDetailsReportsWithTotals>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/orders/{id}/totals",
            cancellationToken)).List;
    }

    public async Task<string[]> GetTnsAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<TelephoneNumbers>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/orders/{id}/tns",
            cancellationToken)).Numbers;
    }

  }
}
