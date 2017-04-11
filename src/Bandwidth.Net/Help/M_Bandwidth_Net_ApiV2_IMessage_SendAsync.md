# IMessage.SendAsync Method 
 

Send a message.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_ApiV2.md">Bandwidth.Net.ApiV2</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.3

## Syntax

**C#**<br />
``` C#
Task<Message> SendAsync(
	MessageData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_ApiV2_MessageData.md">Bandwidth.Net.ApiV2.MessageData</a><br />Parameters of new message</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_ApiV2_Message.md">Message</a>)<br />Created message

## Examples

```
var message = await client.V2.Message.SendAsync(new MessageData{ From = "from", To = new[] {"to"}, Text = "Hello"});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_ApiV2_IMessage.md">IMessage Interface</a><br /><a href ="N_Bandwidth_Net_ApiV2.md">Bandwidth.Net.ApiV2 Namespace</a><br />