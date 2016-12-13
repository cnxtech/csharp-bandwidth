using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Portout Api (IRIS)
  /// </summary>
  public interface IPortout
  {
    /// <summary>
    ///   Add note to the order
    /// </summary>
    /// <param name="id">Portout Id</param>
    /// <param name="note">Note data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created note</returns>
    /// <example>
    /// <code>
    /// var id = await client.Portout.AddNoteAsync("orderId", new Note {Description = "description"});
    /// </code>
    /// </example>
    Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return list of notes of the order
    /// </summary>
    /// <param name="id">Portout id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of notes</returns>
    /// <example>
    /// <code>
    /// var list = await client.Portout.GetNotesAsync("orderId");
    /// </code>
    /// </example>
    Task<Note[]> GetNotesAsync(string id, CancellationToken? cancellationToken = null);
  }

  internal class PortoutApi : ApiBase, IPortout
  {
    public Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/portouts/{id}/notes", cancellationToken, note);
    }

    public async Task<Note[]> GetNotesAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<Notes>(HttpMethod.Get, $"/accounts/{Api.AccountId}/portouts/{id}/notes",
            cancellationToken)).List;
    }
  }
}
