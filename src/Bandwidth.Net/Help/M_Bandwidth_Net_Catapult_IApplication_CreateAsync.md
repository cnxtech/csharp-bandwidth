# IApplication.CreateAsync Method 
 

Create an application that can handle calls and messages for one of your phone number.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<string> CreateAsync(
	CreateApplicationData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_CreateApplicationData.md">Bandwidth.Net.Catapult.CreateApplicationData</a><br />Parameters of new application</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />Created application Id

## Examples

```
var applicationId = await client.Application.CreateAsync(new CreateApplicationData{ Name = "MyApp"});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IApplication.md">IApplication Interface</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />