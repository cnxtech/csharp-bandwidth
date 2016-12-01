# IBridge.UpdateAsync Method 
 

Update a bridge

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task UpdateAsync(
	string bridgeId,
	UpdateBridgeData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>bridgeId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of bridge to change</dd><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_UpdateBridgeData.md">Bandwidth.Net.Catapult.UpdateBridgeData</a><br />Changed data</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">Task</a><br />Task instance for async operation

## Examples

```
await client.Bridge.UpdateAsync("bridgeId", new UpdateBridgeData {BridgeAudio = true});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IBridge.md">IBridge Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />