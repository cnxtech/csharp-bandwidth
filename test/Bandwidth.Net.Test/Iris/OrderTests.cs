using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class OrderTests
  {
    [Fact]
    public async void TestCreate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.Created);
      response.Headers.Location = new Uri("http://localhost/path/id");
      var context = new MockContext<IHttp>();
     var data = new Order
            {
                Name = "Test",
                SiteId = "10",
                CustomerOrderId = "11",
                LataSearchAndOrderType = new LataSearchAndOrderType
                {
                    Lata = "224",
                    Quantity = 1
                }
            };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var id = await api.CreateAsync(data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
      Assert.Equal("id", id);
    }

    public static bool IsValidCreateRequest(HttpRequestMessage request, Order data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGet()
    {
      var orderResult = new OrderResult
            {
                CompletedQuantity = 1,
                CreatedByUser = "test",
                Order = new Order
                {
                    Name = "Test",
                    SiteId = "10",
                    CustomerOrderId = "11",
                    OrderId = "101",
                    OrderCreateDate = DateTime.Now
                }
            };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(orderResult))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var item = await api.GetAsync("id");
      Assert.Equal("101", item.Order.Id);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id";
    }

    [Fact]
    public async void TestList()
    {
       var orderResult = new OrderResult
            {
                CompletedQuantity = 1,
                CreatedByUser = "test",
                Order = new Order
                {
                    Name = "Test",
                    SiteId = "10",
                    CustomerOrderId = "11",
                    OrderId = "101",
                    OrderCreateDate = DateTime.Now
                }
            };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(new Orders{List =  new[]{orderResult}}))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var items = await api.ListAsync();
      Assert.Equal(1, items.Length);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders";
    }

    [Fact]
    public async void TestUpdate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var context = new MockContext<IHttp>();
      var data = new Order
            {
                Name = "Test",
                SiteId = "10",
                CustomerOrderId = "11",
                LataSearchAndOrderType = new LataSearchAndOrderType
                {
                    Lata = "224",
                    Quantity = 1
                }
            };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      await api.UpdateAsync("id", data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
    }

    public static bool IsValidUpdateRequest(HttpRequestMessage request, Order data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGetHistory()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("OrderHistory")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetHistoryRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var items = await api.GetHistoryAsync("id");
      Assert.True(items.Length > 0);
    }

    public static bool IsValidGetHistoryRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id/history";
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
      var api = Helpers.GetIrisApi(context).Order;
      var id = await api.AddNoteAsync("id", data);
      Assert.Equal("noteId", id);
    }

    public static bool IsValidAddNoteRequest(HttpRequestMessage request, Note data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id/notes"
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
      var api = Helpers.GetIrisApi(context).Order;
      var list = await api.GetNotesAsync("id");
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
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id/notes";
    }

    [Fact]
    public async void TestGetAreaCodes()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("OrderAreaCodes")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetAreaCodesRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var list = await api.GetAreaCodesAsync("id");
      Assert.Equal(1, list.Length);
      Assert.Equal("888", list[0].Code);
    }

    public static bool IsValidGetAreaCodesRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id/areaCodes";
    }

    [Fact]
    public async void TestGetNpaNxx()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("OrderNpaNxx")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetNpaNxxRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var list = await api.GetNpaNxxAsync("id");
      Assert.Equal(1, list.Length);
    }

    public static bool IsValidGetNpaNxxRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id/npaNxx";
    }

    [Fact]
    public async void TestGetTotals()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("OrderTotals")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetTotalsRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var list = await api.GetTotalsAsync("id");
      Assert.Equal(1, list.Length);
    }

    public static bool IsValidGetTotalsRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id/totals";
    }

    [Fact]
    public async void TestGetTns()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("OrderTns")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetTnsRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Order;
      var list = await api.GetTnsAsync("id");
      Assert.Equal(2, list.Length);
    }

    public static bool IsValidGetTnsRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/orders/id/tns";
    }

  }
}
