# Call Class
 

Call information


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Api.Call<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-preview

## Syntax

**C#**<br />
``` C#
public class Call
```

The Call type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Api_Call__ctor.md">Call</a></td><td>
Initializes a new instance of the Call class</td></tr></table>&nbsp;
<a href="#call-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_ActiveTime.md">ActiveTime</a></td><td>
Date when the call was answered.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_BridgeId.md">BridgeId</a></td><td>
Id of the bridge where the call will be added</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_CallbackHttpMethod.md">CallbackHttpMethod</a></td><td>
Determine if the callback event should be sent via HTTP GET or HTTP POST.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_CallbackTimeout.md">CallbackTimeout</a></td><td>
Determine how long should the platform wait for callbackUrl's response before timing out (milliseconds).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_CallbackUrl.md">CallbackUrl</a></td><td>
The server URL where the call events related to the call will be sent.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_CallTimeout.md">CallTimeout</a></td><td>
Determine how long should the platform wait for call answer before timing out in seconds (milliseconds).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_ChargeableDuration.md">ChargeableDuration</a></td><td>
The seconds between ActiveTime and EndTime</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_ConferenceId.md">ConferenceId</a></td><td>
Id of the conference where the call will be added</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_Direction.md">Direction</a></td><td>
Call direction</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_EndTime.md">EndTime</a></td><td>
Date when the call ended.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_FallbackUrl.md">FallbackUrl</a></td><td>
The server URL used to send the call events if the request to callbackUrl fails.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_From.md">From</a></td><td>
The phone number or SIP address that made the call. Phone numbers are in E.164 format (e.g. +15555555555) -or- SIP addresses (e.g. identify@domain.com).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_Id.md">Id</a></td><td>
The unique identifier for the call.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_RecordingEnabled.md">RecordingEnabled</a></td><td>
Indicates if the call should be recorded after being created</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_RecordingFileFormat.md">RecordingFileFormat</a></td><td>
The file format of the recorded call</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_RecordingMaxDuration.md">RecordingMaxDuration</a></td><td>
Indicates the maximum duration of call recording in seconds</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_SipHeaders.md">SipHeaders</a></td><td>
Map of Sip headers prefixed by "X-". Up to 5 headers can be sent per call.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_StartTime.md">StartTime</a></td><td>
Date when the call was created.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_State.md">State</a></td><td>
Call state</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_Tag.md">Tag</a></td><td>
A string that will be included in the callback events of the call</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_To.md">To</a></td><td>
The phone number or SIP address that received the call. Phone numbers are in E.164 format (e.g. +15555555555) -or- SIP addresses (e.g. identify@domain.com).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_TranscriptionEnabled.md">TranscriptionEnabled</a></td><td>
Whether all the recordings for this call should be be automatically transcribed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_TransferCallerId.md">TransferCallerId</a></td><td>
This is the caller id that will be used when the call is transferred</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_TransferTo.md">TransferTo</a></td><td>
Number that the call is going to be transferred to</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Call_WhisperAudio.md">WhisperAudio</a></td><td>
Audio to be played to the number that the call will be transfered to</td></tr></table>&nbsp;
<a href="#call-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />