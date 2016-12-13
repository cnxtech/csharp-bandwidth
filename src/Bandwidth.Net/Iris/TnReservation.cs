using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to TnReservation Api (IRIS)
  /// </summary>
  public interface ITnReservation
  {
    /// <summary>
    ///   Create a tnreservation
    /// </summary>
    /// <param name="data">data of new tnreservation</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created tnreservation</returns>
    /// <example>
    /// <code>
    /// var id = await client.TnReservation.CreateAsync(new TnReservation{ReservedTn = "1234567980"}});
    /// </code>
    /// </example>
    Task<string> CreateAsync(TnReservation data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Get a  tnreservation data
    /// </summary>
    /// <param name="id">TnReservation Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>TnReservation data</returns>
    /// <example>
    /// <code>
    /// var reservation = await client.TnReservation.GetAsync("id");
    /// </code>
    /// </example>
    Task<TnReservation> GetAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Remove a tnreservation
    /// </summary>
    /// <param name="id">TnReservation Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <example>
    /// <code>
    /// await client.TnReservation.DeleteAsync("id");
    /// </code>
    /// </example>
    Task DeleteAsync(string id, CancellationToken? cancellationToken = null);
  }


  /// <summary>
  ///   TnReservation
  /// </summary>
  public class TnReservation
  {
    /// <summary>
    ///   Id
    /// </summary>
    public string Id => ReservationId;

    /// <summary>
    ///   ReservationId
    /// </summary>
    public string ReservationId { get; set; }

    /// <summary>
    ///   AccountId
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    ///   ReservationExpires
    /// </summary>
    public int ReservationExpires { get; set; }

    /// <summary>
    ///   ReservedTn
    /// </summary>
    public string ReservedTn { get; set; }
  }

  /// <summary>
  ///   ReservationResponse
  /// </summary>
  public class ReservationResponse
  {
    /// <summary>
    ///   Reservation
    /// </summary>
    public TnReservation Reservation { get; set; }
  }

  internal class TnReservationApi : ApiBase, ITnReservation
  {
    public Task<string> CreateAsync(TnReservation data, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/tnreservation", cancellationToken, data);
    }

    public async Task<TnReservation> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<ReservationResponse>(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/tnreservation/{id}",
            cancellationToken)).Reservation;
    }


    public Task DeleteAsync(string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Delete,
        $"/accounts/{Api.AccountId}/tnreservation/{id}", cancellationToken);
    }
  }
}
