using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to ImportToAccount Api (IRIS)
  /// </summary>
  public interface IImportToAccount
  {

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

  internal class ImportToAccountApi : ApiBase, IImportToAccount
  {
    public Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/importToAccounts/{id}/notes", cancellationToken, note);
    }

    public async Task<Note[]> GetNotes(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<Notes>(HttpMethod.Get, $"/accounts/{Api.AccountId}/importToAccounts/{id}/notes",
            cancellationToken)).List;
    }
  }

}
