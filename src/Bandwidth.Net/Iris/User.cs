using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to User Api (IRIS)
  /// </summary>
  public interface IUser
  {
    /// <summary>
    ///   Get a user data
    /// </summary>
    /// <param name="id">User Id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>User data</returns>
    /// <example>
    ///   <code>
    /// var user = await client.User.GetAsync("id");
    /// </code>
    /// </example>
    Task<User> GetAsync(string id, CancellationToken? cancellationToken = null);


    /// <summary>
    ///   Change password of user
    /// </summary>
    /// <param name="id">User Id</param>
    /// <param name="newPassword">New password</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <example>
    ///   <code>
    /// await client.User.ChangePasswordAsync("id", "newPassword", new User{Name= "my user"});
    /// </code>
    /// </example>
    Task ChangePasswordAsync(string id, string newPassword, CancellationToken? cancellationToken = null);
  }

  /// <summary>
  ///   User
  /// </summary>
  public class User
  {
    /// <summary>
    ///   User name
    /// </summary>
    [XmlElement("Username")]
    public string UserName { get; set; }

    /// <summary>
    ///   First name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///   Last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///   Email address
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    ///   Telephone number
    /// </summary>
    public string TelephoneNumber { get; set; }

    /// <summary>
    ///   Roles
    /// </summary>
    public Role[] Roles { get; set; }

    /// <summary>
    ///   Accounts
    /// </summary>
    public Account[] Accounts { get; set; }
  }

  /// <summary>
  /// UserResponse
  /// </summary>
  public class UserResponse
  {
    /// <summary>
    /// User
    /// </summary>
    public User User { get; set; }
  }

  /// <summary>
  /// Role
  /// </summary>
  public class Role
  {
    /// <summary>
    /// RoleName
    /// </summary>
    public string RoleName { get; set; }

    /// <summary>
    /// Permissions
    /// </summary>
    public Permission[] Permissions { get; set; }
  }

  /// <summary>
  /// Permission
  /// </summary>
  public class Permission
  {
    /// <summary>
    /// Name
    /// </summary>
    [XmlElement("PermissionName")]
    public string Name { get; set; }
  }

  /// <summary>
  /// Password
  /// </summary>
  public sealed class Password : IXmlSerializable
  {
    /// <summary>
    /// Password value
    /// </summary>
    public string Value { get; set; }

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
      writer.WriteString(Value);
    }
  }


  internal class UserApi : ApiBase, IUser
  {
    public async Task<User> GetAsync(string id, CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<UserResponse>(HttpMethod.Get, $"/users/{id}",
        cancellationToken)).User;
    }

    public Task ChangePasswordAsync(string id, string newPassword, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Put, $"/users/{id}/password",
        cancellationToken, null, new Password {Value = newPassword});
    }
  }
}
