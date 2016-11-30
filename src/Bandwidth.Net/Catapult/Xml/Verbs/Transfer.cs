using System.ComponentModel;
using System.Xml.Serialization;

namespace Bandwidth.Net.Catapult.Xml.Verbs
{
  /// <summary>
  ///   The Transfer verb is used to transfer the call to another number.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/transfer/" />
  public class Transfer : IVerb
  {
    /// <summary>
    ///   Defines the number the call will be transferred to
    /// </summary>
    [XmlAttribute("transferTo")]
    public string TransferTo { get; set; }

    /// <summary>
    ///   This is the caller id that will be used when the call is transferred.
    /// </summary>
    [XmlAttribute("transferCallerId")]
    public string TransferCallerId { get; set; }

    /// <summary>
    ///   Relative or absolute URL to send event and request new BaML when transferred call hangs up.
    /// </summary>
    [XmlAttribute("requestUrl")]
    public string RequestUrl { get; set; }

    /// <summary>
    ///   Timeout (milliseconds) to request new BaML.
    /// </summary>
    [XmlAttribute("requestUrlTimeout"), DefaultValue(0)]
    public int RequestUrlTimeout { get; set; }


    /// <summary>
    ///   A string that will be included in the callback events of the conference
    /// </summary>
    [XmlAttribute("tag")]
    public string Tag { get; set; }

    /// <summary>
    ///   This is the timeout (seconds) for the callee to answer the call.
    /// </summary>
    [XmlAttribute("callTimeout"), DefaultValue(0)]
    public int CallTimeout { get; set; }

    /// <summary>
    ///   This will speak the text into the call before transferring it.
    /// </summary>
    public SpeakSentence SpeakSentence { get; set; }

    /// <summary>
    ///   Using the PlayAudio inside the Transfer verb will play the media to the callee before transferring it.
    /// </summary>
    public PlayAudio PlayAudio { get; set; }

    /// <summary>
    ///   Using Record inside Transfer verb will record the transferred call.
    /// </summary>
    public Record Record { get; set; }

    /// <summary>
    ///   A collection of phone numbers to transfer the call to. The first to answer will be transferred.
    /// </summary>
    [XmlElement("PhoneNumber")]
    public string[] PhoneNumbers { get; set; }
  }
}
