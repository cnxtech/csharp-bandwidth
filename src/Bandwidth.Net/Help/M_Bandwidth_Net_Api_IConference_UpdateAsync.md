# IConference.UpdateAsync Method 
 

Change the conference properties and/or status

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-beta4

## Syntax

**C#**<br />
``` C#
Task UpdateAsync(
	string conferenceId,
	UpdateConferenceData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>conferenceId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of conference to change</dd><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_UpdateConferenceData.md">Bandwidth.Net.Api.UpdateConferenceData</a><br />Changed data</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">Task</a><br />Task instance for async operation

## Examples

```
await client.Conference.UpdateAsync("conferenceId", new UpdateConferenceData {Mute = true});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IConference.md">IConference Interface</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />