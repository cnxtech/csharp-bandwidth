using Xunit;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;

namespace Bandwidth.Net.Test
{
  /*public class HttpTests
  {
    [Fact]
    public async void TestSendAsync()
    {
      var http = new Http();
      var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:9988");
      var listener = new TcpListener(IPAddress.Loopback, 9988);
      listener.Start();
      var task = listener.AcceptSocketAsync().ContinueWith(t =>
      {
        var socket = t.Result;
        socket.Send(Encoding.UTF8.GetBytes("HTTP/1.1 204 OK\n\n"));
      });
      var response = await http.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
      Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
      task.Wait();
      listener.Stop();
    }
  }*/
}
