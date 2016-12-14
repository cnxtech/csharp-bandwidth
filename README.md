# Bandwidth.Net

A .Net client library for the [Bandwidth Application Platform](http://bandwidth.com/products/application-platform?utm_medium=social&utm_source=github&utm_campaign=dtolb&utm_content=_)

The current version is v4.0, released ##. Version 2.15 is available  [here](https://github.com/bandwidthcom/csharp-bandwidth/tree/v2.15).


[![Build on .Net 4.5 (Windows)](https://ci.appveyor.com/api/projects/status/bhv8hs3fx9k6c33i?svg=true)](https://ci.appveyor.com/project/avbel/csharp-bandwidth)
[![Build on .Net Core (Linux)](https://travis-ci.org/bandwidthcom/csharp-bandwidth.svg)](https://travis-ci.org/bandwidthcom/csharp-bandwidth)
[![Coverage Status](https://coveralls.io/repos/github/bandwidthcom/csharp-bandwidth/badge.svg)](https://coveralls.io/github/bandwidthcom/csharp-bandwidth)


[Full API Reference](src/Bandwidth.Net/Help/Home.md)

## Installing the SDK

`Bandwidth.Net` is available on Nuget (Nuget 3.0+ is required):

	Install-Package Bandwidth.Net -Pre

## Supported Versions
`Bandwidth.Net` should work on all levels of .Net Framework 4.5+.

| Version | Support Level |
|---------|---------------|
| <4.5 | Unsupported |
| 4.5 | Supported |
| 4.6 | Supported |
| .Net Core (netstandard1.6)  | Supported |
| PCL (Profile111) | Supported |
| Xamarin (IOS, Android, MonoTouch) | Supported |


## Initialization

Each Bandwidth API has own namespace. You can find interface `I<ApiName>Api` and class which implements this interface `<ApiName>Api` in each such namespace. For example you can see `ICatapultApi` and `CatapultApi` in `Bandwidth.Net.Catapult`.
You should create instance of required api object to use it.

```csharp
using Bandwidth.Net.Catapult;
var catapultApi = new CatapultApi(new CatapultAuthData{UserId = "id", ApiToken="token", ApiSecret="secret"});

// Use api then
var account = await catapultApi.Account.GetAsync();

//Also you can use interface ICatapultApi instead of using api class directly
var api = (ICatapultApi)catapultApi;
var allMyCalls = api.Call.List().ToList();
```

### Catapult API
You should fill next auth data to use Catapult Api.

| Argument  | Description           | Default value                       | Required |
|-------------|-----------------------|-------------------------------------|----------|
| `UserId`    | Your user ID | none                         | Yes      |
| `ApiToken`  | Your API token        | none                         | Yes      |
| `ApiSecret` | Your API secret       | none                         | Yes      |
| `BaseUrl`   | The Bandwidth API URL  | `https://api.catapult.inetwork.com/v1` | No       |

You can find these data on your account page in [the portal](https://catapult.inetwork.com/pages/catapult.jsf).


```csharp
using Bandwidth.Net.Catapult;
var catapultApi = new CatapultApi(new CatapultAuthData{
    UserId = "YOUR_USER_ID",
    ApiToken="YOUR_API_TOKEN",
    ApiSecret="YOUR_API_SECRET"
});
```

#### Lazy evalutions

This library uses lazy evalutions in next cases:
    - Object creation,
    - Get list of objects

##### Object Creation

When you create a bridge, call, message, etc. you will receive instance of `ILazyInstance<>` as result. It allow you to get `Id` of created object and created object on demand via property `Instance`.

```csharp
var application = await catapultApi.Application.CreateAsync(new CreateApplicationData {Name = "MyFirstApp"});

Console.WriteLine(application.Id); //will return Id of created application

Console.WriteLine(application.Instance.Name); //will make request to Catapult API to get application data

Console.WriteLine(application.Instance.Name); //will use cached application's data

```

##### Get list of objects

Executing of methods which returns collections of objects will not execute Catapult API request immediately. THis request will be executed only when you try enumerate items of the collection.

```csharp
var calls = catapultApi.Call.List(); // will not execute any requests to Catapult API here

foreach(var call in calls) // a request to Catapult API will be executed here
{
    Console.WriteLine(call.From);
}

// or

var list = calls.ToList(); // a request to Catapult API will be executed here

```

#####


#### Examples

Send a SMS

```csharp
var message = await catapultApi.Message.SendAsync(new MessageData {
	From = "+12345678901", // This must be a Bandwidth number on your account
	To   = "+12345678902",
	Text = "Hello world."
});
Console.WriteLine($"Message Id is {message.Id}");
```

Make a call

```csharp
var call = await catapultApi.Call.CreateAsync(new CreateCallData {
	From = "+12345678901", // This must be a Bandwidth number on your account
	To   = "+12345678902"
});
Console.WriteLine($"Call Id is {call.Id}");
```


### Iris API
You should fill next auth data to use Iris Api.


| Argument  | Description           | Default value                       | Required |
|-------------|-----------------------|-------------------------------------|----------|
| `AccountId`    | Your Iris account ID | none                         | Yes      |
| `UserName`  | Your user name        | none                         | Yes      |
| `Password` | Your password       | none                         | Yes      |
| `BaseUrl`   | The Bandwidth API URL  | `https://api.inetwork.com/v1.0` | No       |


```csharp
using Bandwidth.Net.Iris;
var irisApi = new IrisApi(new IrisAuthData{
    AccountId = "YOUR_ACCOUNT_ID",
    UserName="YOUR_USER_NAME",
    Password="YOUR_PASSWORD"
});
```

#### Examples

```csharp
// Get user's sites
var sites = await irisApi.Site.ListAsync();

// Return sip peer info for given phone number
var sipInfo = await irisApi.Tn.GetSipPeersAsync("+1234567890");

//Get available phone numbers
var numbers = await client.AvailableNumber.ListAsync(new AvailableNumberQuery{AreaCode = "910"});
```

## Providing feedback

For current discussions on 4.0 please see the [4.0 issues section on GitHub](https://github.com/bandwidthcom/csharp-bandwidth/labels/4.0). To start a new topic on 4.0, please open an issue and use the `4.0` tag. Your feedback is greatly appreciated!


## Build Notes

If you are going to build the library to sources with mobile OSes support you should have installed Xamarin tools.
