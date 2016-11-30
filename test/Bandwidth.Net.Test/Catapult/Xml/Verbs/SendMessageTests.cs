using System;
using System.Xml.Serialization;
using Bandwidth.Net.Xml.Verbs;
using Bandwidth.Net.Xml;
using Xunit;

namespace Bandwidth.Net.Test.Xml.Verbs
{
  public class SendMessageTests
  {
    [Fact]
    public void TestConstructor()
    {
      new SendMessage();
    }

    [Fact]
    public void TestReadXml()
    {
      var instance = new SendMessage() as IXmlSerializable;
      Assert.Throws<NotImplementedException>(() => instance.ReadXml(null));
    }

    [Fact]
    public void TestGetSchema()
    {
      var instance = new SendMessage() as IXmlSerializable;
      Assert.Null(instance.GetSchema());
    }

    [Fact]
    public void TestWriteXml()
    {
      var response = new Response(new SendMessage{
        From = "from",
        To = "to",
        Text = "Hello",
        RequestUrl = "url1",
        RequestUrlTimeout = 10,
        StatusCallbackUrl = "url2"
      });
      Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response>\n  <SendMessage from=\"from\" to=\"to\" requestUrl=\"url1\" requestUrlTimeout=\"10\" statusCallbackUrl=\"url2\">Hello</SendMessage>\n</Response>", response.ToXml().Replace("\r\n", "\n"));
    }
  }
}
