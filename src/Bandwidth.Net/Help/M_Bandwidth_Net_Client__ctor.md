# Client Constructor 
 

Constructor

**Namespace:**&nbsp;<a href="N_Bandwidth_Net">Bandwidth.Net</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 1.0.0

## Syntax

**C#**<br />
``` C#
public Client(
	string userId,
	string apiToken,
	string apiSecret,
	IHttp http = null
)
```


#### Parameters
&nbsp;<dl><dt>userId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Id of user on Catapult API</dd><dt>apiToken</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Authorization token of Catapult API</dd><dt>apiSecret</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Authorization secret of Catapult API</dd><dt>http (Optional)</dt><dd>Type: <a href="T_Bandwidth_Net_IHttp">Bandwidth.Net.IHttp</a><br />Optional processor of http requests. Use it to owerwrite default http request processing (useful for test, logs, etc)</dd></dl>

## See Also


#### Reference
<a href="T_Bandwidth_Net_Client">Client Class</a><br /><a href="N_Bandwidth_Net">Bandwidth.Net Namespace</a><br />