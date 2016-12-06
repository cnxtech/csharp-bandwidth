using System.Net.Http;
using System.Threading.Tasks;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class InserviceNumberTests
  {
    [Fact]
    public async void TestList()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("InserviceNumberList")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).InserviceNumber;
      var list = await api.ListAsync();
      Assert.True(list.Length > 0);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/inserviceNumbers";
    }

    [Fact]
    public async void TestGetTotals()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("InserviceNumberTotals")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetTotalsRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).InserviceNumber;
      var totals = await api.GetTotalsAsync();
      Assert.Equal(3, totals.Count);
    }

    public static bool IsValidGetTotalsRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/inserviceNumbers/totals";
    }

  }
}
