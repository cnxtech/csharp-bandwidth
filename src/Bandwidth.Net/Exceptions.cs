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
  /// InvalidBaseUrlException
  /// </summary>
  public sealed class InvalidBaseUrlException : Exception
  {

    /// <summary>
    /// InvalidBaseUrlException
    /// </summary>
    public InvalidBaseUrlException()
        : base("Base url should be non-empty string")
    {
    } 
  }

  /// <summary>
  /// BandwidthException
  /// </summary>
  public sealed class BandwidthException : Exception
  {
    public HttpStatusCode Code { get; private set; }

    /// <summary>
    /// BandwidthException
    /// </summary>
    public BandwidthException(string message, HttpStatusCode code) : base(message)
    {
      Code = code;
    }
  }
}
