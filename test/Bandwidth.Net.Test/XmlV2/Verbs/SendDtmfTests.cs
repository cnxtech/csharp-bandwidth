using System.Xml.Serialization;
using Bandwidth.Net.XmlV2.Verbs;
using Bandwidth.Net.Xml;
using Xunit;
using System;

namespace Bandwidth.Net.Test.XmlV2.Verbs
{
  public class SendDtmfTests
  {
    [Fact]
    public void TestConstructor()
    {
      new SendDtmf();
    }

    [Fact]
    public void TestReadXml()
    {
      var instance = new SendDtmf() as IXmlSerializable;
      Assert.Throws<NotImplementedException>(() => instance.ReadXml(null));
    }

    [Fact]
    public void TestGetSchema()
    {
      var instance = new SendDtmf() as IXmlSerializable;
      Assert.Null(instance.GetSchema());
    }

    [Fact]
    public void TestWriteXml()
    {
      var response = new Response(new SendDtmf
      {
        Digits = "5"
      });
      Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response>\n  <SendDtmf>5</SendDtmf>\n</Response>", response.ToXml().Replace("\r\n", "\n"));
    }
  }
}
