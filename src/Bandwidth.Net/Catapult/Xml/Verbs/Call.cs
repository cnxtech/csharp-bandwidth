using System.ComponentModel;
using System.Xml.Serialization;

namespace Bandwidth.Net.Catapult.Xml.Verbs
{
  /// <summary>
  ///   The Call verb is used to create call to another number.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/call/" />
  public class Call : IVerb
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    public Call()
    {
      RequestUrlTimeout = 30000;
      Timeout = 30;
    }

    /// <summary>
    ///   Defines the number the call will be created from.
    /// </summary>
    [XmlAttribute("from")]
    public string From { get; set; }

    /// <summary>
    ///   Defines the number the call will be called to.
    /// </summary>
    [XmlAttribute("to")]
    public string To { get; set; }

    /// <summary>
    ///   This is the timeout (seconds) for the call to answer
    /// </summary>
    [XmlAttribute("timeout")]
    public int Timeout { get; set; }

    /// <summary>
    ///   Integer time in milliseconds to wait for requestUrl response
    /// </summary>
    [XmlAttribute("requestUrlTimeout"), DefaultValue(30000)]
    public int RequestUrlTimeout { get; set; }

    /// <summary>
    ///   Relative or absolute URL to send event and request new BXML document when call is answered or call is hung up.
    /// </summary>
    [XmlAttribute("requestUrl")]
    public string RequestUrl { get; set; }

    /// <summary>
    ///   A collection of phone numbers to transfer the call to.
    /// </summary>
    [XmlElement("PhoneNumber")]
    public string[] PhoneNumbers { get; set; }


    /// <summary>
    ///   Additional data for the call
    /// </summary>
    [XmlAttribute("tag")]
    public string Tag { get; set; }

    /// <summary>
    ///   PlayAudio sub-verb
    /// </summary>
    public PlayAudio PlayAudio { get; set; }

    /// <summary>
    ///   Record sub-verb
    /// </summary>
    public Record Record { get; set; }

    /// <summary>
    ///   SpeakSentence sub-verb
    /// </summary>
    public SpeakSentence SpeakSentence { get; set; }
  }
}
