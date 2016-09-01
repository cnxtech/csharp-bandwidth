using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bandwidth.Net.Api;
using Bandwidth.Net.Test.Mocks;
using LightMock;
using Xunit;
using Message = Bandwidth.Net.Test.Mocks.Message;

namespace Bandwidth.Net.Test.Api
{
  public class MessageQueueTests
  {
    [Fact]
    public void TestConstructor()
    {
      var context = new MockContext<IMessage>();
      var api = new Message(context);
      var queue = new MessageQueue(api, "from", 2, new CancellationToken(true));
      Assert.Equal(api, queue.Api);
      Assert.Equal("from", queue.From);
      Assert.Equal(2, queue.MessagesToSendPerTime);
      Assert.Equal(TimeSpan.FromSeconds(1), queue.Interval);
    }

    [Fact]
    public void TestConstructor2()
    {
      var context = new MockContext<IMessage>();
      var api = new Message(context);
      var queue = new MessageQueue(api, "from1", 0.2, new CancellationToken(true));
      Assert.Equal(api, queue.Api);
      Assert.Equal("from1", queue.From);
      Assert.Equal(1, queue.MessagesToSendPerTime);
      Assert.Equal(TimeSpan.FromSeconds(5), queue.Interval);
    }

    [Fact]
    public void TestConstructorFail()
    {
      var context = new MockContext<IMessage>();
      var api = new Message(context);
      Assert.Throws<ArgumentNullException>(() => new MessageQueue(api, ""));
    }

    [Fact]
    public void TestConstructorFail2()
    {
      Assert.Throws<ArgumentNullException>(() => new MessageQueue(null, "from"));
    }

    [Fact]
    public void TestConstructorFail3()
    {
      var context = new MockContext<IMessage>();
      var api = new Message(context);
      Assert.Throws<ArgumentOutOfRangeException>(() => new MessageQueue(api, "from", 0));
    }

    [Fact]
    public void TestQueue()
    {
      var queue = GetMessageQueue();
      Assert.Equal(0, queue.MessagesQueue.Count);
      queue.Queue(new MessageData {To = "to1"});
      Assert.Equal(1, queue.MessagesQueue.Count);
      Assert.Equal("to1", queue.MessagesQueue[0].To);
      queue.Queue(new MessageData { To = "to2" }, new MessageData { To = "to3" });
      Assert.Equal(3, queue.MessagesQueue.Count);
      var list = new List<MessageData>(new[] {new MessageData {To = "to4"}, new MessageData {To = "to5"}});
      queue.Queue(list);
      Assert.Equal(5, queue.MessagesQueue.Count);
      Assert.True(queue.MessagesQueue.All(m => m.From == "from"));
    }

    [Fact]
    public void TestGetResults()
    {
      var queue = GetMessageQueue();
      var result = new SendMessageResult {Location = "http://host/messageId"};
      queue.Results.Add(result);
      var results = queue.GetResults();
      Assert.Equal(1, results.Length);
      Assert.Equal(result, results[0]);
    }

    [Fact]
    public async void TestStartSendMessagesWithEmptyQueue()
    {
      var delayContext = new MockContext<IDelay>();
      var queue = GetMessageQueue();
      queue.Delay = new Delay(delayContext);
      delayContext.Arrange(d => d.Delay(The<TimeSpan>.IsAnyValue, The<CancellationToken>.IsAnyValue)).Returns(Task.FromResult(0));
      using (var source = new CancellationTokenSource())
      {
        Task.Run(() => queue.StartSendMessages(source.Token));
        await Task.Delay(100);
        source.Cancel(false);
      }
      delayContext.Assert(d => d.Delay(The<TimeSpan>.IsAnyValue, The<CancellationToken>.IsAnyValue), Invoked.AtLeast(1));
    }

    [Fact]
    public async void TestStartSendMessages()
    {
      var delayContext = new MockContext<IDelay>();
      var messageContext = new MockContext<IMessage>();
      var queue = GetMessageQueue(messageContext);
      queue.Delay = new Delay(delayContext);
      delayContext.Arrange(d => d.Delay(The<TimeSpan>.IsAnyValue, The<CancellationToken>.IsAnyValue)).Returns(Task.FromResult(0));
      var messages = new[]
      {
        new MessageData {To = "to1", Text = "text1"},
        new MessageData {To = "to2", Text = "text2"}
      };
      var results = new[]
      {
        new SendMessageResult {Location = "http://host/id1", Message = messages[0], Result = SendMessageResults.Accepted},
        new SendMessageResult {Location = "http://host/id2", Message = messages[1], Result = SendMessageResults.Accepted}
      };
      messageContext.Arrange(m => m.SendAsync(The<MessageData[]>.IsAnyValue, The<CancellationToken>.IsAnyValue)).Returns(Task.FromResult(new SendMessageResult[0]));
      messageContext.Arrange(m => m.SendAsync(The<MessageData>.IsAnyValue, The<CancellationToken>.IsAnyValue)).Returns(Task.FromResult(null));
      using (var source = new CancellationTokenSource())
      {
        Task.Run(() => queue.StartSendMessages(source.Token));
        queue.Queue(messages);
        await Task.Delay(100000);
        source.Cancel(false);
      }
      delayContext.Assert(d => d.Delay(The<TimeSpan>.IsAnyValue, The<CancellationToken>.IsAnyValue), Invoked.AtLeast(1));
    }

    private MessageQueue GetMessageQueue(IInvocationContext<IMessage> context = null)
    {
      var api = new Message(context ?? new MockContext<IMessage>());
      return new MessageQueue(api, "from", 1, new CancellationToken(true));
    }
  }
}
