using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Account Api (IRIS)
  /// </summary>
  public interface IAccount
  {
    /// <summary>
    ///   Get information about account (IRIS)
    /// </summary>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Task with <see cref="Account" /> Account instance</returns>
    /// <example>
    ///   <code>
    /// var account = await client.IrisAccount.GetAsync();
    /// </code>
    /// </example>
    Task<Account> GetAsync(CancellationToken? cancellationToken = null);
  }

  internal class AccountApi : ApiBase, IAccount
  {
    public async Task<Account> GetAsync(CancellationToken? cancellationToken = null)
    {
      return (await Api.MakeXmlRequestAsync<IrisAccountResponse>(HttpMethod.Get, $"/accounts/{Api.AccountId}", cancellationToken)).Account;
    }
  }

  /// <summary>
  /// Account
  /// </summary>
  public class Account
  {
    /// <summary>
    /// Id
    /// </summary>
    public string Id
    {
      get { return AccountId; }
      set { AccountId = value; }
    }

    /// <summary>
    /// AccountId
    /// </summary>
    public string AccountId { get; set; }

    /// <summary>
    /// CompanyName
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// AccountType
    /// </summary>
    public string AccountType { get; set; }

    /// <summary>
    /// NenaId
    /// </summary>
    public string NenaId { get; set; }

    /// <summary>
    /// Tiers
    /// </summary>
    [XmlArrayItem("Tier")]
    public int[] Tiers { get; set; }

    /// <summary>
    /// ReservationAllowed
    /// </summary>
    public bool ReservationAllowed { get; set; }

    /// <summary>
    /// LnpEnabled
    /// </summary>
    public bool LnpEnabled { get; set; }

    /// <summary>
    /// AltSpid
    /// </summary>
    public string AltSpid { get; set; }

    /// <summary>
    /// Spid
    /// </summary>
    [XmlElement("SPID")]
    public string Spid { get; set; }

    /// <summary>
    /// PortCarrierType
    /// </summary>
    public string PortCarrierType { get; set; }

    /// <summary>
    /// Contact
    /// </summary>
    public Contact Contact { get; set; }

    /// <summary>
    /// Address
    /// </summary>
    public Address Address { get; set; }
  }

  /// <summary>
  /// AccountResponse
  /// </summary>
  [XmlType("AccountResponse")]
  public class IrisAccountResponse
  {
    /// <summary>
    /// Account
    /// </summary>
    public Account Account { get; set; }
  }

  /// <summary>
  /// Contact
  /// </summary>
  public class Contact
  {
    /// <summary>
    /// FirstName
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Phone
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
  }

  /// <summary>
  /// Address
  /// </summary>
  public class Address
  {
    /// <summary>
    /// HouseNumber
    /// </summary>
    public string HouseNumber { get; set; }

    /// <summary>
    /// HouseSuffix
    /// </summary>
    public string HouseSuffix { get; set; }

    /// <summary>
    /// StreetName
    /// </summary>
    public string StreetName { get; set; }

    /// <summary>
    /// StreetSuffix
    /// </summary>
    public string StreetSuffix { get; set; }

    /// <summary>
    /// AddressLine2
    /// </summary>
    public string AddressLine2 { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// StateCode
    /// </summary>
    public string StateCode { get; set; }

    /// <summary>
    /// Zip
    /// </summary>
    public string Zip { get; set; }

    /// <summary>
    /// Country
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// AddressType
    /// </summary>
    public string AddressType { get; set; }
  }
}
