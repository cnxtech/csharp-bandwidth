using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;

namespace Bandwidth.Net.Test
{
  public class DefaultConverterTests
  {
    [Fact]
    public void TestReadJson()
    {
      var item =
        JsonConvert.DeserializeObject<TestItem>("{\"items\": {\"Header1\": \"Value1\", \"Header2\": \"Value2\"}}",
          JsonHelpers.GetSerializerSettings());
      Assert.Equal("Value1", item.Items["Header1"]);
      Assert.Equal("Value2", item.Items["Header2"]);
    }

    [Fact]
    public void TestWriteJson()
    {
      var item = new TestItem
      {
        Items = new Dictionary<string, string>
        {
          {"Header1", "Value1"},
          {"Header2", "Value2"}
        },
        Name = "Name1"
      };
      var json = JsonConvert.SerializeObject(item, JsonHelpers.GetSerializerSettings());
      Assert.Equal("{\"items\":{\"Header1\":\"Value1\",\"Header2\":\"Value2\"},\"name\":\"Name1\"}", json);
    }

    [Fact]
    public void TestCanConvert()
    {
      var converter = new DefaultConverter();
      Assert.True(converter.CanConvert(typeof (object)));
    }

    public class TestItem
    {
      [JsonConverter(typeof (DefaultConverter))]
      public Dictionary<string, string> Items { get; set; }

      public string Name {get;set;}
    }
  }
}
