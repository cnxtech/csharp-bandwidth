using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Host Api (IRIS)
  /// </summary>
  public interface IHost
  {
    /// <summary>
    ///   Get information about hosts
    /// </summary>
    /// <param name="query">Optional query</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of hosts data</returns>
    Task<SiteHost[]> ListAsync(CityQuery query = null, CancellationToken? cancellationToken = null);
  }

  internal class HostApi : ApiBase, IHost
  {
    public async Task<SiteHost[]> ListAsync(CityQuery query = null,
      CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<SiteHostsResponse>(HttpMethod.Get,
        $"/accounts/{Api.AccountId}/hosts", cancellationToken, query)).SiteHosts;
    }
  }

  /// <summary>
  /// SiteHostsResponse
  /// </summary>
  public class SiteHostsResponse
  {
    /// <summary>
    /// SiteHosts
    /// </summary>
    public SiteHost[] SiteHosts { get; set; }
  }

  /// <summary>
  /// SiteHost
  /// </summary>
  public class SiteHost
  {
    /// <summary>
    /// SiteId
    /// </summary>
    public string SiteId { get; set; }

    /// <summary>
    /// SipPeerHosts
    /// </summary>
    public SipPeerHost[] SipPeerHosts { get; set; }
  }

  /// <summary>
  /// SipPeerHost
  /// </summary>
  public class SipPeerHost
  {
    /// <summary>
    /// SipPeerId
    /// </summary>
    public string SipPeerId { get; set; }

    /// <summary>
    /// VoiceHosts
    /// </summary>
    [XmlArrayItem("Host")]
    public HostData[] VoiceHosts { get; set; }

    /// <summary>
    /// SmsHosts
    /// </summary>
    [XmlArrayItem("Host")]
    public HostData[] SmsHosts { get; set; }

    /// <summary>
    /// TerminationHosts
    /// </summary>
    [XmlArrayItem("Host")]
    public HostData[] TerminationHosts { get; set; }
  }

  /// <summary>
  /// HostData
  /// </summary>
  public class HostData
  {
    /// <summary>
    /// HostName
    /// </summary>
    public string HostName { get; set; }

    /// <summary>
    /// Port
    /// </summary>
    public int Port { get; set; }
  }
}
