# IEndpoint.CreateAsync Method 
 

Create a endpoint.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0

## Syntax

**C#**<br />
``` C#
Task<ILazyInstance<Endpoint>> CreateAsync(
	CreateEndpointData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_CreateEndpointData.md">Bandwidth.Net.Api.CreateEndpointData</a><br />Parameters of new endpoint</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_ILazyInstance_1.md">ILazyInstance</a>(<a href ="T_Bandwidth_Net_Api_Endpoint.md">Endpoint</a>))<br />Instance of created endpoint

## Examples

```
var endpoint = await client.Endpoint.CreateAsync(new CreateEndpointData{ Name = "endpoint", DomainId="domainId", ApplicationId="applicationId", Credentials = new CreateEndpointCredentials{Password = "123456"}});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IEndpoint.md">IEndpoint Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />