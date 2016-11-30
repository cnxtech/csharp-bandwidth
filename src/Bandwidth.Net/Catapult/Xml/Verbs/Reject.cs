using System.Xml.Serialization;

namespace Bandwidth.Net.Catapult.Xml.Verbs
{
  /// <summary>
  ///   The Reject verb is used to reject incoming calls
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/reject/" />
  public class Reject : IVerb
  {
    /// <summary>
    ///   Describe the reason for rejecting the call (busy or rejected to play different tones to the caller)
    /// </summary>
    [XmlAttribute("reason")]
    public string Reason { get; set; }
  }
}
