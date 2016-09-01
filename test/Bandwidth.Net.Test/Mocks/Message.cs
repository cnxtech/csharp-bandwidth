using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bandwidth.Net.Api;
using LightMock;

namespace Bandwidth.Net.Test.Mocks
{
  public class Message : IMessage
  {
    private readonly IInvocationContext<IMessage> _context;

    public Message(IInvocationContext<IMessage> context)
    {
      _context = context;
    }


    public IEnumerable<Net.Api.Message> List(MessageQuery query = null, CancellationToken? cancellationToken = null)
    {
      throw new NotImplementedException();
    }

    public Task<ILazyInstance<Net.Api.Message>> SendAsync(MessageData data, CancellationToken? cancellationToken = null)
    {
      return _context.Invoke(m => m.SendAsync(data, cancellationToken));
    }

    public Task<SendMessageResult[]> SendAsync(MessageData[] data, CancellationToken? cancellationToken = null)
    {
      return _context.Invoke(m => m.SendAsync(data, cancellationToken));
    }

    public Task<Net.Api.Message> GetAsync(string messageId, CancellationToken? cancellationToken = null)
    {
      throw new NotImplementedException();
    }
  }
}
