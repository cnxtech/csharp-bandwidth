# ICall.UpdateAsync Method 
 

Manage an active phone call. E.g. Answer an incoming call, reject an incoming call, turn on / off recording, transfer, hang up.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-preview

## Syntax

**C#**<br />
``` C#
Task<HttpResponseMessage> UpdateAsync(
	string callId,
	UpdateCallData data,
	Nullable<CancellationToken> cancellationToken = null,
	bool disposeResponse = true
)
```


#### Parameters
&nbsp;<dl><dt>callId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of call to change</dd><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_UpdateCallData.md">Bandwidth.Net.Api.UpdateCallData</a><br />Changed data</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd><dt>disposeResponse (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Set false if you are going to free response resources yourselves</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/hh159046" target="_blank">HttpResponseMessage</a>)<br />Http response message

## Examples

```
await client.Call.UpdateAsync("callId", new UpdateCallData {CallAudio = true});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_ICall.md">ICall Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />