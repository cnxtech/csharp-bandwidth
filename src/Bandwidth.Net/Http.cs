using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net
{
  public interface IHttp
  {
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken);
  }

  internal class Http<THandler> : IHttp where THandler : HttpMessageHandler, new()
  {
    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
    {
      using (var client = new HttpClient(new THandler(), true))
      {
        return await client.SendAsync(request, completionOption, cancellationToken);
      }
    }
  }
}
