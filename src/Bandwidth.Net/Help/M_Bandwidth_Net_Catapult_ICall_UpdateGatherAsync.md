# ICall.UpdateGatherAsync Method 
 

Update the gather

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task UpdateGatherAsync(
	string callId,
	string gatherId,
	UpdateGatherData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>callId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of the call</dd><dt>gatherId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of the gather</dd><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_UpdateGatherData.md">Bandwidth.Net.Catapult.UpdateGatherData</a><br />Changed data</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">Task</a><br />Task instance for async operation

## Examples

```
await client.Call.UpdateGatherAsync("callId", "gatherId", new UpdateGatherData {State = CallGatherState.Completed});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_ICall.md">ICall Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />