using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to LineOptionOrder Api (IRIS)
  /// </summary>
  public interface ILineOptionOrder
  {
    /// <summary>
    ///   Create 1 or more line options orders
    /// </summary>
    /// <param name="options">orders data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of phone numbers</returns>
    /// <example>
    /// <code>
    /// var list = await client.LineOptionOrder.CreateAsync(new[]{new TnLineOptions{TelephoneNumber = "+1234567890"}});
    /// </code>
    /// </example>
    Task<string[]> CreateAsync(TnLineOptions[] options, CancellationToken? cancellationToken = null);
  }


  internal class LineOptionOrderApi : ApiBase, ILineOptionOrder
  {
    public async Task<string[]> CreateAsync(TnLineOptions[] options, CancellationToken? cancellationToken = null)
    {
      var data = new LineOptionOrderRequest
      {
        TnLineOptions = options
      };
      return
        (await
          Api.MakeXmlRequestAsync<LineOptionOrderResponse>(HttpMethod.Post, $"/accounts/{Api.AccountId}/lineOptionOrders",
            cancellationToken, null, data))
          .LineOptions.CompletedNumbers;
    }
  }

  /// <summary>
  ///   TnLineOptions
  /// </summary>
  public class TnLineOptions
  {
    /// <summary>
    ///   TelephoneNumber
    /// </summary>
    public string TelephoneNumber { get; set; }

    /// <summary>
    ///   CallingNameDisplay
    /// </summary>
    public string CallingNameDisplay { get; set; }
  }

  /// <summary>
  ///   LineOptionOrderRequest
  /// </summary>
  [XmlRoot("LineOptionOrder")]
  public class LineOptionOrderRequest
  {
    /// <summary>
    ///   TnLineOptions
    /// </summary>
    [XmlElement("TnLineOptions")]
    public TnLineOptions[] TnLineOptions { get; set; }
  }

  /// <summary>
  ///   LineOptionOrderResponse
  /// </summary>
  public class LineOptionOrderResponse
  {
    /// <summary>
    ///   LineOptions
    /// </summary>
    public LineOptions LineOptions { get; set; }
  }

  /// <summary>
  ///   LineOptions
  /// </summary>
  public class LineOptions
  {
    /// <summary>
    ///   CompletedNumbers
    /// </summary>
    [XmlArrayItem("TelephoneNumber")]
    public string[] CompletedNumbers { get; set; }
  }
}
