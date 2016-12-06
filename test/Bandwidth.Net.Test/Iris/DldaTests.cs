using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class DldaTests
  {
    [Fact]
    public async void TestCreate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.Created);
      response.Headers.Location = new Uri("http://localhost/path/id");
      var context = new MockContext<IHttp>();
      var data = new Dlda
      {
          DldaTnGroups = new []
          {
            new DldaTnGroup
            {
              TelephoneNumbers = new TelephoneNumbers{Numbers = new []{"+1234567890"}}
            }
          }
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Dlda;
      var id = await api.CreateAsync(data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)), HttpCompletionOption.ResponseContentRead,
          null));
      Assert.Equal("id", id);
    }

    public static bool IsValidCreateRequest(HttpRequestMessage request, Dlda data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/dldas"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGet()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("Dlda")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Dlda;
      var item = await api.GetAsync("id");
      Assert.Equal("ea9e90c2-77a4-4f82-ac47-e1c5bb1311f4", item.Id);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/dldas/id";
    }

    [Fact]
    public async void TestList()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("DldaList")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Dlda;
      var items = await api.ListAsync();
      Assert.Equal(3, items.Length);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/dldas";
    }

    [Fact]
    public async void TestUpdate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var context = new MockContext<IHttp>();
      var data = new Dlda
      {
          DldaTnGroups = new []
          {
            new DldaTnGroup
            {
              TelephoneNumbers = new TelephoneNumbers{Numbers = new []{"+1234567890"}}
            }
          }
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Dlda;
      await api.UpdateAsync("id", data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)), HttpCompletionOption.ResponseContentRead,
          null));
    }

    public static bool IsValidUpdateRequest(HttpRequestMessage request, Dlda data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/dldas/id"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGetHistory()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("DldaHistory")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetHistoryRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Dlda;
      var items = await api.GetHistoryAsync("id");
      Assert.True(items.Length > 0);
    }

    public static bool IsValidGetHistoryRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/dldas/id/history";
    }
 }
}
