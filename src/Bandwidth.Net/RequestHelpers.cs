using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

namespace Bandwidth.Net
{
  internal static class RequestHelpers
  {
    private static ProductInfoHeaderValue BuildUserAgent()
    {
      var assembly = typeof (RequestHelpers).GetTypeInfo().Assembly;
      var assemblyName = new AssemblyName(assembly.FullName);
      return new ProductInfoHeaderValue("csharp-bandwidth",
        $"v{assemblyName.Version.Major}.{assemblyName.Version.Minor}");
    }

    private static readonly ProductInfoHeaderValue UserAgent = BuildUserAgent();

    private static string BuildQueryString(object query)
    {
      var type = query.GetType();
      return string.Join("&", from p in type.GetRuntimeProperties()
        let v = p.GetValue(query)
        where v != null
        let tv = TransformQueryParameterValue(v)
        where !string.IsNullOrEmpty(tv)
        select $"{TransformQueryParameterName(p.Name)}={Uri.EscapeDataString(tv)}");
    }

    private static string TransformQueryParameterName(string name)
    {
      return $"{char.ToLowerInvariant(name[0])}{name.Substring(1)}";
    }

    private static string TransformQueryParameterValue(object value)
    {
      if (value is DateTime)
      {
        return ((DateTime) value).ToUniversalTime().ToString("o");
      }
      return Convert.ToString(value);
    }

    internal static HttpRequestMessage CreateRequest(HttpMethod method, string path, string baseUrl, AuthenticationHeaderValue authenticationHeader, object query = null)
    {
      var url = path.Contains("://") ? path : $"{baseUrl}{path}";
      var urlWithQuery = new UriBuilder(url);
      if (query != null)
      {
        urlWithQuery.Query = BuildQueryString(query);
      }
      var message = new HttpRequestMessage(method, urlWithQuery.Uri);
      message.Headers.UserAgent.Add(UserAgent);
      message.Headers.Authorization = authenticationHeader;
      return message;
    }
  }
}
