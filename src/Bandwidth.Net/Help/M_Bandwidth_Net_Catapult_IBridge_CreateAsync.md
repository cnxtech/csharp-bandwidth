# IBridge.CreateAsync Method 
 

Create a bridge.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<string> CreateAsync(
	CreateBridgeData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_CreateBridgeData.md">Bandwidth.Net.Catapult.CreateBridgeData</a><br />Parameters of new bridge</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />Created bridge Id

## Examples

```
var bridgeId = await client.Bridge.CreateAsync(new CreateBridgeData{ CallIds = new[]{"callId"}});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IBridge.md">IBridge Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />