# ICall.CreateGatherAsync Method 
 

Gather the DTMF digits pressed

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<string> CreateGatherAsync(
	string callId,
	CreateGatherData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>callId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of the calls</dd><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_CreateGatherData.md">Bandwidth.Net.Catapult.CreateGatherData</a><br />Parameters of new call</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />Created gather id

## Examples

```
var gatherId = await client.Call.CreateGatherAsync("callId", new CreateGatherData{ MaxDigits = 1});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_ICall.md">ICall Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />