using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class LnpCheckerTests
  {
    [Fact]
    public async void TestCheck()
    {
      var numbers = new[] {"123", "456"};
      var resp = new NumberPortabilityResponse
      {
        SupportedRateCenters = new[]
        {
          new RateCenterGroup
          {
            RateCenter = "Center1",
            City = "City1",
            State = "State1",
            Lata = "11",
            Tiers = new[] {"111", "222", "333"},
            TnList = new[] {"1111", "2222", "3333"}
          }
        },
        UnsupportedRateCenters = new RateCenterGroup[0]
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(resp))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidPostRequest(r, numbers)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).LnpChecker;
      var res = await api.CheckAsync(numbers, true);
      Assert.Equal("City1", res.SupportedRateCenters.First().City);
    }

    public static bool IsValidPostRequest(HttpRequestMessage request, string[] numbers)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/lnpchecker?fullCheck=true"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             &&
             request.Content.ReadAsStringAsync().Result ==
             Helpers.ToXmlString(new NumberPortabilityRequest {TnList = numbers});
    }
  }
}
