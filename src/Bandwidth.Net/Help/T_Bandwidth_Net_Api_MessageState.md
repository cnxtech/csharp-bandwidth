# MessageState Enumeration
 

Possible message states

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0

## Syntax

**C#**<br />
``` C#
public enum MessageState
```


## Members
&nbsp;<table><tr><th></th><th>Member name</th><th>Value</th><th>Description</th></tr><tr><td /><td target="F:Bandwidth.Net.Api.MessageState.Received">**Received**</td><td>0</td><td>The message was received.</td></tr><tr><td /><td target="F:Bandwidth.Net.Api.MessageState.Queued">**Queued**</td><td>1</td><td>The message is waiting in queue and will be sent soon.</td></tr><tr><td /><td target="F:Bandwidth.Net.Api.MessageState.Sending">**Sending**</td><td>2</td><td>The message was removed from queue and is being sent.</td></tr><tr><td /><td target="F:Bandwidth.Net.Api.MessageState.Sent">**Sent**</td><td>3</td><td>The message was sent successfully.</td></tr><tr><td /><td target="F:Bandwidth.Net.Api.MessageState.Error">**Error**</td><td>4</td><td>There was an error sending or receiving a message (check errors resource for details).</td></tr></table>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />