# IAccount.GetAsync Method 
 

Get information about account (IRIS)

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Iris.md">Bandwidth.Net.Iris</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<Account> GetAsync(
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_Iris_Account.md">Account</a>)<br />Task with <a href ="T_Bandwidth_Net_Iris_Account.md">Account</a> Account instance

## Examples

```
var account = await client.IrisAccount.GetAsync();
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Iris_IAccount.md">IAccount Interface</a><br /><a href ="N_Bandwidth_Net_Iris.md">Bandwidth.Net.Iris Namespace</a><br />