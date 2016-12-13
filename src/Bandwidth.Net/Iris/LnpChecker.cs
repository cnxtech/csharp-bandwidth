using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to LnpChecker Api (IRIS)
  /// </summary>
  public interface ILnpChecker
  {
    /// <summary>
    ///   The lnpchecker resource performs a portability analysis for a set ot TNs
    /// </summary>
    /// <param name="numbers">Phone numbers to check</param>
    /// <param name="fullCheck">
    ///   If true additional information will be provided on the losing carriers associated with the
    ///   listed numbers
    /// </param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Protability report</returns>
    /// <example>
    /// <code>
    /// var response = await client.LnpChecker.CheckAsync(new[]{"+1234567980"}, true);
    /// </code>
    /// </example>
    Task<NumberPortabilityResponse> CheckAsync(string[] numbers, bool fullCheck = false,
      CancellationToken? cancellationToken = null);
  }


  internal class LnpCheckerApi : ApiBase, ILnpChecker
  {
    public Task<NumberPortabilityResponse> CheckAsync(string[] numbers, bool fullCheck = false,
      CancellationToken? cancellationToken = null)
    {
      var data = new NumberPortabilityRequest
      {
        TnList = numbers
      };
      return Api.MakeXmlRequestAsync<NumberPortabilityResponse>(HttpMethod.Post, $"/accounts/{Api.AccountId}/lnpchecker",
        cancellationToken, new {FullCheck = fullCheck.ToString().ToLowerInvariant()}, data);
    }
  }

  /// <summary>
  /// NumberPortabilityResponse
  /// </summary>
  public class NumberPortabilityResponse
  {
    /// <summary>
    /// SupportedRateCenters
    /// </summary>
    public RateCenterGroup[] SupportedRateCenters { get; set; }

    /// <summary>
    /// UnsupportedRateCenters
    /// </summary>
    public RateCenterGroup[] UnsupportedRateCenters { get; set; }

    /// <summary>
    /// PartnerSupportedRateCenters
    /// </summary>
    public RateCenterGroup[] PartnerSupportedRateCenters { get; set; }

    /// <summary>
    /// PortableNumbers
    /// </summary>
    [XmlArrayItem("Tn")]
    public string[] PortableNumbers { get; set; }

    /// <summary>
    /// SupportedLosingCarriers
    /// </summary>
    public LosingCarriers SupportedLosingCarriers { get; set; }

    /// <summary>
    /// UnsupportedLosingCarriers
    /// </summary>
    public LosingCarriers UnsupportedLosingCarriers { get; set; }
  }

  /// <summary>
  /// LosingCarriers
  /// </summary>
  public class LosingCarriers
  {
    /// <summary>
    /// LosingCarrierTnList
    /// </summary>
    public LosingCarrierTnList LosingCarrierTnList { get; set; }
  }

  /// <summary>
  /// LosingCarrierTnList
  /// </summary>
  public class LosingCarrierTnList
  {
    /// <summary>
    /// LosingCarrierSpid
    /// </summary>
    [XmlElement("LosingCarrierSPID")]
    public string LosingCarrierSpid { get; set; }

    /// <summary>
    /// LosingCarrierName
    /// </summary>
    public string LosingCarrierName { get; set; }

    /// <summary>
    /// TnList
    /// </summary>
    [XmlArrayItem("Tn")]
    public string[] TnList { get; set; }
  }

  /// <summary>
  /// RateCenterGroup
  /// </summary>
  public class RateCenterGroup
  {
    /// <summary>
    /// RateCenter
    /// </summary>
    public string RateCenter { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// State
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Lata
    /// </summary>
    [XmlElement("LATA")]
    public string Lata { get; set; }

    /// <summary>
    /// Tiers
    /// </summary>
    [XmlArrayItem("Tier")]
    public string[] Tiers { get; set; }


    /// <summary>
    /// TnList
    /// </summary>
    [XmlArrayItem("Tn")]
    public string[] TnList { get; set; }
  }

  /// <summary>
  /// NumberPortabilityRequest
  /// </summary>
  public class NumberPortabilityRequest
  {
    /// <summary>
    /// TnList
    /// </summary>
    [XmlArrayItem("Tn")]
    public string[] TnList { get; set; }
  }
}
