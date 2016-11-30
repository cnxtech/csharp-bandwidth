using System.Net.Http;
using Xunit;
using Bandwidth.Net.Catapult;

namespace Bandwidth.Net.Test.Catapult
{
  public class CallbackEventTests
  {
    [Fact]
    public void TestCreateFromJson()
    {
      var callbackEvent = CallbackEvent.CreateFromJson("{\"eventType\": \"speak\", \"state\": \"PLAYBACK_STOP\"}");
      Assert.Equal(CallbackEventType.Speak, callbackEvent.EventType);
      Assert.Equal(CallbackEventState.PlaybackStop, callbackEvent.State);
    }

    [Fact]
    public void TestCreateFromJson2()
    {
      var callbackEvent = CallbackEvent.CreateFromJson("{\"eventType\": \"sms\", \"deliveryState\": \"not-delivered\"}");
      Assert.Equal(CallbackEventType.Sms, callbackEvent.EventType);
      Assert.Equal(MessageDeliveryState.NotDelivered, callbackEvent.DeliveryState);
    }

    [Fact]
    public void TestCreateFromJson3()
    {
      var callbackEvent = CallbackEvent.CreateFromJson("{}");
      Assert.Equal(CallbackEventType.Unknown, callbackEvent.EventType);
    }
  }

  public class CallbackEventHelpersTests
  {
    [Fact]
    public async void TestReadAsCallbackEvent()
    {
      var response = new HttpResponseMessage
      {
        Content = new JsonContent("{\"eventType\": \"speak\", \"state\": \"PLAYBACK_STOP\"}")
      };

      var callbackEvent = await response.Content.ReadAsCallbackEventAsync();
      Assert.Equal(CallbackEventType.Speak, callbackEvent.EventType);
      Assert.Equal(CallbackEventState.PlaybackStop, callbackEvent.State);
    }
  }
}
