using System.ComponentModel;
using System.Xml.Serialization;
using Bandwidth.Net.Xml;

namespace Bandwidth.Net.XmlV2.Verbs
{
  /// <summary>
  ///   The Record verb allow call recording.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/record/" />
  public class Record : IVerb
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Record()
    {
      MaxDuration = 60;
      SilenceThreshold = 100;
      SilenceTimeout = 3;
    }

    /// <summary>
    ///   Relative or absolute URL to send event and request new BaML
    /// </summary>
    [XmlAttribute("requestUrl")]
    public string RequestUrl { get; set; }

    /// <summary>
    ///   The time in milliseconds to wait for requestUrl response
    /// </summary>
    [XmlAttribute("requestUrlTimeout"), DefaultValue(0)]
    public int RequestUrlTimeout { get; set; }

    /// <summary>
    ///   The format that the recording will be saved - mp3 or wav.
    /// </summary>
    [XmlAttribute("fileFormat")]
    public string FileFormat { get; set; }


    /// <summary>
    ///   A boolean value to indicate that recording must be transcribed
    /// </summary>
    [XmlAttribute("transcribe")]
    public bool Transcribe { get; set; }

    /// <summary>
    ///   Relative or absolute URL to send transcribed event
    /// </summary>
    [XmlAttribute("transcribeCallbackUrl")]
    public string TranscribeCallbackUrl { get; set; }

    /// <summary>
    /// Record the caller and called party voices on 2 separate channels in the same file
    /// </summary>
    [XmlAttribute("multiChannel")]
    public bool MultiChannel { get; set; }

    /// <summary>
    /// Number of seconds to record the caller’s voice
    /// </summary>
    [XmlAttribute("maxDuration"), DefaultValue(60)]
    public int MaxDuration { get; set; }

    /// <summary>
    /// Number of seconds of silence detected before ending the recording.
    /// </summary>
    [XmlAttribute("silenceTimeout"), DefaultValue(3)]
    public int SilenceTimeout { get; set; }

    /// <summary>
    /// This setting controls when the silence timeout is effective. Set this number higher in noisy environments to detect voice and “silence”. 
    /// </summary>
    [XmlAttribute("silenceThreshold"), DefaultValue(100)]
    public int SilenceThreshold { get; set; }

    /// <summary>
    /// Digit that the caller presses to indicate that the recording can be stopped. It can be any one of 0-9*#. 
    /// </summary>
    [XmlAttribute("terminatingDigits")]
    public string TerminatingDigits { get; set; }
  }
}
