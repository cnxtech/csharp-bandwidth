# Transfer Class
 

The Transfer verb is used to transfer the call to another number.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Xml.Verbs.Transfer<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Xml_Verbs.md">Bandwidth.Net.Xml.Verbs</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.3

## Syntax

**C#**<br />
``` C#
public class Transfer : IVerb
```

The Transfer type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Xml_Verbs_Transfer__ctor.md">Transfer</a></td><td>
Initializes a new instance of the Transfer class</td></tr></table>&nbsp;
<a href="#transfer-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_CallTimeout.md">CallTimeout</a></td><td>
This is the timeout (seconds) for the callee to answer the call.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_PhoneNumbers.md">PhoneNumbers</a></td><td>
A collection of phone numbers to transfer the call to. The first to answer will be transferred.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_PlayAudio.md">PlayAudio</a></td><td>
Using the PlayAudio inside the Transfer verb will play the media to the callee before transferring it.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_Record.md">Record</a></td><td>
Using Record inside Transfer verb will record the transferred call.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_RequestUrl.md">RequestUrl</a></td><td>
Relative or absolute URL to send event and request new BaML when transferred call hangs up.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_RequestUrlTimeout.md">RequestUrlTimeout</a></td><td>
Timeout (milliseconds) to request new BaML.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_SpeakSentence.md">SpeakSentence</a></td><td>
This will speak the text into the call before transferring it.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_Tag.md">Tag</a></td><td>
A string that will be included in the callback events of the conference</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_TransferCallerId.md">TransferCallerId</a></td><td>
This is the caller id that will be used when the call is transferred.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Xml_Verbs_Transfer_TransferTo.md">TransferTo</a></td><td>
Defines the number the call will be transferred to</td></tr></table>&nbsp;
<a href="#transfer-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Xml_Verbs.md">Bandwidth.Net.Xml.Verbs Namespace</a><br />

#### Other Resources
<a href="http://ap.bandwidth.com/docs/xml/transfer/" target="_blank">http://ap.bandwidth.com/docs/xml/transfer/</a><br />