# CreateCallData Class
 

Parameters to create an call


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Catapult.CreateCallData<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
public class CreateCallData
```

The CreateCallData type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Catapult_CreateCallData__ctor.md">CreateCallData</a></td><td>
Initializes a new instance of the CreateCallData class</td></tr></table>&nbsp;
<a href="#createcalldata-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_BridgeId.md">BridgeId</a></td><td>
Id of the bridge where the call will be added</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_CallbackHttpMethod.md">CallbackHttpMethod</a></td><td>
Determine if the callback event should be sent via HTTP GET or HTTP POST.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_CallbackTimeout.md">CallbackTimeout</a></td><td>
Determine how long should the platform wait for callbackUrl's response before timing out (milliseconds).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_CallbackUrl.md">CallbackUrl</a></td><td>
The server URL where the call events related to the call will be sent.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_CallTimeout.md">CallTimeout</a></td><td>
Determine how long should the platform wait for call answer before timing out in seconds (milliseconds).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_ConferenceId.md">ConferenceId</a></td><td>
Id of the conference where the call will be added</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_FallbackUrl.md">FallbackUrl</a></td><td>
The server URL used to send the call events if the request to callbackUrl fails.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_From.md">From</a></td><td>
The phone number or SIP address that made the call. Phone numbers are in E.164 format (e.g. +15555555555) -or- SIP addresses (e.g. identify@domain.com).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_RecordingEnabled.md">RecordingEnabled</a></td><td>
Indicates if the call should be recorded after being created</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_RecordingFileFormat.md">RecordingFileFormat</a></td><td>
The file format of the recorded call.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_RecordingMaxDuration.md">RecordingMaxDuration</a></td><td>
Indicates the maximum duration of call recording in seconds</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_SipHeaders.md">SipHeaders</a></td><td>
Map of Sip headers prefixed by "X-". Up to 5 headers can be sent per call.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_Tag.md">Tag</a></td><td>
A string that will be included in the callback events of the call</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_To.md">To</a></td><td>
The phone number or SIP address that received the call. Phone numbers are in E.164 format (e.g. +15555555555) -or- SIP addresses (e.g. identify@domain.com).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_CreateCallData_TranscriptionEnabled.md">TranscriptionEnabled</a></td><td>
Whether all the recordings for this call should be be automatically transcribed.</td></tr></table>&nbsp;
<a href="#createcalldata-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />