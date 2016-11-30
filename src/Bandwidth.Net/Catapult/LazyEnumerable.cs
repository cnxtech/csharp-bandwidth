using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bandwidth.Net.Catapult
{
  internal class LazyEnumerable<T> : IEnumerable<T>
  {
    private readonly CatapultApi _client;
    private readonly Func<Task<HttpResponseMessage>> _getFirstPageFunc;

    public LazyEnumerable(CatapultApi client, Func<Task<HttpResponseMessage>> getFirstPageFunc)
    {
      if (client == null) throw new ArgumentNullException(nameof(client));
      if (getFirstPageFunc == null) throw new ArgumentNullException(nameof(getFirstPageFunc));
      _client = client;
      _getFirstPageFunc = getFirstPageFunc;
    }

    public IEnumerator<T> GetEnumerator()
    {
      var getData = _getFirstPageFunc;
      while (true)
      {
        string nextPageUrl;
        using (var response = getData().Result)
        {
          var list = response.Content.ReadAsJsonAsync<T[]>().Result;
          foreach (var item in list)
          {
            yield return item;
          }
          IEnumerable<string> linkValues;
          nextPageUrl = "";
          if (response.Headers.TryGetValues("Link", out linkValues))
          {
            var links = linkValues.First().Split(',');
            foreach (var link in links)
            {
              var values = link.Split(';');
              if (values.Length == 2 && values[1].Trim() == "rel=\"next\"")
              {
                nextPageUrl = values[0].Replace('<', ' ').Replace('>', ' ').Trim();
                break;
              }
            }
          }
        }
        if (string.IsNullOrEmpty(nextPageUrl))
        {
          yield break;
        }
        var request = RequestHelpers.CreateRequest(HttpMethod.Get, nextPageUrl, _client.BaseUrl,
          _client.AuthenticationHeader);
        getData = () => _client.MakeJsonRequestAsync(request);
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}