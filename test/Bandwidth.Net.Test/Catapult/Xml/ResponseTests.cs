using System;
using System.Xml.Serialization;
using Bandwidth.Net.Catapult.Xml;
using Xunit;

namespace Bandwidth.Net.Test.Catapult.Xml
{
  public class ResponseTests
  {
    [Fact]
    public void TestToXml()
    {
      var response = new Response();
      Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response />", response.ToXml().Replace("\r\n", "\n"));
    }

    [Fact]
    public void TestToXml2()
    {
      var response = new Response(new TestItem
      {
        StringValue = "Test",
        Attribute1 = 10
      });
      Assert.Equal(
        "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response>\n  <TestItem Attribute1=\"10\">\n    <StringValue>Test</StringValue>\n  </TestItem>\n</Response>",
        response.ToXml().Replace("\r\n", "\n"));
    }

    [Fact]
    public void TestToXml3()
    {
      var response = new Response();
      response.Add(new TestItem
      {
        StringValue = "Test",
        Attribute1 = 10
      });
      Assert.Equal(
        "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response>\n  <TestItem Attribute1=\"10\">\n    <StringValue>Test</StringValue>\n  </TestItem>\n</Response>",
        response.ToXml().Replace("\r\n", "\n"));
    }

    [Fact]
    public void TestToXmlWithNested()
    {
      var response = new Response();
      response.Add(new TestItem
      {
        Attribute1 = 10,
        Nested = new TestItem {Attribute1 = 20}
      });
      Assert.Equal(
        "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Response>\n  <TestItem Attribute1=\"10\">\n    <Nested Attribute1=\"20\" />\n  </TestItem>\n</Response>",
        response.ToXml().Replace("\r\n", "\n"));
    }

    [Fact]
    public void TestReadXml()
    {
      var response = new Response() as IXmlSerializable;
      Assert.Throws<NotImplementedException>(() => response.ReadXml(null));
    }

    [Fact]
    public void TestGetSchema()
    {
      var response = new Response() as IXmlSerializable;
      Assert.Null(response.GetSchema());
    }

    public class TestItem : IVerb
    {
      public string StringValue { get; set; }

      [XmlAttribute]
      public int Attribute1 { get; set; }

      public TestItem Nested { get; set; }
    }
  }
}
