using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class UserTests
  {
    [Fact]
    public async void TestGet()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("User")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).User;
      var item = await api.GetAsync("id");
      Assert.Equal("testcustomer", item.UserName);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/users/id";
    }

    [Fact]
    public async void TestChangePassword()
    {
      var response = new HttpResponseMessage();
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidChangePasswordRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).User;
      await api.ChangePasswordAsync("id", "password");
    }

    public static bool IsValidChangePasswordRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Put
             && request.RequestUri.PathAndQuery == "/v1.0/users/id/password"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result.Contains("<Password>password</Password>");
    }

    [Fact]
    public void TestXmlSerializing()
    {
      ValidateXmlSerializable(new Password());
    }

    private void ValidateXmlSerializable(IXmlSerializable item)
    {
      Assert.Null(item.GetSchema());
      Assert.Throws<NotImplementedException>(() => item.ReadXml(null));
    }
  }
}
