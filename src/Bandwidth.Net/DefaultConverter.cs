using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bandwidth.Net
{
  /// <summary>
  /// Default Json converter (without changing names)
  /// </summary>
  public class DefaultConverter : JsonConverter
  {
    /// <summary>
    /// CanConvert
    /// </summary>
    /// <param name="objectType">Type of converted object</param>
    /// <returns></returns>
    public override bool CanConvert(Type objectType)
    {
      return true;
    }

    /// <summary>
    /// ReadJson
    /// </summary>
    /// <param name="reader">reader</param>
    /// <param name="objectType">objectType</param>
    /// <param name="existingValue">existingValue</param>
    /// <param name="serializer">serializer</param>
    /// <returns></returns>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      var rawString = JObject.Load(reader).ToString();
      return JsonConvert.DeserializeObject(rawString, objectType); // use default settings
    }

    /// <summary>
    /// WriteJson
    /// </summary>
    /// <param name="writer">writer</param>
    /// <param name="value">value</param>
    /// <param name="serializer">serializer</param>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      var json = JsonConvert.SerializeObject(value); // use default settings
      writer.WriteRawValue(json);
    }
  }
}
