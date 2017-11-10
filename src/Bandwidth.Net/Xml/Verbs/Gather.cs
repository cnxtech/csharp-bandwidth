using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Bandwidth.Net.Xml.Verbs
{
  /// <summary>
  ///   The Gather verb is used to collect digits for some period of time.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/gather/" />
  [Obsolete("Use verb from namspace Bandwidth.Net.XmlV2.Verbs")]
  public class Gather : IVerb
  {
    /// <summary>
    ///   Constructor
    /// </summary>
    public Gather()
    {
      RequestUrlTimeout = 30000;
      TerminatingDigits = "#";
      MaxDigits = 128;
      InterDigitTimeout = 5;
      Bargeable = true;
    }

    /// <summary>
    ///   Relative or absolute URL to send event to and request
    /// </summary>
    [XmlAttribute("requestUrl")]
    public string RequestUrl { get; set; }

    /// <summary>
    ///   Integer time in milliseconds to wait for requestUrl response
    /// </summary>
    [XmlAttribute("requestUrlTimeout"), DefaultValue(30000)]
    public int RequestUrlTimeout { get; set; }

    /// <summary>
    ///   Digits to stop gather
    /// </summary>
    [XmlAttribute("terminatingDigits"), DefaultValue("#")]
    public string TerminatingDigits { get; set; }

    /// <summary>
    ///   Quantity of digits to collect
    /// </summary>
    [XmlAttribute("maxDigits"), DefaultValue(128)]
    public int MaxDigits { get; set; }

    /// <summary>
    ///   Integer time indicating the timeout between digits
    /// </summary>
    [XmlAttribute("interDigitTimeout"), DefaultValue(5)]
    public int InterDigitTimeout { get; set; }

    /// <summary>
    ///   Boolean to indicate if audio playback should be stopped when digit is pressed
    /// </summary>
    [XmlAttribute("bargeable"), DefaultValue(true)]
    public bool Bargeable { get; set; }

    /// <summary>
    ///  Using the SpeakSentence inside the Gather verb will speak the text to the callee.
    /// </summary>
    public SpeakSentence SpeakSentence { get; set; }

    /// <summary>
    /// Using the PlayAudio inside the Gather verb will play the media to the callee.
    /// </summary>
    public PlayAudio PlayAudio { get; set; }
  }
}
