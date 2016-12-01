# IDomain.List Method 
 

Get a list of domains

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
IEnumerable<Domain> List(
	DomainQuery query = null,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>query (Optional)</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_DomainQuery.md">Bandwidth.Net.Catapult.DomainQuery</a><br />Optional query parameters</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />>Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href ="T_Bandwidth_Net_Catapult_Domain.md">Domain</a>)<br />Collection with <a href ="T_Bandwidth_Net_Catapult_Domain.md">Domain</a> instances

## Examples

```
var domains = client.Domain.List();
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IDomain.md">IDomain Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />