# ICall.GetTranscriptions Method 
 

Get a list of transcriptions of call

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
IEnumerable<Transcription> GetTranscriptions(
	string callId,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>callId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of call to get transcriptions</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />>Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href ="T_Bandwidth_Net_Catapult_Transcription.md">Transcription</a>)<br />Collection with <a href ="T_Bandwidth_Net_Catapult_Transcription.md">Transcription</a> instances

## Examples

```
var transcriptions = client.Call.GetTranscriptions("callId");
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_ICall.md">ICall Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />