# MessageData Class
 

Parameters to send an message


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Api.MessageData<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-preview

## Syntax

**C#**<br />
``` C#
public class MessageData
```

The MessageData type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Api_MessageData__ctor.md">MessageData</a></td><td>
Initializes a new instance of the MessageData class</td></tr></table>&nbsp;
<a href="#messagedata-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_CallbackTimeout.md">CallbackTimeout</a></td><td>
Determine how long should the platform wait for callbackUrl's response before timing out (milliseconds).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_CallbackUrl.md">CallbackUrl</a></td><td>
The complete URL where the events related to the outgoing message will be sent.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_FallbackUrl.md">FallbackUrl</a></td><td>
The server URL used to send message events if the request to callbackUrl fails.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_From.md">From</a></td><td>
The message sender's telephone number (or short code).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_Media.md">Media</a></td><td>
Array containing list of media urls to be sent as content for an mms.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_ReceiptRequested.md">ReceiptRequested</a></td><td>
Requested receipt option for outbound messages</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_Tag.md">Tag</a></td><td>
A string that will be included in the callback events of the message.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_Text.md">Text</a></td><td>
The message contents.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_MessageData_To.md">To</a></td><td>
Message recipient telephone number (or short code).</td></tr></table>&nbsp;
<a href="#messagedata-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />