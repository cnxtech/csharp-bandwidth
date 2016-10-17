using System;
using System.Collections.Generic;
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

    /// <summary>
    /// BandwidthException
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="code">Status code</param>
    public BandwidthException(string message, IDictionary<string, string> additionalData, HttpStatusCode code) : this(message, code)
    {
      foreach (var item in additionalData)
      {
        AdditionalData[item.Key] = item.Value;
      }
    }

    /// <summary>
    /// Additional data of exception
    /// </summary>
    public readonly Dictionary<string, string> AdditionalData = new Dictionary<string, string>();
  }
}
