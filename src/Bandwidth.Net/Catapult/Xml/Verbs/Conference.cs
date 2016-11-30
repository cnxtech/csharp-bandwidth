using System.Xml.Serialization;

namespace Bandwidth.Net.Catapult.Xml.Verbs
{
  /// <summary>
  ///   The Conference verb is used to create conferences.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/conference/" />
  public class Conference : IVerb
  {
    /// <summary>
    ///   The phone number that will host the conference.
    /// </summary>
    [XmlAttribute("from")]
    public string From { get; set; }

    /// <summary>
    ///   URL where the events related to the Conference will be sent through POST.
    /// </summary>
    [XmlAttribute("statusCallbackUrl")]
    public string StatusCallbackUrl { get; set; }

    /// <summary>
    ///   If "true", will play a tone when the member joins the conference. If "false", no tone is played when the member joins
    ///   the conference.
    /// </summary>
    [XmlAttribute("joinTone")]
    public bool JoinTone { get; set; }

    /// <summary>
    ///   If "true", will play a tone when the member leaves the conference. If "false", no tone is played when the member
    ///   leaves the conference.
    /// </summary>
    [XmlAttribute("leavingTone")]
    public bool LeavingTone { get; set; }

    /// <summary>
    ///   If "true", the member will join in mute and will be able to hear unmuted participants.
    /// </summary>
    [XmlAttribute("mute")]
    public bool Mute { get; set; }

    /// <summary>
    ///   If "true", the member will join in hold.
    /// </summary>
    [XmlAttribute("hold")]
    public bool Hold { get; set; }

    /// <summary>
    ///   A string that will be included in the callback events of the conference.
    /// </summary>
    [XmlAttribute("tag")]
    public string Tag { get; set; }
  }
}
