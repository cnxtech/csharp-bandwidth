using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class SiteTests
  {
    [Fact]
    public async void TestCreate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.Created);
      response.Headers.Location = new Uri("http://localhost/path/id");
      var context = new MockContext<IHttp>();
      var data = new Site
      {
        Name = "Test",

      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Site;
      var id = await api.CreateAsync(data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
      Assert.Equal("id", id);
    }

    public static bool IsValidCreateRequest(HttpRequestMessage request, Site data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGet()
    {
      var site = new Site
      {
        Name = "Test"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(new SiteResponse{Site = site}))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Site;
      var item = await api.GetAsync("id");
      Assert.Equal("Test", item.Name);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/id";
    }

    [Fact]
    public async void TestList()
    {
      var sites = new SitesResponse
      {
        Sites = new[]
        {
          new Site {Name = "Test1"}
        }
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(sites))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Site;
      var items = await api.ListAsync();
      Assert.Equal(1, items.Length);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites";
    }

    [Fact]
    public async void TestUpdate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var context = new MockContext<IHttp>();
      var data = new Site
      {
        Description = "Test site"
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Site;
      await api.UpdateAsync("id", data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
    }

    public static bool IsValidUpdateRequest(HttpRequestMessage request, Site data)
    {
      return request.Method == HttpMethod.Put &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/id"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestDelete()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidDeleteRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Site;
      await api.DeleteAsync("id");
    }

    public static bool IsValidDeleteRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Delete &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/id";
    }

  }
}
