﻿using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Bandwidth.Net.Iris
{
  /// <summary>
  ///   Access to Portin Api (IRIS)
  /// </summary>
  public interface IPortin
  {
    /// <summary>
    ///   Create a portin order
    /// </summary>
    /// <param name="data">data of new Portin order</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Order response</returns>
    Task<LnpOrderResponse> CreateAsync(Portin data, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Add note to the order
    /// </summary>
    /// <param name="id">Portin Id</param>
    /// <param name="note">Note data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Id of created note</returns>
    Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null);

    /// <summary>
    ///   Return list of notes of the order
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Array of notes</returns>
    Task<Note[]> GetNotesAsync(string id, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Upload file to an order
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="stream">stream with content to upload</param>
    /// <param name="mediaType">media type of uploaded data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>file name on the server</returns>
    Task<string> CreateFileAsync(string id, Stream stream, string mediaType, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Upload file to an order
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="buffer">byte buffer with content to upload</param>
    /// <param name="mediaType">media type of uploaded data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>file name on the server</returns>
    Task<string> CreateFileAsync(string id, byte[] buffer, string mediaType, CancellationToken? cancellationToken = null);

#if !WithoutFileIO
    /// <summary>
    /// Upload file to an order
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="filePath">path to file to upload</param>
    /// <param name="mediaType">media type of uploaded data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>file name on the server</returns>
    Task<string> CreateFileAsync(string id, string filePath, string mediaType,
      CancellationToken? cancellationToken = null);
#endif

    /// <summary>
    /// Replace file on the server
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="fileName">Name of file to replace</param>
    /// <param name="stream">stream with new data</param>
    /// <param name="mediaType">media type of uploaded data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Task instance</returns>
    Task UpdateFileAsync(string id, string fileName, Stream stream, string mediaType,
      CancellationToken? cancellationToken = null);

    /// <summary>
    /// Replace file on the server
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="fileName">Name of file to replace</param>
    /// <param name="buffer">new data as byte array</param>
    /// <param name="mediaType">media type of uploaded data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Task instance</returns>
    Task UpdateFileAsync(string id, string fileName, byte[] buffer, string mediaType,
      CancellationToken? cancellationToken = null);

#if !WithoutFileIO
    /// <summary>
    /// Replace file on the server
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="fileName">Name of file to replace</param>
    /// <param name="filePath">path to file to upload</param>
    /// <param name="mediaType">media type of uploaded data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Task instance</returns>
    Task UpdateFileAsync(string id, string fileName, string filePath, string mediaType,
      CancellationToken? cancellationToken = null);
#endif

    /// <summary>
    /// Get information about file
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="fileName">File name on the server</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns></returns>
    Task<FileMetadata> GetFileMetadataAsync(string id, string fileName, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Remove an portin order
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="fileName">File name on the server</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Async task</returns>
    Task DeleteFileAsync(string id, string fileName, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Get list of files of the order on the server
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="metadata">if true files metadata will be returned too</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>List of files</returns>
    Task<FileData[]> GetFilesAsync(string id, bool metadata = false, CancellationToken? cancellationToken = null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="fileName">File name on the server</param>
    /// <param name="asStream">if true file content will be returned as Stream object, otherwise as byte array</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>File content</returns>
    Task<FileContent> GetFileAsync(string id, string fileName, bool asStream = false,
      CancellationToken? cancellationToken = null);

    /// <summary>
    /// Change portin data
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="data">Changed data</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Async task</returns>
    Task UpdateAsync(string id, LnpOrderSupp data, CancellationToken? cancellationToken = null);

    /// <summary>
    /// Remove a portin order
    /// </summary>
    /// <param name="id">Portin id</param>
    /// <param name="cancellationToken">Optional token to cancel async operation</param>
    /// <returns>Async task</returns>
    Task DeleteAsync(string id, CancellationToken? cancellationToken = null);
  }

  /// <summary>
  /// Portin
  /// </summary>
  [XmlType("LnpOrder")]
  public class Portin
  {
    /// <summary>
    /// Id
    /// </summary>
    public string Id => OrderId;

    /// <summary>
    /// OrderId
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// BillingTelephoneNumber
    /// </summary>
    public string BillingTelephoneNumber { get; set; }

    /// <summary>
    /// Subscriber
    /// </summary>
    public Subscriber Subscriber { get; set; }

    /// <summary>
    /// LoaAuthorizingPerson
    /// </summary>
    public string LoaAuthorizingPerson { get; set; }

    /// <summary>
    /// ListOfPhoneNumbers
    /// </summary>
    [XmlArrayItem("PhoneNumber")]
    public string[] ListOfPhoneNumbers { get; set; }

    /// <summary>
    /// SiteId
    /// </summary>
    public string SiteId { get; set; }

    /// <summary>
    /// PeerId
    /// </summary>
    public string PeerId { get; set; }

    /// <summary>
    /// Triggered
    /// </summary>
    public bool Triggered { get; set; }
  }

  /// <summary>
  /// LnpOrderResponse
  /// </summary>
  public class LnpOrderResponse : Portin
  {
    /// <summary>
    /// ProcessingStatus
    /// </summary>
    public string ProcessingStatus { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// BillingType
    /// </summary>
    public string BillingType { get; set; }

    /// <summary>
    /// WirelessInfo
    /// </summary>
    [XmlElement("WirelessInfo")]
    public WirelessInfo[] WirelessInfo { get; set; }

    /// <summary>
    /// LosingCarrierName
    /// </summary>
    public string LosingCarrierName { get; set; }

    /// <summary>
    /// LastModifiedDate
    /// </summary>
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// UserId
    /// </summary>
    [XmlElement("userId")]
    public string UserId { get; set; }
  }

  /// <summary>
  /// LnpOrderSupp
  /// </summary>
  public class LnpOrderSupp : Portin
  {
    /// <summary>
    /// RequestedFocDate
    /// </summary>
    public DateTime RequestedFocDate { get; set; }

    /// <summary>
    /// WirelessInfo
    /// </summary>
    [XmlElement("WirelessInfo")]
    public WirelessInfo[] WirelessInfo { get; set; }
  }

  /// <summary>
  /// WirelessInfo
  /// </summary>
  public class WirelessInfo
  {
    /// <summary>
    /// AccountNumber
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// PinNumber
    /// </summary>
    public string PinNumber { get; set; }
  }


  /// <summary>
  /// Status
  /// </summary>
  public class Status
  {
    /// <summary>
    /// Code
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }
  }


  /// <summary>
  /// FileMetadata
  /// </summary>
  [XmlType("FileMetaData")]
  public class FileMetadata
  {
    /// <summary>
    /// DocumentType
    /// </summary>
    public string DocumentType { get; set; }

    /// <summary>
    /// DocumentName
    /// </summary>
    public string DocumentName { get; set; }
  }

  /// <summary>
  /// FileListResponse
  /// </summary>
  [XmlType("fileListResponse")]
  public class FileListResponse
  {
    /// <summary>
    /// FileCount
    /// </summary>
    [XmlElement("fileCount")]
    public int FileCount { get; set; }

    /// <summary>
    /// FileData
    /// </summary>
    [XmlElement("fileData")]
    public FileData[] FileData { get; set; }
  }

  /// <summary>
  /// FileData
  /// </summary>
  public class FileData
  {
    /// <summary>
    /// FileName
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// FileMetadata
    /// </summary>
    [XmlElement("FileMetaData")]
    public FileMetadata FileMetadata { get; set; }
  }

  /// <summary>
  /// Downloaded file content
  /// </summary>
  public sealed class FileContent : IDisposable
  {
    private readonly IDisposable _owner;

    internal FileContent(IDisposable owner)
    {
      if (owner == null) throw new ArgumentNullException(nameof(owner));
      _owner = owner;
    }

    /// <summary>
    /// Media type of downloaded file
    /// </summary>
    public string MediaType { get; set; }

    /// <summary>
    /// File content as stream
    /// </summary>
    public Stream Stream { get; set; }

    /// <summary>
    /// Fiel content as byte array
    /// </summary>
    public byte[] Buffer { get; set; }

    /// <summary>
    /// Free allocated resources
    /// </summary>
    public void Dispose()
    {
      _owner.Dispose();
    }
  }


  internal class PortinApi : ApiBase, IPortin
  {
    public Task<string> AddNoteAsync(string id, Note note, CancellationToken? cancellationToken = null)
    {
      return Api.MakePostXmlRequestAsync($"/accounts/{Api.AccountId}/portins/{id}/notes", cancellationToken, note);
    }

    public async Task<Note[]> GetNotesAsync(string id, CancellationToken? cancellationToken = null)
    {
      return
        (await
          Api.MakeXmlRequestAsync<Notes>(HttpMethod.Get, $"/accounts/{Api.AccountId}/portins/{id}/notes",
            cancellationToken)).List;
    }

    public Task<LnpOrderResponse> CreateAsync(Portin data, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<LnpOrderResponse>(HttpMethod.Post, $"/accounts/{Api.AccountId}/portins",
        cancellationToken, null, data);
    }

    public Task<string> CreateFileAsync(string id, Stream stream, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      return SendFileAsync(id, new StreamContent(stream), mediaType, cancellationToken);
    }

    public Task<string> CreateFileAsync(string id, byte[] buffer, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      return SendFileAsync(id, new ByteArrayContent(buffer), mediaType, cancellationToken);
    }

#if !WithoutFileIO
    public Task<string> CreateFileAsync(string id, string filePath, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      using (var stream = File.OpenRead(filePath))
      {
        return CreateFileAsync(id, stream, mediaType, cancellationToken);
      }
    }
#endif

    public Task UpdateFileAsync(string id, string fileName, Stream stream, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      return UpdateFileAsync(id, fileName, new StreamContent(stream), mediaType, cancellationToken);
    }

    public Task UpdateFileAsync(string id, string fileName, byte[] buffer, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      return UpdateFileAsync(id, fileName, new ByteArrayContent(buffer), mediaType, cancellationToken);
    }

#if !WithoutFileIO
    public Task UpdateFileAsync(string id, string fileName, string filePath, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      using (var stream = File.OpenRead(filePath))
      {
        return UpdateFileAsync(id, fileName, stream, mediaType, cancellationToken);
      }
    }
#endif

    public Task<FileMetadata> GetFileMetadataAsync(string id, string fileName,
      CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestAsync<FileMetadata>(HttpMethod.Get,
        $"/accounts/{Api.AccountId}/portins/{id}/loas/{Uri.EscapeUriString(fileName)}/metadata", cancellationToken);
    }

    public Task DeleteFileAsync(string id, string fileName, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Delete,
        $"/accounts/{Api.AccountId}/portins/{id}/loas/{Uri.EscapeUriString(fileName)}", cancellationToken);
    }

    public async Task<FileData[]> GetFilesAsync(string id, bool metadata = false,
      CancellationToken? cancellationToken = null)
    {
      var response = await Api.MakeXmlRequestAsync<FileListResponse>(HttpMethod.Get,
        $"/accounts/{Api.AccountId}/portins/{id}/loas", cancellationToken,
        new {Metadata = metadata.ToString().ToLowerInvariant()});
      return response == null ? new FileData[0] : response.FileData.ToArray();
    }

    public async Task<FileContent> GetFileAsync(string id, string fileName, bool asStream = false,
      CancellationToken? cancellationToken = null)
    {
      var response =
        await
          Api.MakeXmlRequestAsync(HttpMethod.Get,
            $"/accounts/{Api.AccountId}/portins/{id}/loas/{Uri.EscapeUriString(fileName)}", cancellationToken);
      var content = new FileContent(response) {MediaType = response.Content.Headers.ContentType.MediaType};
      if (asStream)
      {
        content.Stream = await response.Content.ReadAsStreamAsync();
      }
      else
      {
        content.Buffer = await response.Content.ReadAsByteArrayAsync();
      }
      return content;
    }

    public Task UpdateAsync(string id, LnpOrderSupp data, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Put, $"/accounts/{Api.AccountId}/portins/{id}",
        cancellationToken, null, data);
    }

    public Task DeleteAsync(string id, CancellationToken? cancellationToken = null)
    {
      return Api.MakeXmlRequestWithoutResponseAsync(HttpMethod.Delete, $"/accounts/{Api.AccountId}/portins/{id}",
        cancellationToken);
    }

    private async Task<string> SendFileAsync(string id, HttpContent content, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      using (
        var request = RequestHelpers.CreateRequest(HttpMethod.Put, $"/accounts/{Api.AccountId}/portins/{id}/loas",
          Api.BaseUrl, Api.AuthenticationHeader))
      {
        request.Content = content;
        request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
        using (var response = await Api.MakeXmlRequestAsync(request, cancellationToken))
        {
          return
            XDocument.Parse(await response.Content.ReadAsStringAsync())
              .Descendants("filename")
              .FirstOrDefault()
              .Value;
        }
      }
    }

    private async Task UpdateFileAsync(string id, string fileName, HttpContent content, string mediaType,
      CancellationToken? cancellationToken = null)
    {
      using (
        var request = RequestHelpers.CreateRequest(HttpMethod.Put,
          $"/accounts/{Api.AccountId}/portins/{id}/loas/{Uri.EscapeUriString(fileName)}",
          Api.BaseUrl, Api.AuthenticationHeader))
      {
        request.Content = content;
        request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
        using (await Api.MakeXmlRequestAsync(request, cancellationToken))
        {
        }
      }
    }
  }
}
