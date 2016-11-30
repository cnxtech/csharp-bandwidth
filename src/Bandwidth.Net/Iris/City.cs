using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bandwidth.Net.Iris
{
    public interface ICity
    {
        Task<City[]> ListAsync(CityQuery query = null, CancellationToken? cancellationToken = null);
    }

    internal class CityApi : ApiBase, ICity
    {
        public async Task<City[]> ListAsync(CityQuery query = null,
          CancellationToken? cancellationToken = null)
        {
            return (await Api.MakeXmlRequestAsync<CityResponse>(HttpMethod.Get,
              "/cities", cancellationToken, query)).Cities;
        }
    }

    public class CityQuery
    {
        public string State { get; set; }
        public bool? Supported { get; set; }
        public bool? Available { get; set; }
    }

    public class City
    {
        public string RcAbbreviation { get; set; }
        public string Name { get; set; }
    }

    public class CityResponse
    {
        public City[] Cities { get; set; }
    }
}
