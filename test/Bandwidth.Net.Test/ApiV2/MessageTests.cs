using System;
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
    public async void TestCreateMessagingApplicationAsync()
    {
      var authData = new IrisAuthData
      {
        AccountId = "AccountId",
        UserName = "UserName",
        Password = "Password",
        SubaccountId = "SubaccountId"
      };
      var context = new MockContext<IHttp>();
      var api = Helpers.GetClient(context).V2.Message;
      
      context.Arrange(m => m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateApplicationRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(new HttpResponseMessage {Content = Helpers.GetXmlContent("CreateMessagingApplicationResponse")}));
      var response = new HttpResponseMessage();
      response.Headers.Location = new Uri("http://localhost/LocationId");
      context.Arrange(m => m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateLocationRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      context.Arrange(m => m.SendAsync(The<HttpRequestMessage>.Is(r => IsEnableSms(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(new HttpResponseMessage()));
      context.Arrange(m => m.SendAsync(The<HttpRequestMessage>.Is(r => IsEnableMms(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(new HttpResponseMessage()));
      context.Arrange(m => m.SendAsync(The<HttpRequestMessage>.Is(r => IsAssignApplicationToLocationRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(new HttpResponseMessage()));
      
      var application = await api.CreateMessagingApplicationAsync(authData, new CreateMessagingApplicationData
      {
        Name = "App1",
        CallbackUrl = "url",
        LocationName = "Location1",
        SmsOptions = new SmsOptions
        {
          TollFreeEnabled = true
        },
        MmsOptions = new MmsOptions
        {
          Enabled = true
        }
      });
      Assert.Equal("ApplicationId", application.ApplicationId);
      Assert.Equal("LocationId", application.LocationId);
    }

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
      var message = await api.SendAsync(new MessageData {From = "+12345678901", To = new[] { "+12345678902" }, Text = "Hey, check this out!", ApplicationId = "id" });
      Assert.Equal("14762070468292kw2fuqty55yp2b2", message.Id);
      Assert.Equal(MessageDirection.Out, message.Direction);
    }
    public static bool IsValidSendRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Post && request.RequestUri.PathAndQuery == "/v2/users/userId/messages" &&
             request.Content.Headers.ContentType.MediaType == "application/json" &&
             request.Content.ReadAsStringAsync().Result == "{\"from\":\"+12345678901\",\"to\":[\"+12345678902\"],\"text\":\"Hey, check this out!\",\"applicationId\":\"id\"}";
    }

    public static bool IsValidCreateApplicationRequest(HttpRequestMessage request)
    {
      return false; //TODO implement
    }

    public static bool IsValidCreateLocationRequest(HttpRequestMessage request)
    {
      return false; //TODO implement
    }

    public static bool IsEnableSms(HttpRequestMessage request)
    {
      return false; //TODO implement
    }

    public static bool IsEnableMms(HttpRequestMessage request)
    {
      return false; //TODO implement
    }

    public static bool IsAssignApplicationToLocationRequest(HttpRequestMessage request)
    {
      return false; //TODO implement
    }
  }
}
