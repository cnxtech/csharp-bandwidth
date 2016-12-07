using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Lidb Api (IRIS)
  /// </summary>
  public interface ILidb
  {
    /// <summary>
    ///   Create an Lidb order
    /// </summary>
    /// <param name="data">data of new order</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created Dlda</returns>
    Task<string> CreateAsync(Lidb data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get a Lidb order
    /// </summary>
    /// <param name="id">Lidb Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Lidb data</returns>
    Task<Lidb> GetAsync(string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   List orders
    /// </summary>
    /// <returns>Array of orders data</returns>
    Task<OrderIdUserIdDate[]> ListAsync(LidbQuery query = null, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  ///   Query parameters for Lidb
  /// </summary>
  public class LidbQuery
  {
    /// <summary>
    ///   LastModifiedAfter
    /// </summary>
    public DateTime? LastModifiedAfter { get; set; }

    /// <summary>
    ///   ModifiedDateFrom
    /// </summary>
    public DateTime? ModifiedDateFrom { get; set; }

    /// <summary>
    ///   ModifiedDateTo
    /// </summary>
    public DateTime? ModifiedDateTo { get; set; }

    /// <summary>
    ///   Tn
    /// </summary>
    public string Tn { get; set; }
  }

  /// <summary>
  ///   Lidb
  /// </summary>
  [XmlRoot("LidbOrder")]
  public class Lidb
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
    /// OrderId
    /// </summary>
    [XmlElement("orderId")]
    public string OrderId { get; set; }

    /// <summary>
    /// OrderCreateDate
    /// </summary>
    public DateTime OrderCreateDate { get; set; }

    /// <summary>
    /// ProcessingStatus
    /// </summary>
    public string ProcessingStatus { get; set; }

    /// <summary>
    /// CreatedByUser
    /// </summary>
    public string CreatedByUser { get; set; }

    /// <summary>
    /// LastModifiedDate
    /// </summary>
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// OrderCompleteDate
    /// </summary>
    public DateTime OrderCompleteDate { get; set; }

    /// <summary>
    /// LidbTnGroups
    /// </summary>
    public LidbTnGroup[] LidbTnGroups { get; set; }
  }

  /// <summary>
  /// LidbTnGroup
  /// </summary>
  public class LidbTnGroup
  {
    /// <summary>
    /// TelephoneNumbers
    /// </summary>
    [XmlArrayItem("TelephoneNumber")]
    public string[] TelephoneNumbers { get; set; }

    /// <summary>
    /// FullNumber
    /// </summary>
    public string FullNumber { get; set; }

    /// <summary>
    /// SubscriberInformation
    /// </summary>
    public string SubscriberInformation { get; set; }

    /// <summary>
    /// UseType
    /// </summary>
    public string UseType { get; set; }

    /// <summary>
    /// Visibility
    /// </summary>
    public string Visibility { get; set; }
  }

  internal class LidbApi : ApiBase, ILidb
  {
    public Task<string> CreateAsync(Lidb data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/lidbs", cancellationToken, data);
    }

    public Task<Lidb> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<Lidb>(HttpMethod.Get, $"/accounts/{Api.AccountId}/lidbs/{id}", cancellationToken);
    }

    public async Task<OrderIdUserIdDate[]> ListAsync(LidbQuery query = null, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<ResponseSelectWrapper>(HttpMethod.Get, $"/accounts/{Api.AccountId}/lidbs",
            cancellationToken, query)).ListOrderIdUserIdDate;
    }
  }
}
