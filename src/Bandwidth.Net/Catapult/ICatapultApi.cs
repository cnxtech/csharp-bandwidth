namespace Bandwidth.Net.Catapult
{
  /// <summary>
  ///   Catapult Api interface
  /// </summary>
  public interface ICatapultApi
  {
    /// <summary>
    ///   Access to Error Api
    /// </summary>
    IError Error { get; }

    /// <summary>
    ///   Access to Account Api
    /// </summary>
    IAccount Account { get; }

    /// <summary>
    ///   Access to Application Api
    /// </summary>
    IApplication Application { get; }

    /// <summary>
    ///   Access to AvailableNumber Api
    /// </summary>
    IAvailableNumber AvailableNumber { get; }

    /// <summary>
    ///   Access to Bridge Api
    /// </summary>
    IBridge Bridge { get; }

    /// <summary>
    ///   Access to Domain Api
    /// </summary>
    IDomain Domain { get; }

    /// <summary>
    ///   Access to Call Api
    /// </summary>
    ICall Call { get; }

    /// <summary>
    ///   Access to Conference Api
    /// </summary>
    IConference Conference { get; }

    /// <summary>
    ///   Access to Message Api
    /// </summary>
    IMessage Message { get; }

    /// <summary>
    ///   Access to NumberInfo Api
    /// </summary>
    INumberInfo NumberInfo { get; }

    /// <summary>
    ///   Access to PhoneNumber Api
    /// </summary>
    IPhoneNumber PhoneNumber { get; }

    /// <summary>
    ///   Access to Recording Api
    /// </summary>
    IRecording Recording { get; }

    /// <summary>
    ///   Access to Transcription Api
    /// </summary>
    ITranscription Transcription { get; }

    /// <summary>
    ///   Access to Media Api
    /// </summary>
    IMedia Media { get; }

    /// <summary>
    ///   Access to Endpoint Api
    /// </summary>
    IEndpoint Endpoint { get; }
  }

  /// <summary>
  ///   Auth data for Catapult Api
  /// </summary>
  public class CatapultAuthData
  {
    /// <summary>
    ///   User ID (not your user name)
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    ///   Api Token
    /// </summary>
    public string ApiToken { get; set; }

    /// <summary>
    ///   Api Secret
    /// </summary>
    public string ApiSecret { get; set; }

    /// <summary>
    ///   Optional base url of catapult services
    /// </summary>
    public string BaseUrl { get; set; } = "https://api.catapult.inetwork.com/v1";
  }
}