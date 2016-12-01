# IEndpoint.CreateAuthTokenAsync Method 
 

Create auth token for the endpoint (usefull for client applications instead of using SIP account password directly)

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<EndpointAuthToken> CreateAuthTokenAsync(
	string domainId,
	string endpointId,
	CreateAuthTokenData data = null,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>domainId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of endpoint's domain</dd><dt>endpointId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of endpoint</dd><dt>data (Optional)</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_CreateAuthTokenData.md">Bandwidth.Net.Catapult.CreateAuthTokenData</a><br />Optional parameters of new token</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_Catapult_EndpointAuthToken.md">EndpointAuthToken</a>)<br />Created auth token

## Examples

```
var token = await client.Endpoint.CreateAuthTokenAsync("domainId", "endpointId");
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IEndpoint.md">IEndpoint Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />