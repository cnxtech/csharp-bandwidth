using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class ImportToAccountsTests
  {
    [Fact]
    public async void TestAddNote()
    {
      var data = new Note
      {
        Description = "test"
      };
      var response = new HttpResponseMessage(HttpStatusCode.Created);
      response.Headers.Location = new Uri("http://localhost/path/noteId");
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidAddNoteRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).ImportToAccount;
      var id = await api.AddNoteAsync("id", data);
      Assert.Equal("noteId", id);
    }

    public static bool IsValidAddNoteRequest(HttpRequestMessage request, Note data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/importToAccounts/id/notes"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGetNotes()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("Notes")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetNotesRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).ImportToAccount;
      var list = await api.GetNotes("id");
      Assert.Equal(2, list.Length);
      Assert.Equal("11299", list[0].Id);
      Assert.Equal("customer", list[0].UserId);
      Assert.Equal("Test", list[0].Description);
      Assert.Equal("11301", list[1].Id);
      Assert.Equal("customer", list[1].UserId);
      Assert.Equal("Test1", list[1].Description);
    }

    public static bool IsValidGetNotesRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/importToAccounts/id/notes";
    }
  }
}
