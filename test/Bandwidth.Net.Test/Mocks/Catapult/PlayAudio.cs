using System.Threading;
using System.Threading.Tasks;
using Bandwidth.Net.Catapult;
using LightMock;

namespace Bandwidth.Net.Test.Mocks.Catapult
{
  public class PlayAudio : IPlayAudio
  {
    private readonly IInvocationContext<IPlayAudio> _context;

    public PlayAudio(IInvocationContext<IPlayAudio> context)
    {
      _context = context;
    }


    public Task PlayAudioAsync(string id, PlayAudioData data, CancellationToken? cancellationToken = null)
    {
      return _context.Invoke(m => m.PlayAudioAsync(id, data, cancellationToken));
    }
  }
}
