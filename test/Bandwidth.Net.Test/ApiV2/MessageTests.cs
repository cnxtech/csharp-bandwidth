using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.ApiV2;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.ApiV2
{
  public class MessageTests
  {
    [Fact]
    public async void TestSend()
    {
      var response = new HttpResponseMessage(HttpStatusCode.Accepted);
      response.Content = new JsonContent(Helpers.GetJsonResourse("SendMessageResponse2"));
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidSendRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetClient(context).V2.Message;
      var message = await api.SendAsync(new MessageData {From = "+12345678901", To = new[] { "+12345678902" }, Text = "Hey, check this out!" });
      Assert.Equal("14762070468292kw2fuqty55yp2b2", message.Id);
      Assert.Equal(MessageDirection.Out, message.Direction);
    }
    public static bool IsValidSendRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Post && request.RequestUri.PathAndQuery == "/v2/users/userId/messages" &&
             request.Content.Headers.ContentType.MediaType == "application/json" &&
             request.Content.ReadAsStringAsync().Result == "{\"from\":\"+12345678901\",\"to\":[\"+12345678902\"],\"text\":\"Hey, check this out!\"}";
    }
  }
}
