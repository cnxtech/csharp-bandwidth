using System;
using System.Net.Http;
using System.Threading.Tasks;
using Bandwidth.Net.Api;
using Newtonsoft.Json;

namespace Bandwidth.Net.ApiV2
{
  /// <summary>
  ///   Catapult Api callback event
  /// </summary>
  /// <example>
  /// <code>
  /// var callbackEvent = CallbackEvent.CreateFromJson("{\"type\": \"message-received\"}");
  /// switch(callbackEvent.Type)
  /// {
  ///   case CallbackEventType.MessageReceived:
  ///     Console.WriteLine($"Sms {callbackEvent.Message.From} -> {string.Join(", ", callbackEvent.Message.To)}: {callbackEvent.Message.Text}");
  ///     break;
  /// }
  /// </code>
  /// </example>
  public class CallbackEvent
  {
    /// <summary>
    ///   Event type
    /// </summary>
    public CallbackEventType Type { get; set; }

    /// <summary>
    ///   Event time
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    ///   Event description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///   Message data
    /// </summary>
    public Message Message { get; set; }

    public static CallbackEvent CreateFromJson(string json)
      => JsonConvert.DeserializeObject<CallbackEvent>(json, JsonHelpers.GetSerializerSettings());
  }

  /// <summary>
  ///   Possible event types
  /// </summary>
  public enum CallbackEventType
  {
    /// <summary>
    ///   Unknown type
    /// </summary>
    Unknown,

    /// <summary>
    ///   Message received
    /// </summary>
    MessageReceived,

    /// <summary>
    ///   Message sent
    /// </summary>
    MessageSent,

    /// <summary>
    ///   Message delivered
    /// </summary>
    MessageDelivered,

    /// <summary>
    ///   Message rejected forbidden country
    /// </summary>
    MessageRejectedForbiddenCountry
  }
}
