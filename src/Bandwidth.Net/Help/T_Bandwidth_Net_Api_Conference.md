# Conference Class
 

Conference information


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Api.Conference<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-preview

## Syntax

**C#**<br />
``` C#
public class Conference
```

The Conference type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Api_Conference__ctor.md">Conference</a></td><td>
Initializes a new instance of the Conference class</td></tr></table>&nbsp;
<a href="#conference-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_ActiveMembers.md">ActiveMembers</a></td><td>
The number of active conference members.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_CallbackHttpMethod.md">CallbackHttpMethod</a></td><td>
Determine if the callback event should be sent via HTTP GET or HTTP POST.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_CallbackTimeout.md">CallbackTimeout</a></td><td>
Determine how long should the platform wait for callbackUrl's response before timing out in milliseconds.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_CallbackUrl.md">CallbackUrl</a></td><td>
The complete URL where the events related to the Conference will be sent to.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_CompletedTime.md">CompletedTime</a></td><td>
The time that the Conference was completed</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_CreatedTime.md">CreatedTime</a></td><td>
The time that the Conference was created</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_FallbackUrl.md">FallbackUrl</a></td><td>
The URL used to send the callback event if the request to callbackUrl fails.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_From.md">From</a></td><td>
The phone number that will host the conference.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_Hold.md">Hold</a></td><td>
If "true", all member can't hear or speak in the conference. If "false", all members can hear and speak in the conference (unless set at the member level).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_Id.md">Id</a></td><td>
The unique identifier for the conference.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_Mute.md">Mute</a></td><td>
If "true", all member can't speak in the conference. If "false", all members can speak in the conference (unless set at the member level).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_State.md">State</a></td><td>
Conference state</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Conference_Tag.md">Tag</a></td><td>
A string that will be included in the callback events of the conference.</td></tr></table>&nbsp;
<a href="#conference-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />