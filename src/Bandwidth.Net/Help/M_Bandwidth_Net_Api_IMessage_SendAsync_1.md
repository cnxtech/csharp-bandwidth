# IMessage.SendAsync Method (MessageData[], Nullable(CancellationToken))
 

Send a message.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0

## Syntax

**C#**<br />
``` C#
Task<SendMessageResult[]> SendAsync(
	MessageData[] data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Api_MessageData.md">Bandwidth.Net.Api.MessageData</a>[]<br />Array of parameters of new messages</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_Api_SendMessageResult.md">SendMessageResult</a>[])<br />Instance of created message

## Examples

```
var messages = await client.Message.SendAsync(new[]{new MessageData{ From = "from", To = "to", Text = "Hello"}});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Api_IMessage.md">IMessage Interface</a><br /><a href ="Overload_Bandwidth_Net_Api_IMessage_SendAsync.md">SendAsync Overload</a><br /><a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />