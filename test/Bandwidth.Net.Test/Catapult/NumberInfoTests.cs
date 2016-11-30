using System.Net.Http;
using System.Threading.Tasks;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Catapult
{
  public class NumberInfoTests
  {
    [Fact]
    public async void TestGet()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetCatapultContent("NumberInfo")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetCatapultApi(context).NumberInfo;
      var numberInfo = await api.GetAsync("1234567890");
      Assert.Equal("Name", numberInfo.Name);
      Assert.Equal("number", numberInfo.Number);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get && request.RequestUri.PathAndQuery == "/v1/phoneNumbers/numberInfo/1234567890";
    }
  }
}
