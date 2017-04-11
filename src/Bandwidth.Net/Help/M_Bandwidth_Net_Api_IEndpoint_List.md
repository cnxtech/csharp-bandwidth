# IEndpoint.List Method 
 

Get a list of endpoints

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.3

## Syntax

**C#**<br />
``` C#
IEnumerable<Endpoint> List(
	string domainId,
	EndpointQuery query = null,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>domainId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of endpoint's domain</dd><dt>query (Optional)</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_EndpointQuery.md">Bandwidth.Net.Api.EndpointQuery</a><br />Optional query parameters</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />>Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href ="T_Bandwidth_Net_Api_Endpoint.md">Endpoint</a>)<br />Collection with <a href ="T_Bandwidth_Net_Api_Endpoint.md">Endpoint</a> instances

## Examples

```
var endpoints = client.Endpoint.List("domainId");
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IEndpoint.md">IEndpoint Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />