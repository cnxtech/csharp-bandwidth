# IAvailableNumber.SearchLocalAsync Method 
 

Search for available local numbers

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<AvailableNumber[]> SearchLocalAsync(
	LocalNumberQuery query,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>query</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_LocalNumberQuery.md">Bandwidth.Net.Catapult.LocalNumberQuery</a><br />Search criterias</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_Catapult_AvailableNumber.md">AvailableNumber</a>[])<br />Array with <a href ="T_Bandwidth_Net_Catapult_AvailableNumber.md">AvailableNumber</a> instances

## Examples

```
var numbers = await client.AvailableNumber.SearchLocalAsync(new LocalNumberQuery {AreaCode = 910});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IAvailableNumber.md">IAvailableNumber Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />