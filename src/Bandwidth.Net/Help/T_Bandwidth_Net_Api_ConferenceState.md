# ConferenceState Enumeration
 

Possible conference states

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-beta4

## Syntax

**C#**<br />
``` C#
public enum ConferenceState
```


## Members
&nbsp;<table><tr><th></th><th>Member name</th><th>Value</th><th>Description</th></tr><tr><td /><td target="F:Bandwidth.Net.Api.ConferenceState.Created">**Created**</td><td>0</td><td>Conference was created and has no members.</td></tr><tr><td /><td target="F:Bandwidth.Net.Api.ConferenceState.Active">**Active**</td><td>1</td><td>Conference was created and has one or more ACTIVE members. As soon as the first member is added to a conference, the state is changed to active.</td></tr><tr><td /><td target="F:Bandwidth.Net.Api.ConferenceState.Completed">**Completed**</td><td>2</td><td>The conference was completed. Once the conference is completed, It can not be used anymore.</td></tr></table>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />