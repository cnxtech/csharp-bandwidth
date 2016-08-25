# Bandwidth.Net

A .Net client library for the [Bandwidth Application Platform](http://bandwidth.com/products/application-platform?utm_medium=social&utm_source=github&utm_campaign=dtolb&utm_content=_)

The current version is v3.0, released ## August, 2016. Version 2.14 is available  [here](https://github.com/bandwidthcom/csharp-bandwidth/tree/v2.14).


[![Build on .Net 4.5 (Windows)](https://ci.appveyor.com/api/projects/status/bhv8hs3fx9k6c33i?svg=true)](https://ci.appveyor.com/project/avbel/csharp-bandwidth)
[![Build on .Net Core (Linux)](https://travis-ci.org/bandwidthcom/csharp-bandwidth.svg)](https://travis-ci.org/bandwidthcom/csharp-bandwidth)
[![Coverage Status](https://coveralls.io/repos/github/bandwidthcom/csharp-bandwidth/badge.svg)](https://coveralls.io/github/bandwidthcom/csharp-bandwidth)


[Full API Reference](src/Bandwidth.Net/Help/Home.md)

## Installing the SDK

`Bandwidth.Net` is available on Nuget (Nuget 3.0+ is required):

	Install-Package Bandwidth.Net

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


## Client initialization

All interaction with the API is done through a class `Client`. The `Client` constructor takes an next options:

| Argument  | Description           | Default value                       | Required |
|-------------|-----------------------|-------------------------------------|----------|
| `userId`    | Your Bandwidth user ID | none                         | Yes      |
| `apiToken`  | Your API token        | none                         | Yes      |
| `apiSecret` | Your API secret       | none                         | Yes      |
| `baseUrl`   | The Bandwidth API URL  | `https://api.catapult.inetwork.com` | No       |

To initialize the `Client` instance, provide your API credentials which can be found on your account page in [the portal](https://catapult.inetwork.com/pages/catapult.jsf).

```csharp
using Bandwidth.Net;

var client = new Client(
	"YOUR_USER_ID", // <-- note, this is not the same as the username you used to login to the portal
	"YOUR_API_TOKEN",
	"YOUR_API_SECRET"
);
```

Your `client` object is now ready to use the API.

### Lazy evalutions

This library uses lazy evalutions in next cases:
    - Object creation,
    - Get list of objects 

#### Object Creation

When you create a bridge, call, message, etc. you will receive instance of `ILazyInstance<>` as result. It allow you to get `Id` of created object and created object on demand via property `Instance`.

```csharp
var application = await client.Application.CreateAsync(new CreateApplicationData {Name = "MyFirstApp"});

Console.WriteLine(application.Id); //will return Id of created application

Console.WriteLine(application.Instance.Name); //will make request to Catapult API to get application data

Console.WriteLine(application.Instance.Name); //will use cached application's data

``` Get list of objects

Executing of methods which returns collections of objects will not execute Catapult API request immediately. THis request will be executed only when you try enumerate items of the collection.

```csharp
var calls = client.Call.List(); // will not execute any requests to Catapult API here

foreach(var call in calls) // a request to Catapult API will be executed here
{
    Console.WriteLine(call.From);
}

// or

var list = calls.ToList(); // a request to Catapult API will be executed here

``` 

#### 


### Examples

Send a SMS

```csharp
var message = await client.Message.SendAsync(new MessageData {
	From = "+12345678901", // This must be a Catapult number on your account
	To   = "+12345678902",
	Text = "Hello world."
});
Console.WriteLine($"Message Id is {message.Id}");
```

Make a call

```csharp
var call = await client.Call.CreateAsync(new CreateCallData {
	From = "+12345678901", // This must be a Catapult number on your account
	To   = "+12345678902"
});
Console.WriteLine($"Call Id is {call.Id}");
```
## Providing feedback

For current discussions on 3.0 please see the [3.0 issues section on GitHub](https://github.com/bandwidthcom/csharp-bandwidth/labels/3.0). To start a new topic on 3.0, please open an issue and use the `3.0` tag. Your feedback is greatly appreciated!

## Rest API Coverage
------------
* [Account](http://ap.bandwidth.com/docs/rest-api/account/)
    * [X] Information
    * [X] Transactions
* [Applications](http://ap.bandwidth.com/docs/rest-api/applications/)
    * [X] List
    * [X] Create
    * [X] Get info
    * [X] Update
    * [X] Delete
* [Available Numbers](http://ap.bandwidth.com/docs/rest-api/available-numbers/)
    * [X] Search Local
    * [X] Buy Local
    * [X] Search Tollfree
    * [X] Buy Tollfree
* [Bridges](http://ap.bandwidth.com/docs/rest-api/bridges/)
    * [X] List
    * [X] Create
    * [X] Get info
    * [X] Update Calls
    * [X] Play Audio
        * [X] Speak Sentence
        * [X] Play Audio File
    * [X] Get Calls
* [Calls](http://ap.bandwidth.com/docs/rest-api/calls/)
    * [X] List all calls
    * [X] Create
    * [X] Get info
    * [X] Update Status
        * [X] Transfer
        * [X] Answer
        * [X] Hangup
        * [X] Reject
    * [X] Play Audio
        * [X] Speak Sentence
        * [X] Play Audio File
    * [X] Send DTMF
    * [X] Events
        * [X] List
        * [X] Get individual info
    * [X] List Recordings
    * [X] List Transciptions
    * [X] Gather
        * [X] Create Gather
        * [X] Get Gather info
        * [X] Update Gather
* [Conferences](http://ap.bandwidth.com/docs/rest-api/conferences/)
    * [X] Create conference
    * [X] Get info for single conference
    * [X] Play Audio
        * [X] Speak Sentence
        * [X] Play Audio File
    * [X] Members
        * [X] Add member
        * [X] List members
        * [X] Update members
            * [X] Mute
            * [X] Remove
            * [X] Hold
        * [X] Play Audio to single member
            * [X] Speak Sentence
            * [X] Play Audio File
* [Domains](http://ap.bandwidth.com/docs/rest-api/domains/)
    * [X] List all domains
    * [X] create domain
    * [X] Delete domain
* [Endpoints](http://ap.bandwidth.com/docs/rest-api/endpoints/)
    * [X] List all endpoints
    * [X] Create Endpoint
    * [X] Get Single Endpoint
    * [X] Update Single Endpoint
    * [X] Delete Single Endpoint
    * [X] Create auth token
* [Errors](http://ap.bandwidth.com/docs/rest-api/errors/)
    * [X] Get all errors
    * [X] Get info on Single Error
* [Intelligence Services](http://ap.bandwidth.com/docs/rest-api/intelligenceservices/)
    * [ ] Number Intelligence
* [Media](http://ap.bandwidth.com/docs/rest-api/media/)
    * [X] List all media
    * [X] Upload media
    * [X] Download single media file
    * [X] Delete single media
* [Messages](http://ap.bandwidth.com/docs/rest-api/messages/)
    * [X] List all messages
    * [X] Send Message
    * [X] Get single message
    * [X] [Batch Messages](http://ap.bandwidth.com/docs/rest-api/messages/#resourcePOSTv1usersuserIdmessages) (single request, multiple messages)
* [Number Info](http://ap.bandwidth.com/docs/rest-api/numberinfo/)
    * [X] Get number info
* [Phone Numbers](http://ap.bandwidth.com/docs/rest-api/phonenumbers/)
    * [X] List all phone numbers
    * [X] Get single phone number
    * [X] Order singe number
    * [X] Update single number
    * [X] Delete number
* [Recordings](http://ap.bandwidth.com/docs/rest-api/recordings/)
    * [X] List all recordings
    * [X] Get single recording info
* [Transciptions](http://ap.bandwidth.com/docs/rest-api/recordingsidtranscriptions/)
    * [X] Create
    * [X] Get info for single transcription
    * [X] Get all transcriptions for a recording
