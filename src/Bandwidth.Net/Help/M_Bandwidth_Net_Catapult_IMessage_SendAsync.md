# IMessage.SendAsync Method (MessageData, Nullable(CancellationToken))
 

Send a message.

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
Task<string> SendAsync(
	MessageData data,
	Nullable<CancellationToken> cancellationToken = null
)
```


#### Parameters
&nbsp;<dl><dt>data</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_MessageData.md">Bandwidth.Net.Catapult.MessageData</a><br />Parameters of new message</dd><dt>cancellationToken (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd384802" target="_blank">CancellationToken</a>)<br />Optional token to cancel async operation</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />Created message Id

## Examples

```
var messageId = await client.Message.SendAsync(new MessageData{ From = "from", To = "to", Text = "Hello"});
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_IMessage.md">IMessage Interface</a><br /><a href ="Overload_Bandwidth_Net_Catapult_IMessage_SendAsync.md">SendAsync Overload</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />