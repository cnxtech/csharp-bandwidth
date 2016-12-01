# CatapultApi Constructor (CatapultAuthData, IHttp)
 

Contructor

**Namespace:**&nbsp;<a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult</a><br />**Assembly:**&nbsp;Bandwidth.Net (in Bandwidth.Net.dll) Version: 4.0.0

## Syntax

**C#**<br />
``` C#
public CatapultApi(
	CatapultAuthData authData,
	IHttp http
)
```


#### Parameters
&nbsp;<dl><dt>authData</dt><dd>Type: <a href ="T_Bandwidth_Net_Catapult_CatapultAuthData.md">Bandwidth.Net.Catapult.CatapultAuthData</a><br />Auth data</dd><dt>http</dt><dd>Type: <a href ="T_Bandwidth_Net_IHttp.md">Bandwidth.Net.IHttp</a><br />object which implements http requests handling (usefull for tests)</dd></dl>

## Examples

```
var api = new CatapultApi(new CatapultAuthData{UserId = "userId", ApiToken = "token", ApiSecret = "secret"}, new YourMockHttp());
```


## See Also


#### Reference
<a href ="T_Bandwidth_Net_Catapult_CatapultApi.md">CatapultApi Class</a><br /><a href ="Overload_Bandwidth_Net_Catapult_CatapultApi__ctor.md">CatapultApi Overload</a><br /><a href ="N_Bandwidth_Net_Catapult.md">Bandwidth.Net.Catapult Namespace</a><br />