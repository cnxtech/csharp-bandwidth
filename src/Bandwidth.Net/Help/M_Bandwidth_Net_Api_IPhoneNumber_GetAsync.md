# IPhoneNumber.GetAsync Method 
 

Get information about a phone number

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.3

## Syntax

**C#**<br />
``` C#
Task<PhoneNumber> GetAsync(
	string phoneNumberId,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>phoneNumberId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of phone number to get</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_Api_PhoneNumber.md">PhoneNumber</a>)<br />Task with <a href ="T_Bandwidth_Net_Api_PhoneNumber.md">PhoneNumber</a>PhoneNumber instance

## Examples

```
var phoneNumber = await client.PhoneNumber.GetAsync("phoneNumberId");
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IPhoneNumber.md">IPhoneNumber Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />