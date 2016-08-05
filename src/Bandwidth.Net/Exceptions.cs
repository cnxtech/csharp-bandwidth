using System;
using System.Net;

namespace Bandwidth.Net
{
  /// <summary>
  /// MissingCredentialsException
  /// </summary>
  public sealed class MissingCredentialsException : Exception
  {

    /// <summary>
    /// MissingCredentialsException
    /// </summary>
    public MissingCredentialsException()
        : base("Missing credentials.\n" +
        "Use new Client(<userId>, <apiToken>, <apiSecret>) to set up them.")
    {
    }
  }

  /// <summary>
  /// BandwidthException
  /// </summary>
  public sealed class BandwidthException : Exception
  {
    /// <summary>
    /// Status code
    /// </summary>
    public HttpStatusCode Code { get; private set; }

    /// <summary>
    /// BandwidthException
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="code">Status code</param>
    public BandwidthException(string message, HttpStatusCode code) : base(message)
    {
      Code = code;
    }
  }
}
