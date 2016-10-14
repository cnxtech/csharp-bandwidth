# CallbackEventHelpers.ReadAsCallbackEventAsync Method 
 

Read CallbackEvent instance from http content

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net.md">Bandwidth.Net</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 3.0.0-beta4

## Syntax

**C#**<br />
``` C#
public static Task<CallbackEvent> ReadAsCallbackEventAsync(
	this HttpContent content
)
```


#### Parameters
&nbsp;<dl><dt>content</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/hh193687" target="_blank">System.Net.Http.HttpContent</a><br />Content</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/dd321424" target="_blank">Task</a>(<a href ="T_Bandwidth_Net_CallbackEvent.md">CallbackEvent</a>)<br />Callback event data or null if response content is not json

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/hh193687" target="_blank">HttpContent</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## Examples

```
var callbackEvent = await response.Content.ReadAsCallbackEventAsync(); // response is instance of HttpResponseMessage
switch(callbackEvent.EventType)
{
  case CallbackEventType.Sms:
    Console.WriteLine($"Sms {callbackEvent.From} -> {callbackEvent.To}: {callbackEvent.Text}");
    break;
}
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_CallbackEventHelpers.md">CallbackEventHelpers Class</a><br /><a href ="N_Bandwidth_Net.md">Bandwidth.Net Namespace</a><br />