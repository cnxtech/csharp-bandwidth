using System.Xml.Serialization;

namespace Bandwidth.Net.Catapult.Xml.Verbs
{
  /// <summary>
  ///   Pause is a verb to specify the length of seconds to wait before executing the next verb.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/pause/" />
  public class Pause : IVerb
  {
    /// <summary>
    ///   Seconds to wait before continuing the execution
    /// </summary>
    [XmlAttribute("duration")]
    public int Duration { get; set; }
  }
}
