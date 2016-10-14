# CallQuery Class
 

Query to get calls


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Bandwidth.Net.Api.CallQuery<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-beta4

## Syntax

**C#**<br />
``` C#
public class CallQuery
```

The CallQuery type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Api_CallQuery__ctor.md">CallQuery</a></td><td>
Initializes a new instance of the CallQuery class</td></tr></table>&nbsp;
<a href="#callquery-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_CallQuery_BridgeId.md">BridgeId</a></td><td>
The id of the bridge for querying a list of calls history</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_CallQuery_ConferenceId.md">ConferenceId</a></td><td>
The id of the conference for querying a list of calls history</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_CallQuery_From.md">From</a></td><td>
The number to filter calls that came from (must be either an E.164 formated number, like +19195551212, or a valid SIP URI, like sip:someone@somewhere.com).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_CallQuery_Size.md">Size</a></td><td>
Used for pagination to indicate the size of each page requested for querying a list of calls. If no value is specified the default value is 25 (maximum value 1000).</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_CallQuery_SortOrder.md">SortOrder</a></td><td>
How to sort the calls. If no value is specified the default value is Desc</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href ="P_Bandwidth_Net_Api_CallQuery_To.md">To</a></td><td>
The number to filter calls that was called to (must be either an E.164 formated number, like +19195551212, or a valid SIP URI, like sip:someone@somewhere.com).</td></tr></table>&nbsp;
<a href="#callquery-class">Back to Top</a>

## See Also


#### Reference
<a href ="N_Bandwidth_Net_Api.md">Bandwidth.Net.Api Namespace</a><br />