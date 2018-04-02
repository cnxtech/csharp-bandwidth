using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bandwidth.Net
{
  internal sealed class JsonStringEnumConverter: StringEnumConverter
  {
    public char Delimiter {get; set;}
    public JsonStringEnumConverter():base()
    {
        Delimiter = '-';
    }
    public JsonStringEnumConverter(char delimiter):base()
    {
        Delimiter = delimiter;
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      // convert string like "enum-value" and "eNUM-VALUE" to EnumType.EnumValue
      var rawString = (string)reader.Value;
      var result = string.Join("",
        rawString.ToLowerInvariant().Replace('_', '-').Split('-').Select(v => $"{char.ToUpperInvariant(v[0])}{v.Substring(1)}"));
      return Enum.Parse(objectType, result, true);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      // convert EnumType.EnumValue to string "enum-value"
      var rawString = value.ToString();
      var result = new StringBuilder(2*rawString.Length);
      var isFirst = true;
      foreach (var s in rawString)
      {
        if (char.IsUpper(s))
        {
          if (isFirst)
          {
            isFirst = false;
          }
          else
          {
            result.Append(Delimiter);
          }
          result.Append(char.ToLowerInvariant(s));
        }
        else
        {
          result.Append(s);
        }
      }
      writer.WriteValue(result.ToString());
    }
  }
}
