# IPhoneNumber.CreateAsync Method 
 

Allocate a number so you can use it.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0

## Syntax

**C#**<br />
``` C#
Task<ILazyInstance<PhoneNumber>> CreateAsync(
	CreatePhoneNumberData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_CreatePhoneNumberData.md">Bandwidth.Net.Api.CreatePhoneNumberData</a><br />Parameters of new phone number</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_ILazyInstance_1.md">ILazyInstance</a>(<a href ="T_Bandwidth_Net_Api_PhoneNumber.md">PhoneNumber</a>))<br />Instance of created phone number

## Examples

```
var phoneNumber = await client.PhoneNumber.CreateAsync(new CreatePhoneNumberData{ Number = "+1234567890"});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IPhoneNumber.md">IPhoneNumber Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />