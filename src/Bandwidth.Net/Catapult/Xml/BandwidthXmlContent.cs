using System.Net.Http;
using System.Text;

namespace Bandwidth.Net.Catapult.Xml
{
  /// <summary>
  ///   BandwidthXML content for HttpResponseMessage
  /// </summary>
  /// <example>
  ///   <code>
  ///  var response = new HttpResponseMessage();
  ///  response.Content = new BandwidthXmlContent(new Response( new Hangup() )); // will generate next xml lines 
  ///  /*
  ///  <Response>
  ///       <Hangup></Hangup>
  ///     </Response>
  ///  */
  ///  </code>
  /// </example>
  public class BandwidthXmlContent : StringContent
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="bxmlResponse">BXML response object</param>
    public BandwidthXmlContent(Response bxmlResponse) : base(bxmlResponse.ToXml(), Encoding.UTF8, "text/xml")
    {
    }
  }
}
