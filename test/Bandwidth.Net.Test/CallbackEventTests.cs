using System.Net.Http;
using Bandwidth.Net.Api;
using Xunit;

namespace Bandwidth.Net.Test
{
  public class CallbackEventTests
  {
    [Fact]
    public void TestCreateFromJson()
    {
      var callbackEvent = CallbackEvent.CreateFromJson("{\"eventType\": \"speak\", \"state\": \"PLAYBACK_STOP\"}");
      Assert.Equal(CallbackEventTypes.Speak, callbackEvent.EventType);
      Assert.Equal(CallbackEventStates.PlaybackStop, callbackEvent.State);
    }

    [Fact]
    public void TestCreateFromJson2()
    {
      var callbackEvent = CallbackEvent.CreateFromJson("{\"eventType\": \"sms\", \"deliveryState\": \"not-delivered\"}");
      Assert.Equal(CallbackEventTypes.Sms, callbackEvent.EventType);
      Assert.Equal(MessageDeliveryState.NotDelivered, callbackEvent.DeliveryState);
    }

    [Fact]
    public void TestCreateFromJson3()
    {
      var callbackEvent = CallbackEvent.CreateFromJson("{}");
      Assert.Equal(CallbackEventTypes.Unknown, callbackEvent.EventType);
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
      Assert.Equal(CallbackEventTypes.Speak, callbackEvent.EventType);
      Assert.Equal(CallbackEventStates.PlaybackStop, callbackEvent.State);
    }
  }
}
