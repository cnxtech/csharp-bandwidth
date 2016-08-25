# IPhoneNumber.UpdateAsync Method 
 

Make changes to a number

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0

## Syntax

**C#**<br />
``` C#
Task UpdateAsync(
	string phoneNumberId,
	UpdatePhoneNumberData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>phoneNumberId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of phoneNumber to change</dd><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_UpdatePhoneNumberData.md">Bandwidth.Net.Api.UpdatePhoneNumberData</a><br />Changed data</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">Task</a><br />Task instance for async operation

## Examples

```
await client.PhoneNumber.UpdateAsync("phoneNumberId", new UpdatePhoneNumberData {ApplicationId = "appId"});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IPhoneNumber.md">IPhoneNumber Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />