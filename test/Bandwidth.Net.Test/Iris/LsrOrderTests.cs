using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class LsrOrderTests
  {
    [Fact]
    public async void TestCreate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.Created);
      response.Headers.Location = new Uri("http://localhost/path/id");
      var context = new MockContext<IHttp>();
      var data = new LsrOrder
      {
        Pon = "Some Pon",
        CustomerOrderId = "MyId5",
        Spid = "123C",
        BillingTelephoneNumber = "9192381468",
        AuthorizingPerson = "Jim Hopkins",
        Subscriber = new Subscriber
        {
          SubscriberType = "BUSINESS",
          BusinessName = "BusinessName",
          ServiceAddress = new Address
          {
            HouseNumber = "11",
            StreetName = "Park",
            StreetSuffix = "Ave",
            City = "New York",
            StateCode = "NY",
            Zip = "90025"
          },
          AccountNumber = "123463",
          PinNumber = "1231"
        },
        ListOfTelephoneNumbers = new[] {"9192381848", "9192381467"}
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).LsrOrder;
      var id = await api.CreateAsync(data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
      Assert.Equal("id", id);
    }

    public static bool IsValidCreateRequest(HttpRequestMessage request, LsrOrder data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lsrorders"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGet()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("LsrOrder")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).LsrOrder;
      var item = await api.GetAsync("id");
      Assert.Equal("00cf7e08-cab0-4515-9a77-2d0a7da09415", item.Id);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lsrorders/id";
    }

    [Fact]
    public async void TestList()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("LsrOrderList")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).LsrOrder;
      var items = await api.ListAsync();
      Assert.Equal(2, items.Length);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lsrorders";
    }

    [Fact]
    public async void TestUpdate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var context = new MockContext<IHttp>();
      var data = new LsrOrder
      {
        BillingTelephoneNumber = "12345"
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).LsrOrder;
      await api.UpdateAsync("id", data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
    }

    public static bool IsValidUpdateRequest(HttpRequestMessage request, LsrOrder data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lsrorders/id"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGetHistory()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("LsrOrderHistory")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetHistoryRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).LsrOrder;
      var items = await api.GetHistoryAsync("id");
      Assert.True(items.Length > 0);
    }

    public static bool IsValidGetHistoryRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lsrorders/id/history";
    }

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
      var api = Helpers.GetIrisApi(context).LsrOrder;
      var id = await api.AddNoteAsync("id", data);
      Assert.Equal("noteId", id);
    }

    public static bool IsValidAddNoteRequest(HttpRequestMessage request, Note data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lsrorders/id/notes"
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
      var api = Helpers.GetIrisApi(context).LsrOrder;
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
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lsrorders/id/notes";
    }

  }
}
