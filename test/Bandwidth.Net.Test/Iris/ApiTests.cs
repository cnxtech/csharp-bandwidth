using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using Bandwidth.Net.Test.Mocks;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class ApiTests
  {
    [Fact]
    public void TestConstructor()
    {
      var api = new IrisApi(new IrisAuthData {AccountId = "accountId", UserName = "userName", Password = "password"});
      Assert.Equal("accountId", api.AccountId);
      Assert.Equal(Convert.ToBase64String(Encoding.UTF8.GetBytes("userName:password")), api.AuthenticationHeader.Parameter);
    }

    [Fact]
    public async void TestConstructor2()
    {
      var context = new MockContext<IHttp>();
      var request = new HttpRequestMessage(HttpMethod.Get, "/test");
      context.Arrange(m => m.SendAsync(request, HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      var api = new IrisApi(new IrisAuthData { AccountId = "accountId", UserName = "userName", Password = "password" }, new Http(context));
      Assert.Equal("accountId", api.AccountId);
      using (var response = await api.MakeXmlRequestAsync(request))
      {
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      }
      Assert.Equal("accountId", api.AccountId);
    }

    [Fact]
    public void TestConstructorFails()
    {
      Assert.Throws<ArgumentNullException>(() => new IrisApi(null));
      Assert.Throws<MissingCredentialsException>(() => new IrisApi(new IrisAuthData()));
      Assert.Throws<InvalidBaseUrlException>(
        () =>
          new IrisApi(new IrisAuthData
          {
            AccountId = "accountId",
            UserName = "userName",
            Password = "password",
            BaseUrl = null
          }));
      Assert.Throws<ArgumentNullException>(
        () => new IrisApi(new IrisAuthData { AccountId = "accountId", UserName = "userName", Password = "password" }, null));
    }

    [Fact]
    public async void TestMakeXmlRequestReq()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetIrisApi(context);
      var request = new HttpRequestMessage(HttpMethod.Get, "/test");
      context.Arrange(m => m.SendAsync(request, HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      using (var response =
        await api.MakeXmlRequestAsync(request))
      {
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      }
    }

    [Fact]
    public async void TestMakeXmlTRequest()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetIrisApi(context);
      context.Arrange(
        m => m.SendAsync(The<HttpRequestMessage>.IsAnyValue, HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
          Content = new StringContent("<MakeXmlRequestDemo><Test>value</Test></MakeXmlRequestDemo>", Encoding.UTF8, "application/xml")
        }));
      var result = await api.MakeXmlRequestAsync<MakeXmlRequestDemo>(HttpMethod.Get, "/test");
      Assert.Equal("value", result.Test);
    }

    [Fact]
    public async void TestMakeXmlRequest()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetIrisApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidRequestWithoutBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      using (var response = await api.MakeXmlRequestAsync(HttpMethod.Get, "/test"))
      {
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      }
    }

    [Fact]
    public async void TestMakeXmlWithoutRequestRequest()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetIrisApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidRequestWithoutBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      await api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Get, "/test");

    }

    [Fact]
    public async void TestMakeXmlRequestWithBody()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetIrisApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidXmlRequestWithBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      var response = await api.MakeXmlRequestAsync(HttpMethod.Post, "/test", null, null, new MakeXmlRequestDemo { Test = "value" });
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void TestMakePostXmlRequest()
    {
      var context = new MockContext<IHttp>();
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      response.Headers.Location = new Uri("http://host/path/id");
      var api = Helpers.GetIrisApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidXmlRequestWithBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(response));
      var id = await api.MakePostXmlRequestAsync("/test", null, new MakeXmlRequestDemo { Test = "value" });
      Assert.Equal("id", id);
    }

    [Fact]
    public async void TestMakePostXmlRequestWithoutLocationHeader()
    {
      var context = new MockContext<IHttp>();
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var api = Helpers.GetIrisApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidXmlRequestWithBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(response));
      var id = await api.MakePostXmlRequestAsync("/test", null, new MakeXmlRequestDemo { Test = "value" });
      Assert.True(string.IsNullOrEmpty(id));
    }


    public static bool IsValidRequestWithBody(HttpRequestMessage request)
    {
      return request.Content.Headers.ContentType.MediaType == "application/json"
             && request.Content.ReadAsStringAsync().Result == "{\"field\":\"value\"}";
    }

    public static bool IsValidXmlRequestWithBody(HttpRequestMessage request)
    {
      return request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result.Contains("<Test>value</Test>");
    }

    public static bool IsValidRequestWithoutBody(HttpRequestMessage request)
    {
      return request.Content == null;
    }

  }

  public class MakeXmlRequestDemo
  {
    public string Test { get; set; }
  }
}
