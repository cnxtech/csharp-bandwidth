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
  public class BandwidthException : Exception
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

  /// <summary>
  /// RateLimitException
  /// </summary>
  public class RateLimitException : BandwidthException
  {

    /// <summary>
    /// Time after which your rate limit should be cleared
    /// </summary>
    public DateTime ResetTime { get; private set; }

    /// <summary>
    /// RateLimitException
    /// </summary>
    /// <param name="resetTime">Time after which your rate limit should be cleared</param>
    public RateLimitException(DateTime resetTime): base("Too Many Requests", (HttpStatusCode)429)
    {
      ResetTime = resetTime;
    }
  }
}
