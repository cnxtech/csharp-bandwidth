# IMedia.DownloadAsync Method 
 

Download a media file

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-preview

## Syntax

**C#**<br />
``` C#
Task<DownloadMediaFileData> DownloadAsync(
	string mediaName,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>mediaName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of media file to download</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_Api_DownloadMediaFileData.md">DownloadMediaFileData</a>)<br />Task with <a href ="T_Bandwidth_Net_Api_DownloadMediaFileData.md">DownloadMediaFileData</a> instance

## Examples

```
using(var data = await client.Media.DownloadAsync("file.txt"))
{
  var fileContent = await data.ReadAsStringAsync();
}
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IMedia.md">IMedia Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />