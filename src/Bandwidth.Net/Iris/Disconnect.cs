using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Disconnect Api (IRIS)
  /// </summary>
  public interface IDisconnect
  {
    /// <summary>
    ///   Create an order
    /// </summary>
    /// <param name="orderName">Order Name</param>
    /// <param name="numbers">Numbers to order</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    Task CreateAsync(string orderName, string[] numbers, CancellationToken? cancellationToken = null);

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

  internal class DisconnectApi : ApiBase, IDisconnect
  {
    public Task CreateAsync(string orderName, string[] numbers, CancellationToken? cancellationToken = null)
    {
      var order = new DisconnectTelephoneNumberOrder
      {
        Name = orderName,
        DisconnectTelephoneNumberOrderType = new DisconnectTelephoneNumberOrderType
        {
          TelephoneNumbers = numbers
        }
      };
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Post,
        $"/accounts/{Api.AccountId}/disconnects", cancellationToken, null, order);
    }

    public Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/disconnects/{id}/notes", cancellationToken, note);
    }

    public async Task<Note[]> GetNotes(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<Notes>(HttpMethod.Get, $"/accounts/{Api.AccountId}/disconnects/{id}/notes",
            cancellationToken)).List;
    }
  }

  /// <summary>
  /// DisconnectTelephoneNumberOrder
  /// </summary>
  public class DisconnectTelephoneNumberOrder
  {
    /// <summary>
    /// Name
    /// </summary>
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    /// DisconnectTelephoneNumberOrderType
    /// </summary>
    public DisconnectTelephoneNumberOrderType DisconnectTelephoneNumberOrderType { get; set; }
  }

  /// <summary>
  /// DisconnectTelephoneNumberOrderType
  /// </summary>
  public class DisconnectTelephoneNumberOrderType
  {
    /// <summary>
    /// TelephoneNumbers
    /// </summary>
    [XmlElement("TelephoneNumber")]
    public string[] TelephoneNumbers { get; set; }
  }

  /// <summary>
  /// Note
  /// </summary>
  public class Note
  {
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// LastDateModifier
    /// </summary>
    [DefaultDateTime]
    public DateTime LastDateModifier { get; set; }

    /// <summary>
    /// UserId
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }
  }

  /// <summary>
  /// Notes
  /// </summary>
  public class Notes
  {
    /// <summary>
    /// List
    /// </summary>
    [XmlElement("Note")]
    public Note[] List { get; set; }
  }
}
