# IBridge.List Method 
 

Get a list of bridges

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
IEnumerable<Bridge> List(
	BridgeQuery query = null,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>query (Optional)</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_BridgeQuery.md">Bandwidth.Net.Catapult.BridgeQuery</a><br />Optional query parameters</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />>Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href ="T_Bandwidth_Net_Catapult_Bridge.md">Bridge</a>)<br />Collection with <a href ="T_Bandwidth_Net_Catapult_Bridge.md">Bridge</a> instances

## Examples

```
var bridges = client.Bridge.List();
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IBridge.md">IBridge Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />