using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class SipPeerTests
  {
    [Fact]
    public async void TestCreate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.Created);
      response.Headers.Location = new Uri("http://localhost/path/id");
      var context = new MockContext<IHttp>();
      var data = new SipPeer
      {
        Name = "Test",
        SiteId = "10"
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).SipPeer;
      var id = await api.CreateAsync("10", data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
      Assert.Equal("id", id);
    }

    public static bool IsValidCreateRequest(HttpRequestMessage request, SipPeer data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGet()
    {
      var sippeerResult = new SipPeer
      {
        SiteId = "10",
        PeerId = "101",
        Name = "Name"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(sippeerResult))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).SipPeer;
      var item = await api.GetAsync("10", "101");
      Assert.Equal("101", item.Id);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers/101";
    }

    [Fact]
    public async void TestList()
    {
      var peer = new SipPeer
      {
        SiteId = "10",
        PeerId = "101"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(new SipPeersResponse {SipPeers = new[] {peer}}))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).SipPeer;
      var items = await api.ListAsync("10");
      Assert.Equal(1, items.Length);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers";
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
      var api = Helpers.GetIrisApi(context).SipPeer;
      await api.DeleteAsync("10", "101");
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidDeleteRequest(r)),
          HttpCompletionOption.ResponseContentRead,
          null));
    }

    public static bool IsValidDeleteRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Delete &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers/101";
    }

    [Fact]
    public async void TestGetTns()
    {
      var data = new SipPeerTelephoneNumbersResponse
      {
        SipPeerTelephoneNumbers = new[]
        {
          new SipPeerTelephoneNumber
          {
            FullNumber = "+1234567890"
          }
        }
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(data))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetTnsRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).SipPeer;
      var item = await api.GetTnsAsync("10", "101");
      Assert.Equal(1, item.Length);
    }

    public static bool IsValidGetTnsRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers/101/tns";
    }

    [Fact]
    public async void TestGetTn()
    {
      var data = new SipPeerTelephoneNumberResponse
      {
        SipPeerTelephoneNumber =
          new SipPeerTelephoneNumber
          {
            FullNumber = "+1234567890"
          }
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(data))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetTnRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).SipPeer;
      var item = await api.GetTnAsync("10", "101", "123");
      Assert.Equal("+1234567890", item.FullNumber);
    }

    public static bool IsValidGetTnRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers/101/tns/123";
    }

    [Fact]
    public async void TestUpdateTn()
    {
      var data = new SipPeerTelephoneNumber {FullNumber = "+1234567890"};
      var response = new HttpResponseMessage();
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateTnRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).SipPeer;
      await api.UpdateTnAsync("10", "101", "123", data);
    }

    public static bool IsValidUpdateTnRequest(HttpRequestMessage request, SipPeerTelephoneNumber data)
    {
      return request.Method == HttpMethod.Put
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers/101/tns/123"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestMoveTns()
    {
      var data = new[] {"+1234567890", "+1234567891"};
      var response = new HttpResponseMessage();
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidMoveTnsRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).SipPeer;
      await api.MoveTnsAsync("10", "101", data);
    }

    public static bool IsValidMoveTnsRequest(HttpRequestMessage request, string[] data)
    {
      return request.Method == HttpMethod.Post
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/sites/10/sippeers/101/movetns"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             &&
             request.Content.ReadAsStringAsync().Result ==
             Helpers.ToXmlString(new SipPeerTelephoneNumbers {Numbers = data});
    }
  }
}
