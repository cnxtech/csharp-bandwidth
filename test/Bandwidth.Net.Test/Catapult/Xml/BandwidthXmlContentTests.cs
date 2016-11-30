using Bandwidth.Net.Catapult.Xml;
using Bandwidth.Net.Catapult.Xml.Verbs;
using Xunit;

namespace Bandwidth.Net.Test.Catapult.Xml
{
  public class BandwidthXmlContentTests
  {
    [Fact]
    public async void TestConstructor()
    {
      using (var content = new BandwidthXmlContent(new Response(new Hangup())))
      {
        Assert.Equal("text/xml", content.Headers.ContentType.MediaType);
        var xml = await content.ReadAsStringAsync();
        Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response>\n  <Hangup />\n</Response>", xml.Replace("\r\n", "\n"));
      }
    }
  }
}
