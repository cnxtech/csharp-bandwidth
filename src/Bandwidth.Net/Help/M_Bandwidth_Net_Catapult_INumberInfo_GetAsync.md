# INumberInfo.GetAsync Method 
 

Get the CNAM info of a number

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<NumberInfo> GetAsync(
	string number,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>number</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Phone number to get CNAM informations</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_Catapult_NumberInfo.md">NumberInfo</a>)<br />Task with <a href ="T_Bandwidth_Net_Catapult_NumberInfo.md">NumberInfo</a>NumberInfo instance

## Examples

```
var numberInfo = await client.NumberInfo.GetAsync("1234567890");
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_INumberInfo.md">INumberInfo Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />