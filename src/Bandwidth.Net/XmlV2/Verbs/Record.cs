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
    ///   Constructor
    /// </summary>
    public Record()
    {
      MaxDuration = 300;
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
  }
}
