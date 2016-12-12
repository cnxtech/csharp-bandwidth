using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class TnTests
  {

    [Fact]
    public async void TestGet()
    {
      var tn = new Tn
      {
         OrderId = "111"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(tn))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Tn;
      var item = await api.GetAsync("123");
      Assert.Equal("111", item.OrderId);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/tns/123";
    }

    [Fact]
    public async void TestList()
    {
      var numbers = new TelephoneNumbersResponse
      {
        TelephoneNumbers = new []
        {
          new TelephoneNumber{FullNumber = "123456"} 
        }
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(numbers))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Tn;
      var items = await api.ListAsync();
      Assert.Equal(1, items.TelephoneNumbers.Length);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/tns";
    }

    [Fact]
    public async void TestGetDetails()
    {
      var details = new TelephoneNumberDetails
      {
        FullNumber = "123456"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(details))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetDetailsRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Tn;
      var data = await api.GetDetailsAsync("123456");
      Assert.Equal("123456", data.FullNumber);
    }

    public static bool IsValidGetDetailsRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/tns/123456/tndetails";
    }

    [Fact]
    public async void TestGetSipPeers()
    {
      var details = new TelephoneNumberSipPeer
      {
        Name = "SIP"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(details))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetSipPeersRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Tn;
      var data = await api.GetSipPeersAsync("123456");
      Assert.Equal("SIP", data.Name);
    }

    public static bool IsValidGetSipPeersRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/tns/123456/sippeers";
    }

    [Fact]
    public async void TestGetSites()
    {
      var details = new TelephoneNumberSite
      {
        Name = "Site"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(details))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetSitesRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Tn;
      var data = await api.GetSitesAsync("123456");
      Assert.Equal("Site", data.Name);
    }

    public static bool IsValidGetSitesRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/tns/123456/sites";
    }

    [Fact]
    public async void TestGetLata()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("TnLata")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetLataRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Tn;
      var lata = await api.GetLataAsync("123456");
      Assert.Equal("656", lata);
    }

    public static bool IsValidGetLataRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/tns/123456/lata";
    }

    [Fact]
    public async void TestGetRateCenter()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("TnRateCenter")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRateCenterRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Tn;
      var result = await api.GetRateCenter("123456");
      Assert.Equal("CO", result.State);
      Assert.Equal("DENVER", result.RateCenter);
    }

    public static bool IsValidGetRateCenterRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/tns/123456/ratecenter";
    }

  }
}
