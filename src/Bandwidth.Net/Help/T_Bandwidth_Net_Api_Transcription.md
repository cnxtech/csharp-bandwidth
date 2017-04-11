# Transcription Class
 

Transcription data


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Api.Transcription<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.3

## Syntax

**C#**<br />
``` C#
public class Transcription
```

The Transcription type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Api_Transcription__ctor.md">Transcription</a></td><td>
Initializes a new instance of the Transcription class</td></tr></table>&nbsp;
<a href="#transcription-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_ChargeableDuration.md">ChargeableDuration</a></td><td>
The seconds between activeTime and endTime for the recording; this is the time that is going to be used to charge the resource.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_Id.md">Id</a></td><td>
The unique id of the transcriptions resource.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_State.md">State</a></td><td>
The state of the transcription</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_Text.md">Text</a></td><td>
The transcribed text.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_TextMediaName.md">TextMediaName</a></td><td>
Media name of full text file</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_TextSize.md">TextSize</a></td><td>
The size of the transcribed text. If the text is longer than 1000 characters it will be cropped; the full text can be retrieved from the url available at textUrl property.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_TextUrl.md">TextUrl</a></td><td>
An url to the full text; this property is available regardless the textSize.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_Transcription_Time.md">Time</a></td><td>
The date/time the transcription resource was created</td></tr></table>&nbsp;
<a href="#transcription-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />