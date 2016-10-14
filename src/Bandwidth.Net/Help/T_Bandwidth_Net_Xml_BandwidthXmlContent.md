# BandwidthXmlContent Class
 

BandwidthXML content for HttpResponseMessage


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/hh193687" target="_blank">System.Net.Http.HttpContent</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/hh158909" target="_blank">System.Net.Http.ByteArrayContent</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/hh138250" target="_blank">System.Net.Http.StringContent</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bandwidth.Net.Xml.BandwidthXmlContent<br />
**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Xml.md">Bandwidth.Net.Xml</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-beta4

## Syntax

**C#**<br />
``` C#
public class BandwidthXmlContent : StringContent
```

The BandwidthXmlContent type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href ="M_Bandwidth_Net_Xml_BandwidthXmlContent__ctor.md">BandwidthXmlContent</a></td><td>
Constructor</td></tr></table>&nbsp;
<a href="#bandwidthxmlcontent-class">Back to Top</a>

## Extension Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")![Code example](media/CodeExample.png "Code example")</td><td><a href ="M_Bandwidth_Net_CallbackEventHelpers_ReadAsCallbackEventAsync.md">ReadAsCallbackEventAsync</a></td><td>
Read CallbackEvent instance from http content
 (Defined by <a href ="T_Bandwidth_Net_CallbackEventHelpers.md">CallbackEventHelpers</a>.)</td></tr></table>&nbsp;
<a href="#bandwidthxmlcontent-class">Back to Top</a>

## Examples

```
var response = new HttpResponseMessage();
response.Content = new BandwidthXmlContent(new Response( new Hangup() )); // will generate next xml lines 
/*

*/
```


## See Also


#### Reference
<a href ="N_Bandwidth_Net_Xml.md">Bandwidth.Net.Xml Namespace</a><br />