# GatherPrompt Class
 

Gather prompt


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">Bandwidth.Net.Catapult.PlayAudioData</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Bandwidth.Net.Catapult.GatherPrompt<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
public class GatherPrompt : PlayAudioData
```

The GatherPrompt type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Catapult_GatherPrompt__ctor.md">GatherPrompt</a></td><td>
Initializes a new instance of the GatherPrompt class</td></tr></table>&nbsp;
<a href="#gatherprompt-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_GatherPrompt_Bargeable.md">Bargeable</a></td><td>
Make the prompt (audio or sentence) bargeable (will be interrupted at first digit gathered). Default: true</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_PlayAudioData_FileUrl.md">FileUrl</a></td><td>
The location of an audio file to play (WAV and MP3 supported).
 (Inherited from <a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">PlayAudioData</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_PlayAudioData_Gender.md">Gender</a></td><td>
The gender of the voice used to synthesize the sentence. It will be considered only if sentence is not null. The female gender will be used by default.
 (Inherited from <a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">PlayAudioData</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_PlayAudioData_Locale.md">Locale</a></td><td>
The locale used to get the accent of the voice used to synthesize the sentence.
 (Inherited from <a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">PlayAudioData</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_PlayAudioData_LoopEnabled.md">LoopEnabled</a></td><td>
When value is true, the audio will keep playing in a loop. Default: false.
 (Inherited from <a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">PlayAudioData</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_PlayAudioData_Sentence.md">Sentence</a></td><td>
The sentence to speak.
 (Inherited from <a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">PlayAudioData</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_PlayAudioData_Tag.md">Tag</a></td><td>
A string that will be included in the events delivered when the audio playback starts or finishes
 (Inherited from <a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">PlayAudioData</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Catapult_PlayAudioData_Voice.md">Voice</a></td><td>
The voice to speak the sentence.
 (Inherited from <a href ="T_Bandwidth_Net_Catapult_PlayAudioData.md">PlayAudioData</a>.)</td></tr></table>&nbsp;
<a href="#gatherprompt-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />