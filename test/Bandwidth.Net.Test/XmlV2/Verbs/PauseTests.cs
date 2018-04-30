using System.Xml.Serialization;
using Bandwidth.Net.XmlV2.Verbs;
using Bandwidth.Net.Xml;
using Xunit;
using System;

namespace Bandwidth.Net.Test.XmlV2.Verbs
{
  public class PauseTests
  {
    [Fact]
    public void TestConstructor()
    {
      new Pause();
    }


    [Fact]
    public void TestWriteXml()
    {
      var response = new Response(new Pause
      {
        Length = 5
      });
      Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response>\n  <Pause length=\"5\" />\n</Response>", response.ToXml().Replace("\r\n", "\n"));
    }
  }
}
