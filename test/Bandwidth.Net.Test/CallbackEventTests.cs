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

    [Fact]
    public void TestSmsEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("SmsEvent"));
      Assert.Equal(CallbackEventType.Sms, callbackEvent.EventType);
      Assert.Equal("{messageId}", callbackEvent.MessageId);
    }

    [Fact]
    public void TestMmsEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("MmsEvent"));
      Assert.Equal(CallbackEventType.Mms, callbackEvent.EventType);
      Assert.Equal("m-dr4mcch2wfb6frcls677glq", callbackEvent.MessageId);
    }

    [Fact]
    public void TestAnswerEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("AnswerEvent"));
      Assert.Equal(CallbackEventType.Answer, callbackEvent.EventType);
      Assert.Equal("m-dr4mcch2wfb6frcls677glq", callbackEvent.MessageId);
    }

    [Fact]
    public void TestPlaybackEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("PlaybackEvent"));
      Assert.Equal(CallbackEventType.Playback, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
    }

    [Fact]
    public void TestTimeoutEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("TimeoutEvent"));
      Assert.Equal(CallbackEventType.Timeout, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
    }

    [Fact]
    public void TestConferenceEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("ConferenceEvent"));
      Assert.Equal(CallbackEventType.Conference, callbackEvent.EventType);
      Assert.Equal("{conferenceId}", callbackEvent.ConferenceId);
    }

    [Fact]
    public void TestConferencePlaybackEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("ConferencePlaybackEvent"));
      Assert.Equal(CallbackEventType.ConferencePlayback, callbackEvent.EventType);
      Assert.Equal("{conferenceId}", callbackEvent.ConferenceId);
    }

    [Fact]
    public void TestConferenceMemberEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("ConferenceMemberEvent"));
      Assert.Equal(CallbackEventType.ConferenceMember, callbackEvent.EventType);
      Assert.Equal("{conferenceId}", callbackEvent.ConferenceId);
      Assert.Equal("{callId}", callbackEvent.CallId);
    }

    [Fact]
    public void TestConferenceSpeakEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("ConferenceSpeakEvent"));
      Assert.Equal(CallbackEventType.ConferenceSpeak, callbackEvent.EventType);
      Assert.Equal("{conferenceId}", callbackEvent.ConferenceId);
    }

    [Fact]
    public void TestDtmfEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("DtmfEvent"));
      Assert.Equal(CallbackEventType.Dtmf, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal("5", callbackEvent.DtmfDigits);
    }

    [Fact]
    public void TestGatherEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("GatherEvent"));
      Assert.Equal(CallbackEventType.Gather, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal("25", callbackEvent.Digits);
    }

    [Fact]
    public void TestIncomingCallEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("IncomingCallEvent"));
      Assert.Equal(CallbackEventType.IncomingCall, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal("{appId}", callbackEvent.ApplicationId);
    }

    [Fact]
    public void TestHangupEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("HangupEvent"));
      Assert.Equal(CallbackEventType.Hangup, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal("NORMAL_CLEARING", callbackEvent.Cause);
    }

    [Fact]
    public void TestRecordingEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("RecordingEvent"));
      Assert.Equal(CallbackEventType.Recording, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal("{recordingId}", callbackEvent.RecordingId);
    }

    [Fact]
    public void TestRejectEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("RejectEvent"));
      Assert.Equal(CallbackEventType.Hangup, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal("CALL_REJECTED", callbackEvent.Cause);
    }

    [Fact]
    public void TestSpeakEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("SpeakEvent"));
      Assert.Equal(CallbackEventType.Speak, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal(CallbackEventState.PlaybackStart, callbackEvent.State);
    }

    [Fact]
    public void TestSpeakEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("SpeakEvent"));
      Assert.Equal(CallbackEventType.Speak, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal(CallbackEventState.PlaybackStart, callbackEvent.State);
    }

    [Fact]
    public void TestTranscriptionEvent()
    {
      var callbackEvent = CallbackEvent.CreateFromJson(Helpers.GetJsonContent("TranscriptionEvent"));
      Assert.Equal(CallbackEventType.Transcription, callbackEvent.EventType);
      Assert.Equal("{callId}", callbackEvent.CallId);
      Assert.Equal("{transcriptionId}", callbackEvent.TranscriptionId);
      Assert.Equal(CallbackEventState.Completed, callbackEvent.State);
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
