using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Api
{
  internal interface IDelay
  {
    Task Delay(TimeSpan interval, CancellationToken cancellationToken);
  }

  internal class DelayInternal : IDelay
  {
    public Task Delay(TimeSpan interval, CancellationToken cancellationToken)
    {
      return Task.Delay(interval, cancellationToken);
    }
  }

  public class MessageQueue
  {
    internal readonly IMessage Api;
    internal readonly string From;
    internal readonly List<MessageData> MessagesQueue;
    internal readonly List<SendMessageResult> Results;
    internal readonly int Count;
    internal readonly TimeSpan Interval;
    internal IDelay Delay;

    public MessageQueue(IMessage api, string from, double rate = 1, CancellationToken? cancellationToken = null)
    {
      if(rate <= 0) throw new ArgumentOutOfRangeException(nameof(rate), $"{nameof(rate)} should be more than 0");
      Api = api;
      From = @from;
      if (rate >= 1)
      {
        Count = (int) Math.Round(rate);
        Interval = TimeSpan.FromSeconds(1);
      }
      else
      {
        Interval = TimeSpan.FromSeconds(1/rate);
        Count = 1;
      }
      MessagesQueue = new List<MessageData>();
      Results = new List<SendMessageResult>();
      StartSendMessages(cancellationToken ?? CancellationToken.None).Start();
    }

    public void Queue(params MessageData[] data)
    {
      Queue((IEnumerable<MessageData>)data);
    }

    public void Queue(IEnumerable<MessageData> data)
    {
      var list = data.ToList();
      foreach (var messageData in list)
      {
        messageData.From = From;
      }
      lock (MessagesQueue)
      {
        MessagesQueue.AddRange(list);
      }
    }

    public SendMessageResult[] GetResults()
    {
      lock (Results)
      {
        return Results.ToArray();
      }
    }

 
    internal async Task  StartSendMessages(CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
      {
        return;
      }
      MessageData[] messages;
      var startTime = DateTime.Now;
      lock (MessagesQueue)
      {
        messages = MessagesQueue.Take(Count).ToArray();
        MessagesQueue.RemoveRange(0, messages.Length);
      }
      var delay = Delay ?? new DelayInternal();
      if (messages.Length > 0)
      {
        var results = await Api.SendAsync(messages, cancellationToken);
        var rateLimitResults =
          results.Where(r => r.Error.Code == "message-rate-limit" || r.Error.Code == "multi-message-limit").ToList();
        var rateLimitMessages = rateLimitResults.Select(r => r.Message).ToList();
        if (rateLimitMessages.Count > 0)
        {
          Queue(rateLimitMessages); //repeat sending of rate limited messages;
          await delay.Delay(TimeSpan.FromSeconds(1), cancellationToken);
          // wait a bit to avoid rate limit error for next messages
        }
        var otherResults = results.Where(r => !rateLimitResults.Contains(r));
        lock (Results)
        {
          Results.AddRange(otherResults);
        }
      }
      var executionTime = DateTime.Now - startTime;
      var timeToWait = Interval - executionTime;
      await delay.Delay(timeToWait, cancellationToken);
      await StartSendMessages(cancellationToken);
    }
  }
}
