using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bandwidth.Net.Iris;
using LightMock;
using Xunit;

namespace Bandwidth.Net.Test.Iris
{
  public class PortinTests
  {
    [Fact]
    public async void TestCreate()
    {
      var order = new LnpOrderResponse
      {
        BillingTelephoneNumber = "1111",
        Subscriber = new Subscriber
        {
          SubscriberType = "BUSINESS",
          BusinessName = "Company",
          ServiceAddress = new Address
          {
            City = "City",
            StateCode = "State",
            Country = "County"
          }
        },
        SiteId = "1",
        OrderId = "id"
      };
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(order))
      };
      response.Headers.Location = new Uri("http://localhost/path/id");
      var context = new MockContext<IHttp>();
      var data = new Portin
      {
        SiteId = "siteId"
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var res = await api.CreateAsync(data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
      Assert.Equal("1111", res.BillingTelephoneNumber);
      Assert.Equal("id", res.Id);
    }

    public static bool IsValidCreateRequest(HttpRequestMessage request, Portin data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestList()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("PortinList")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidListRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var items = await api.ListAsync();
      Assert.Equal(2, items.Length);
    }

    public static bool IsValidListRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins";
    }

    [Fact]
    public async void TestGet()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("Portin")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetRequest(r)), HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var item = await api.GetAsync("id");
      Assert.Equal("771297665AABC", item.WirelessInfo[0].AccountNumber);
    }

    public static bool IsValidGetRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id";
    }

    [Fact]
    public async void TestUpdate()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var context = new MockContext<IHttp>();
      var data = new LnpOrderSupp
      {
        SiteId = "newSiteId"
      };
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      await api.UpdateAsync("id", data);
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUpdateRequest(r, data)),
          HttpCompletionOption.ResponseContentRead,
          null));
    }


    public static bool IsValidUpdateRequest(HttpRequestMessage request, Portin data)
    {
      return request.Method == HttpMethod.Put &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }


    [Fact]
    public async void TestDelete()
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidDeleteRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      await api.DeleteAsync("id");
      context.Assert(m =>
        m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidDeleteRequest(r)),
          HttpCompletionOption.ResponseContentRead,
          null));
    }

    public static bool IsValidDeleteRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Delete &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id";
    }


    [Fact]
    public async void TestAddNote()
    {
      var data = new Note
      {
        Description = "test"
      };
      var response = new HttpResponseMessage(HttpStatusCode.Created);
      response.Headers.Location = new Uri("http://localhost/path/noteId");
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidAddNoteRequest(r, data)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var id = await api.AddNoteAsync("id", data);
      Assert.Equal("noteId", id);
    }

    public static bool IsValidAddNoteRequest(HttpRequestMessage request, Note data)
    {
      return request.Method == HttpMethod.Post &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/notes"
             && request.Content.Headers.ContentType.MediaType == "application/xml"
             && request.Content.ReadAsStringAsync().Result == Helpers.ToXmlString(data);
    }

    [Fact]
    public async void TestGetNotes()
    {
      var response = new HttpResponseMessage
      {
        Content = Helpers.GetIrisContent("Notes")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetNotesRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var list = await api.GetNotesAsync("id");
      Assert.Equal(2, list.Length);
      Assert.Equal("11299", list[0].Id);
      Assert.Equal("customer", list[0].UserId);
      Assert.Equal("Test", list[0].Description);
      Assert.Equal("11301", list[1].Id);
      Assert.Equal("customer", list[1].UserId);
      Assert.Equal("Test1", list[1].Description);
    }

    public static bool IsValidGetNotesRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get &&
             request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/notes";
    }

    [Fact]
    public async void TestCreateFileStream()
    {
      var response = new HttpResponseMessage
      {
        Content = new XmlContent("<Response><filename>fileName</filename></Response>")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateFileRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      using (var stream = new MemoryStream(Encoding.Unicode.GetBytes("1234")))
      {
        var fileName = await api.CreateFileAsync("id", stream, "application/octet-stream");
        Assert.Equal("fileName", fileName);
      }
    }

    [Fact]
    public async void TestCreateFileBuffer()
    {
      var response = new HttpResponseMessage
      {
        Content = new XmlContent("<Response><filename>fileName</filename></Response>")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateFileRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var fileName = await api.CreateFileAsync("id", Encoding.Unicode.GetBytes("1234"), "application/octet-stream");
      Assert.Equal("fileName", fileName);
    }

    [Fact]
    public async void TestCreateFilePath()
    {
      var response = new HttpResponseMessage
      {
        Content = new XmlContent("<Response><filename>fileName</filename></Response>")
      };
      var context = new MockContext<IHttp>();
      var path = Path.GetTempFileName();
      try
      {
        File.WriteAllBytes(path, Encoding.Unicode.GetBytes("1234"));
        context.Arrange(
          m =>
            m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidCreateFileRequest(r)),
              HttpCompletionOption.ResponseContentRead,
              null)).Returns(Task.FromResult(response));
        var api = Helpers.GetIrisApi(context).Portin;
        var fileName = await api.CreateFileAsync("id", path, "application/octet-stream");
        Assert.Equal("fileName", fileName);
      }
      finally
      {
        File.Delete(path);
      }
    }


    public static bool IsValidCreateFileRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Put
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/loas"
             && request.Content.Headers.ContentType.MediaType == "application/octet-stream"
             && Encoding.Unicode.GetString(request.Content.ReadAsByteArrayAsync().Result) == "1234";
    }

    [Fact]
    public async void TestUpdateFileStream()
    {
      var response = new HttpResponseMessage();
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUploadFileRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      using (var stream = new MemoryStream(Encoding.Unicode.GetBytes("1234")))
      {
        await api.UpdateFileAsync("id", "fileName", stream, "application/octet-stream");
      }
    }

    [Fact]
    public async void TestUpdateFileBuffer()
    {
      var response = new HttpResponseMessage();
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUploadFileRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      await api.UpdateFileAsync("id", "fileName", Encoding.Unicode.GetBytes("1234"), "application/octet-stream");
    }

    [Fact]
    public async void TestUpdateFilePath()
    {
      var response = new HttpResponseMessage();
      var context = new MockContext<IHttp>();
      var path = Path.GetTempFileName();
      try
      {
        File.WriteAllBytes(path, Encoding.Unicode.GetBytes("1234"));
        context.Arrange(
          m =>
            m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidUploadFileRequest(r)),
              HttpCompletionOption.ResponseContentRead,
              null)).Returns(Task.FromResult(response));
        var api = Helpers.GetIrisApi(context).Portin;
        await api.UpdateFileAsync("id", "fileName", path, "application/octet-stream");
      }
      finally
      {
        File.Delete(path);
      }
    }


    public static bool IsValidUploadFileRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Put
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/loas/fileName"
             && request.Content.Headers.ContentType.MediaType == "application/octet-stream"
             && Encoding.Unicode.GetString(request.Content.ReadAsByteArrayAsync().Result) == "1234";
    }

    [Fact]
    public async void TestDeleteFile()
    {
      var response = new HttpResponseMessage();
      var context = new MockContext<IHttp>();
      context.Arrange(
          m =>
            m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidDeleteFileRequest(r)),
              HttpCompletionOption.ResponseContentRead,
              null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      await api.DeleteFileAsync("id", "fileName");
    }
    
    public static bool IsValidDeleteFileRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Delete
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/loas/fileName";
    }

    [Fact]
    public async void TestGetFileMetadata()
    {
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(new FileMetadata
        {
          DocumentName = "name",
          DocumentType = "type"
        }))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetFileMetadataRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var metadata = await api.GetFileMetadataAsync("id", "fileName");
      Assert.Equal("name", metadata.DocumentName);
      Assert.Equal("type", metadata.DocumentType);
    }


    public static bool IsValidGetFileMetadataRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/loas/fileName/metadata";
    }

    [Fact]
    public async void TestGetFiles()
    {
      var response = new HttpResponseMessage
      {
        Content = new XmlContent(Helpers.ToXmlString(new FileListResponse{ FileData = new[]{ new FileData
        {
          FileName = "fileName"
        }}}))
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetFilesRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      var files = await api.GetFilesAsync("id");
      Assert.Equal(1, files.Length);
    }


    public static bool IsValidGetFilesRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/loas?metadata=false";
    }

    [Fact]
    public async void TestGetFileStream()
    {
      var response = new HttpResponseMessage
      {
        Content = new StringContent("1234", Encoding.UTF8, "text/plain")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetFileRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      using (var r = await api.GetFileAsync("id", "fileName", true))
      {
        Assert.Equal("text/plain", r.MediaType);
        Assert.Null(r.Buffer);
        Assert.NotNull(r.Stream);
      }
    }

    [Fact]
    public async void TestGetFileBuffer()
    {
      var response = new HttpResponseMessage
      {
        Content = new StringContent("1234", Encoding.UTF8, "text/plain")
      };
      var context = new MockContext<IHttp>();
      context.Arrange(
        m =>
          m.SendAsync(The<HttpRequestMessage>.Is(r => IsValidGetFileRequest(r)),
            HttpCompletionOption.ResponseContentRead,
            null)).Returns(Task.FromResult(response));
      var api = Helpers.GetIrisApi(context).Portin;
      using (var r = await api.GetFileAsync("id", "fileName"))
      {
        Assert.Equal("text/plain", r.MediaType);
        Assert.NotNull(r.Buffer);
        Assert.Null(r.Stream);
      }
    }


    public static bool IsValidGetFileRequest(HttpRequestMessage request)
    {
      return request.Method == HttpMethod.Get
             && request.RequestUri.PathAndQuery == "/v1.0/accounts/accountId/portins/id/loas/fileName";
    }

  }
}
