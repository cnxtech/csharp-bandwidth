using System.Net.Http;
using System.Reflection;
using System.Resources;
using System.Text;
using Bandwidth.Net.Catapult;
using Bandwidth.Net.Iris;
using Bandwidth.Net.Test.Mocks;
using LightMock;

namespace Bandwidth.Net.Test
{
  public static class Helpers
  {
    public static CatapultApi GetCatapultApi(MockContext<IHttp> context = null)
    {
      return new CatapultApi(new CatapultAuthData { UserId = "userId", ApiToken = "token", ApiSecret = "secret", BaseUrl = "http://localhost/v1" }, new Http(context));
    }

    public static IrisApi GetIrisApi(MockContext<IHttp> context = null)
    {
      return new IrisApi(new IrisAuthData { AccountId = "accountId", UserName = "userName", Password = "password", BaseUrl = "http://localhost/v1.0" }, new Http(context));
    }

    private static readonly ResourceManager JsonResourceManager = new ResourceManager("Bandwidth.Net.Test.Catapult.Json", typeof(Helpers).GetTypeInfo().Assembly);
    public static string GetCatapultResourse(string name)
    {
      return JsonResourceManager.GetString(name);
    }

    public static JsonContent GetCatapultContent(string name)
    {
      return new JsonContent(GetCatapultResourse(name));
    }

    private static readonly ResourceManager XmlResourceManager = new ResourceManager("Bandwidth.Net.Test.Iris.Xml", typeof(Helpers).GetTypeInfo().Assembly);
    public static string GetIrisResourse(string name)
    {
      return XmlResourceManager.GetString(name);
    }

    public static XmlContent GetIrisContent(string name)
    {
      return new XmlContent(GetIrisResourse(name));
    }
  }

  public class JsonContent : StringContent
  {
    public JsonContent(string content) : base(content, Encoding.UTF8, "application/json")
    {
    }
  }

  public class XmlContent : StringContent
  {
    public XmlContent(string content) : base(content, Encoding.UTF8, "application/xml")
    {
    }
  }
}
