using System;
using Xunit;
using LightMock;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Net;

namespace Bandwidth.Net.Test
{
  public class ClientTests
    {
        [Fact]
        public void TestConstructor()
        {
            var api = new Client("userId", "apiToken", "apiSecret");
        }

        [Fact]
        public void TestConstructorWithBaseUrl()
        {
            var api = new Client("userId", "apiToken", "apiSecret", "http://host");
            Assert.Equal("http://host/v1/", api.CreateRequest(HttpMethod.Get, "/").RequestUri.ToString());
        }

        [Fact]
        public void TestConstructorWithEmptyCredentialParams()
        {
            Assert.Throws<MissingCredentialsException>(() => new Client("", "apiToken", "apiSecret"));
        }

        [Fact]
        public void TestConstructorWithEmptyBaseUrl()
        {
            Assert.Throws<InvalidBaseUrlException>(() => new Client("userId", "apiToken", "apiSecret", ""));
        }

        [Fact]
        public void TestCreateRequest()
        {
            var api = new Client("userId", "apiToken", "apiSecret");
            var request = api.CreateRequest(HttpMethod.Get, "/test");
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("https://api.catapult.inetwork.com/v1/test", request.RequestUri.ToString());
            var hash = Convert.ToBase64String(Encoding.UTF8.GetBytes("apiToken:apiSecret"));
            Assert.Equal($"Basic {hash}", request.Headers.Authorization.ToString());
        }
        
        [Fact]
        public void TestCreateRequestWithQuery()
        {
            var api = new Client("userId", "apiToken", "apiSecret");
            var request = api.CreateRequest(HttpMethod.Get, "/test", new {Field1 = 1, Field2 = "text value", Field3 = new DateTime(2016, 8, 1, 0, 0, 0, DateTimeKind.Utc) });
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("https://api.catapult.inetwork.com/v1/test?field1=1&field2=text value&field3=2016-08-01T00:00:00.0000000Z", request.RequestUri.ToString());
            var hash = Convert.ToBase64String(Encoding.UTF8.GetBytes("apiToken:apiSecret"));
            Assert.Equal($"Basic {hash}", request.Headers.Authorization.ToString());
        }

        [Fact]
        public async void TestMakeRequest()
        {
            var context = new MockContext<IHttp>();
            var api = new Client("userId", "apiToken", "apiSecret", "url", new Mocks.Http(context));
            var request = new HttpRequestMessage(HttpMethod.Get, "/test");
            context.Arrange(c => c.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None))
                .Returns(Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            var response = await api.MakeRequest(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
