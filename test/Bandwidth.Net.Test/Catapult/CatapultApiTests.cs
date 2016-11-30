using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bandwidth.Net.Catapult;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Catapult
{
  public class CatapultApiTests
  {
    [Fact]
    public void TestConstructor()
    {
      var api = new CatapultApi(new CatapultAuthData {UserId = "userId", ApiToken = "token", ApiSecret = "secret"});
      Assert.Equal("userId", api.UserId);
      Assert.Equal(Convert.ToBase64String(Encoding.UTF8.GetBytes("token:secret")), api.AuthenticationHeader.Parameter);
    }

    [Fact]
    public async void TestConstructor2()
    {
      var context = new MockContext<IHttp>();
      var request = new HttpRequestMessage(HttpMethod.Get, "/test");
      context.Arrange(m => m.SendAsync(request, HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      var api = new CatapultApi(new CatapultAuthData { UserId = "userId", ApiToken = "token", ApiSecret = "secret" }, new Mocks.Http(context));
      using (var response = await api.MakeJsonRequestAsync(request))
      {
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      }
      Assert.Equal("userId", api.UserId);
    }

    [Fact]
    public void TestConstructorFails()
    {
      Assert.Throws<ArgumentNullException>(() => new CatapultApi(null));
      Assert.Throws<MissingCredentialsException>(() => new CatapultApi(new CatapultAuthData()));
      Assert.Throws<InvalidBaseUrlException>(
        () =>
          new CatapultApi(new CatapultAuthData
          {
            UserId = "userId",
            ApiToken = "token",
            ApiSecret = "secret",
            BaseUrl = null
          }));
      Assert.Throws<ArgumentNullException>(
        () => new CatapultApi(new CatapultAuthData {UserId = "userId", ApiToken = "token", ApiSecret = "secret"}, null));
    }

    [Fact]
    public async void TestMakeJsonRequestReq()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetCatapultApi(context);
      var request = new HttpRequestMessage(HttpMethod.Get, "/test");
      context.Arrange(m => m.SendAsync(request, HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      using (var response = await api.MakeJsonRequestAsync(request))
      {
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      }
    }

    [Fact]
    public async void TestMakeJsonTRequest()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetCatapultApi(context);
      context.Arrange(
        m => m.SendAsync(The<HttpRequestMessage>.IsAnyValue, HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
        {
          Content = new StringContent("{\"test\": \"value\"}", Encoding.UTF8, "application/json")
        }));
      var result = await api.MakeJsonRequestAsync<MakeJsonRequestDemo>(HttpMethod.Get, "/test");
      Assert.Equal("value", result.Test);
    }

    [Fact]
    public async void TestMakeJsonRequest()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetCatapultApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidRequestWithoutBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      using (var response = await api.MakeJsonRequestAsync(HttpMethod.Get, "/test"))
      {
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      }
    }

    [Fact]
    public async void TestMakeJsonWithoutRequestRequest()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetCatapultApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidRequestWithoutBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      await api.MakeJsonRequestWithoutResponseAsync(HttpMethod.Get, "/test");

    }

    [Fact]
    public async void TestMakeJsonRequestWithBody()
    {
      var context = new MockContext<IHttp>();
      var api = Helpers.GetCatapultApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidRequestWithBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
      var response = await api.MakeJsonRequestAsync(HttpMethod.Post, "/test", null, null, new { Field = "value" });
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void TestMakePostJsonRequest()
    {
      var context = new MockContext<IHttp>();
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      response.Headers.Location = new Uri("http://host/path/id");
      var api = Helpers.GetCatapultApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidRequestWithBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(response));
      var id = await api.MakePostJsonRequestAsync("/test", null, new { Field = "value" });
      Assert.Equal("id", id);
    }

    [Fact]
    public async void TestMakePostJsonRequestWithoutLocationHeader()
    {
      var context = new MockContext<IHttp>();
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var api = Helpers.GetCatapultApi(context);
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidRequestWithBody(r)),
            HttpCompletionOption.ResponseContentRead, null))
        .Returns(Task.FromResult(response));
      var id = await api.MakePostJsonRequestAsync("/test", null, new { Field = "value" });
      Assert.True(string.IsNullOrEmpty(id));
    }

    public static bool IsValidRequestWithBody(HttpRequestMessage request)
    {
      return request.Content.Headers.ContentType.MediaType == "application/json"
             && request.Content.ReadAsStringAsync().Result == "{\"field\":\"value\"}";
    }

    public static bool IsValidRequestWithoutBody(HttpRequestMessage request)
    {
      return request.Content == null;
    }

    public class MakeJsonRequestDemo
    {
      public string Test { get; set; }
    }
  }
}
