# IPhoneNumber.List Method 
 

Get a list of users phone numbers

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
IEnumerable<PhoneNumber> List(
	PhoneNumberQuery query = null,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>query (Optional)</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_PhoneNumberQuery.md">Bandwidth.Net.Catapult.PhoneNumberQuery</a><br />Optional query parameters</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />>Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href ="T_Bandwidth_Net_Catapult_PhoneNumber.md">PhoneNumber</a>)<br />Collection with <a href ="T_Bandwidth_Net_Catapult_PhoneNumber.md">PhoneNumber</a> instances

## Examples

```
var phoneNumbers = client.PhoneNumber.List();
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IPhoneNumber.md">IPhoneNumber Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />