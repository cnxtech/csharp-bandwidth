using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Bandwidth.Net.Test
{
  public class RequestHelpersTests
  {
    [Fact]
    public void TestCreateRequest()
    {
      var hash = Convert.ToBase64String(Encoding.UTF8.GetBytes("apiToken:apiSecret"));
      var request = RequestHelpers.CreateRequest(HttpMethod.Get, "/test", "http://localhost/v1", new AuthenticationHeaderValue("Basic", hash));
      Assert.Equal(HttpMethod.Get, request.Method);
      Assert.Equal("http://localhost/v1/test", request.RequestUri.ToString());
      Assert.Equal($"Basic {hash}", request.Headers.Authorization.ToString());
    }

    [Fact]
    public void TestCreateRequestWithAbsoluteUrl()
    {
      var request = RequestHelpers.CreateRequest(HttpMethod.Get, "http://my-host/test", "http://localhost/v1", new AuthenticationHeaderValue("Basic", ""));
      Assert.Equal(HttpMethod.Get, request.Method);
      Assert.Equal("http://my-host/test", request.RequestUri.ToString());
    }

    [Fact]
    public void TestCreateRequestWithQuery()
    {
      var hash = Convert.ToBase64String(Encoding.UTF8.GetBytes("apiToken:apiSecret"));
      var request = RequestHelpers.CreateRequest(HttpMethod.Get, "/test", "http://localhost/v1", new AuthenticationHeaderValue("Basic", hash),
        new
        {
          Field1 = 1,
          Field2 = "text value",
          Field3 = new DateTime(2016, 8, 1, 0, 0, 0, DateTimeKind.Utc),
          EmptyField = (string) null,
          EmptyField2 = ""
        });
      Assert.Equal(HttpMethod.Get, request.Method);
      Assert.Equal(
        "http://localhost/v1/test?field1=1&field2=text value&field3=2016-08-01T00:00:00.0000000Z",
        request.RequestUri.ToString());
      Assert.Equal($"Basic {hash}", request.Headers.Authorization.ToString());
    }
  }
}
