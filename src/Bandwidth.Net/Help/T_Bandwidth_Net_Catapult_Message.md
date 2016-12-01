# Message Class
 

Message information


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Catapult.Message<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
public class Message
```

The Message type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Catapult_Message__ctor.md">Message</a></td><td>
Initializes a new instance of the Message class</td></tr></table>&nbsp;
<a href="#message-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_CallbackTimeout.md">CallbackTimeout</a></td><td>
Determine how long should the platform wait for callbackUrl's response before timing out (milliseconds).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_CallbackUrl.md">CallbackUrl</a></td><td>
The complete URL where the events related to the outgoing message will be sent.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_DeliveryCode.md">DeliveryCode</a></td><td>
Numeric value of deliver code, see table for values.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_DeliveryDescription.md">DeliveryDescription</a></td><td>
Message delivery description for the respective delivery code</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_DeliveryState.md">DeliveryState</a></td><td>
Message delivery state</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_Direction.md">Direction</a></td><td>
Direction of message</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_FallbackUrl.md">FallbackUrl</a></td><td>
The server URL used to send message events if the request to callbackUrl fails.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_From.md">From</a></td><td>
The message sender's telephone number (or short code).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_Id.md">Id</a></td><td>
The unique identifier for the message.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_Media.md">Media</a></td><td>
Array containing list of media urls to be sent as content for an mms.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_ReceiptRequested.md">ReceiptRequested</a></td><td>
Requested receipt option for outbound messages</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_State.md">State</a></td><td>
Message state</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_Tag.md">Tag</a></td><td>
A string that will be included in the callback events of the message.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_Text.md">Text</a></td><td>
The message contents.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_Time.md">Time</a></td><td>
The time when the message was completed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_Message_To.md">To</a></td><td>
Message recipient telephone number (or short code).</td></tr></table>&nbsp;
<a href="#message-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />