using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class LineOptionOrderTests
  {
    [Fact]
    public async void TestCreate()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("LineOptionOrder")
      };
      var context = new MockContext<IHttp>();
      var data = new[]
      {
        new TnLineOptions
        {
          CallingNameDisplay = "data1",
          TelephoneNumber = "+1234567890"
        }
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).LineOptionOrder;
      var numbers = await api.CreateAsync(data);
      Assert.Equal(1, numbers.Length);
      Assert.Equal("2013223685", numbers[0]);
    }

    public static bool IsValidCreateRequest(HttpRequestMessage request, TnLineOptions[] data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lineOptionOrders"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(new LineOptionOrderRequest{ TnLineOptions = data });
    }
  }
}
