using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.ApiV2
{
  /// <summary>
  ///   Access to Message Api
  /// </summary>
  public interface IMessage
  {

    /// <summary>
    ///   Send a message.
    /// </summary>
    /// <param name="data">Parameters of new message</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Created message</returns>
    /// <example>
    ///   <code>
    /// var message = await client.Message.SendAsync(new MessageData{ From = "from", To = new[] {"to"}, Text = "Hello"});
    /// </code>
    /// </example>
    Task<SendMessageResult> SendAsync(MessageData data, CancellationToken? cancellationToken = null);

  }

  internal class MessageApi : ApiBase, IMessage
  {
    public Task<SendMessageResult> SendAsync(MessageData data,
      CancellationToken? cancellationToken = null)
    {
      return Client.MakePostJsonRequestAsync<SendMessageResult>($"/users/{Client.UserId}/messages", cancellationToken, data, "v2");
    }
  }

  /// <summary>
  ///   Parameters to send an message
  /// </summary>
  public class MessageData
  {
    /// <summary>
    /// The message sender's telephone number (or short code).
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Message recipient telephone number (or short code).
    /// </summary>
    public string[] To { get; set; }

    /// <summary>
    /// The message contents.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Array containing list of media urls to be sent as content for an mms.
    /// </summary>
    public string[] Media { get; set; }

    /// <summary>
    /// The complete URL where the events related to the outgoing message will be sent.
    /// </summary>
    public string Tag { get; set; }
  }

  /// <summary>
  /// Rsult of batch send of some messages
  /// </summary>
  public class Message
  {
    /// <summary>
    /// Id of the message
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The message sender's telephone number (or short code).
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Message recipient telephone number (or short code).
    /// </summary>
    public string[] To { get; set; }

    /// <summary>
    /// The message contents.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Array containing list of media urls to be sent as content for an mms.
    /// </summary>
    public string[] Media { get; set; }

    /// <summary>
    /// The complete URL where the events related to the outgoing message will be sent.
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// The message owner
    /// </summary>
    public string Owner { get; set; }

    /// <summary>
    /// Direction of the message
    /// </summary>
    public MessageDirection Direction { get; set; }


  }

  /// <summary>
  /// Directions of message
  /// </summary>
  public enum MessageDirection
  {
    /// <summary>
    /// A message that came from the telephone network to one of your numbers (an "inbound" message)
    /// </summary>
    In,

    /// <summary>
    /// A message that was sent from one of your numbers to the telephone network (an "outbound" message)
    /// </summary>
    Out
  }
}
