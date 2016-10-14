# ITranscription.List Method 
 

Get a list of transcriptions

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-beta4

## Syntax

**C#**<br />
``` C#
IEnumerable<Transcription> List(
	string recordingId,
	TranscriptionQuery query = null,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>recordingId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of the recording</dd><dt>query (Optional)</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_TranscriptionQuery.md">Bandwidth.Net.Api.TranscriptionQuery</a><br />Optional query parameters</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />>Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href ="T_Bandwidth_Net_Api_Transcription.md">Transcription</a>)<br />Collection with <a href ="T_Bandwidth_Net_Api_Transcription.md">Transcription</a> instances

## Examples

```
var transcriptions = client.Transcription.List("recordingId");
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_ITranscription.md">ITranscription Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />