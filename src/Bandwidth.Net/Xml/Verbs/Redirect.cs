using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Bandwidth.Net.Xml.Verbs
{
  /// <summary>
  ///   The Redirect verb is used to redirect the current XML execution to another URL.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/redirect/" />
  [Obsolete("Use verb from namspace Bandwidth.Net.XmlV2.Verbs")]
  public class Redirect : IVerb
  {
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
    ///   Specify any call Id or message Id where the redirect will be applied to.
    /// </summary>
    [XmlAttribute("context")]
    public string Context { get; set; }
  }
}
