using System;
using System.Xml.Serialization;

namespace Bandwidth.Net.Xml.Verbs
{
  /// <summary>
  ///   The Reject verb is used to reject incoming calls
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/reject/" />
  [Obsolete("This verb was removed in BXMLv2")]
  public class Reject : IVerb
  {
    /// <summary>
    ///   Describe the reason for rejecting the call (busy or rejected to play different tones to the caller)
    /// </summary>
    [XmlAttribute("reason")]
    public string Reason { get; set; }
  }
}
