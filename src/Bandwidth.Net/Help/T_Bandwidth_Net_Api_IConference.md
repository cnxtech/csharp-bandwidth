# IConference Interface
 

Access to Conference Api

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-beta4

## Syntax

**C#**<br />
``` C#
public interface IConference : IPlayAudio
```

The IConference type exposes the following members.


## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_IConference_CreateAsync.md">CreateAsync</a></td><td>
Create a conference</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_IConference_CreateMemberAsync.md">CreateMemberAsync</a></td><td>
Add a member to a conference.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_IConference_GetAsync.md">GetAsync</a></td><td>
Get information about a conference</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_IConference_GetMemberAsync.md">GetMemberAsync</a></td><td>
Retrieve properties for a single conference member</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_IConference_GetMembers.md">GetMembers</a></td><td>
List all members from a conference</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_IPlayAudio_PlayAudioAsync.md">PlayAudioAsync</a></td><td>
Play audio
 (Inherited from <a href ="T_Bandwidth_Net_IPlayAudio.md">IPlayAudio</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Api_IConference_PlayAudioToMemberAsync.md">PlayAudioToMemberAsync</a></td><td>
Play audio to conference member</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_IConference_UpdateAsync.md">UpdateAsync</a></td><td>
Change the conference properties and/or status</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_IConference_UpdateMemberAsync.md">UpdateMemberAsync</a></td><td>
Update a conference member (remove, mute, hold)</td></tr></table>&nbsp;
<a href="#iconference-interface">Back to Top</a>

## Extension Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_DeleteMemberAsync.md">DeleteMemberAsync</a></td><td>
Remove member from the conference
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_HoldAsync.md">HoldAsync</a></td><td>
Hold/Unhold the conference
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_HoldMemberAsync.md">HoldMemberAsync</a></td><td>
Hold/Unhold the conference member
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_MuteAsync.md">MuteAsync</a></td><td>
Mute/Unmute the conference
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_MuteMemberAsync.md">MuteMemberAsync</a></td><td>
Mute/Unmute the conference member
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_PlayAudioExtensions_PlayAudioFileAsync.md">PlayAudioFileAsync</a></td><td>
Play audio file by url
 (Defined by <a href ="T_Bandwidth_Net_PlayAudioExtensions.md">PlayAudioExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_PlayAudioFileToMemberAsync.md">PlayAudioFileToMemberAsync</a></td><td>
Play audio file by url
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_PlayAudioExtensions_SpeakSentenceAsync.md">SpeakSentenceAsync</a></td><td>
Speak a sentence
 (Defined by <a href ="T_Bandwidth_Net_PlayAudioExtensions.md">PlayAudioExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_SpeakSentenceToMemberAsync.md">SpeakSentenceToMemberAsync</a></td><td>
Speak a sentence
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href ="M_Bandwidth_Net_Api_ConferenceExtensions_TerminateAsync.md">TerminateAsync</a></td><td>
Terminate the conference
 (Defined by <a href ="T_Bandwidth_Net_Api_ConferenceExtensions.md">ConferenceExtensions</a>.)</td></tr></table>&nbsp;
<a href="#iconference-interface">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />