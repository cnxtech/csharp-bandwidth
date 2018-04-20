using System.ComponentModel;
using System.Xml.Serialization;
using Bandwidth.Net.Xml;

namespace Bandwidth.Net.XmlV2.Verbs
{
  /// <summary>
  ///   Pause the execution of an ongoing BXML document
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/pause/" />
  public class Pause : IVerb
  {
    /// <summary>
    ///  How many seconds Bandwidth will wait silently before continuing on.
    /// </summary>
    [XmlAttribute("length")]
    public int Length { get; set; }
  }
}
