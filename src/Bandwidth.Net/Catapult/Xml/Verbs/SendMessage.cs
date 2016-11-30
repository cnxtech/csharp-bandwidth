using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bandwidth.Net.Catapult.Xml.Verbs
{
  /// <summary>
  ///   The SendMessage is used to send a text message.
  /// </summary>
  /// <seealso href="http://ap.bandwidth.com/docs/xml/message/" />
  public class SendMessage : IXmlSerializable, IVerb
  {
    /// <summary>
    ///   Default constructor
    /// </summary>
    public SendMessage()
    {
      RequestUrlTimeout = 30;
    }

    /// <summary>
    ///   The number from the message will be sent
    /// </summary>
    public string From { get; set; }

    /// <summary>
    ///   The number to send the message to
    /// </summary>
    public string To { get; set; }

    /// <summary>
    ///   Relative or absolute URL to send event and request new BaML
    /// </summary>
    public string RequestUrl { get; set; }

    /// <summary>
    ///   Integer time seconds to wait for requestUrl response
    /// </summary>
    public int RequestUrlTimeout { get; set; }

    /// <summary>
    ///   Relative or absolute URL to send the message callback
    /// </summary>
    public string StatusCallbackUrl { get; set; }

    /// <summary>
    ///   Text to send
    /// </summary>
    public string Text { get; set; }


    XmlSchema IXmlSerializable.GetSchema()
    {
      return null;
    }

    void IXmlSerializable.ReadXml(XmlReader reader)
    {
      throw new NotImplementedException();
    }

    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("from", From);
      writer.WriteAttributeString("to", To);
      if (!string.IsNullOrEmpty(RequestUrl))
      {
        writer.WriteAttributeString("requestUrl", RequestUrl);
      }
      if (RequestUrlTimeout != 30)
      {
        writer.WriteAttributeString("requestUrlTimeout", RequestUrlTimeout.ToString(CultureInfo.InvariantCulture));
      }
      if (!string.IsNullOrEmpty(StatusCallbackUrl))
      {
        writer.WriteAttributeString("statusCallbackUrl", StatusCallbackUrl);
      }
      writer.WriteString(Text);
    }
  }
}
