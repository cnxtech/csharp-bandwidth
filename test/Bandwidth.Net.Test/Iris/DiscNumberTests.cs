using System.Net.Http;
using System.Threading.Tasks;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class DiscNumberTests
  {
    [Fact]
    public async void TestGet()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("DiscNumber")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).DiscNumber;
      var list = await api.ListAsync();
      Assert.Equal(2, list.Length);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get && request.RequestUri.PathAndQuery == "/v1.0/discnumbers";
    }

    [Fact]
    public async void TestGetTotals()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("DiscNumberTotals")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetTotalsRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).DiscNumber;
      var total = await api.GetTotalsAsync();
      Assert.Equal(2, total.Count);
    }

    public static bool IsValidGetTotalsRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get && request.RequestUri.PathAndQuery == "/v1.0/discnumbers/totals";
    }
  }
}
