# Bandwidth.Net
[![Build on .Net 4.5 (Windows)](https://ci.appveyor.com/api/projects/status/bhv8hs3fx9k6c33i?svg=true)](https://ci.appveyor.com/project/avbel/csharp-bandwidth)
[![Build on .Net Core (Linux)](https://travis-ci.org/bandwidthcom/csharp-bandwidth.svg)](https://travis-ci.org/bandwidthcom/csharp-bandwidth)
[![Coverage Status](https://coveralls.io/repos/github/bandwidthcom/csharp-bandwidth/badge.svg)](https://coveralls.io/github/bandwidthcom/csharp-bandwidth)

.NET library for [Bandwidth's App Platform](http://ap.bandwidth.com/?utm_medium=social&utm_source=github&utm_campaign=dtolb&utm_content=)


With Bandwidth.Net  you have access to the entire set of API methods including:
* **Account** - get user's account data and transactions,
* **Application** - manage user's applications,
* **AvailableNumber** - search free local or toll-free phone numbers,
* **Bridge** - control bridges between calls,
* **Call** - get access to user's calls,
* **Conference** - manage user's conferences,
* **ConferenceMember** - make actions with conference members,
* **Domain** - get access to user's domains,
* **EntryPoint** - control of endpoints of domains,
* **Error** - list of errors,
* **Media** - list, upload and download files to Bandwidth API server,
* **Message** - send SMS/MMS, list messages,
* **NumberInfo** - receive CNUM info by phone number,
* **PhoneNumber** - get access to user's phone numbers,
* **Recording** - mamange user's recordings.

Also you can work with Bandwidth XML using special types (in namespaces `Bandwidth.Net.Xml` and `Bandwidth.Net.Xml.Verbs`). 
## Install

Run

```
nuget install Bandwidth.Net
```

Or install `Bandwidth.Net` via UI in Visual Studio.
## Getting Started

* Install `Bandwidth.Net`,
* **Get user id, api token and secret** - to use the Catapult API you need these data.  You can get them [here](https://catapult.inetwork.com/pages/catapult.jsf) on the tab "Account",
* **Set user id, api token and secret** - you can do that with 2 ways:

```
//Using client directly
var client = Client.GetInstance("userId", "apiToken", "apiSecret");

//Or you can use default client instance.
//Do that only once
Client.GlobalOptions = new ClientOptions
{
    UserId = "userId",
    ApiToken = "apiToken",
    ApiSecret = "apiSecret"
};


```
## Usage

All static functions support 2 ways to be called: with client instance as first arg or without client instance (default client instance will be used then)

```
//Using client directly
var client = Client.GetInstance("userId", "apiToken", "apiSecret");
var call = await Call.List(client, new Dictionary<string, object>{{"page", 1}});

//Or you can use default client instance.
//You should set up its global options before using of api functions.

var call = await Call.List(new Dictionary<string, object>{{"page", 1}});

```
Read [Catapult Api documentation](https://catapult.inetwork.com/docs/api-docs/) for more details

## Examples
*All examples assume you have already setup your auth data!*

List all calls from special number

```csharp
  var list = await Call.List(new Dictionary<string, object>{{"from", "+19195551212"}});
```

List all received messages

```csharp
  var messages = await Message.List(new Dictionary<string, object>{{"state", "received"}});
```

Send SMS

```csharp
  var message = await Message.Create(new Dictionary<string, object>{{"from", "+19195551212"}, {"to", "+191955512142"}, {"text", "Test"}});
```

Send some SMSes

```csharp
  var messages = new[]
  {
   new Dictionary<string, object>
   {
     {"to", "+19195551214"},
     {"from", "+19195551212"},
     {"text", "Test1"}
   },
   new Dictionary<string, object>
   {
     {"to", "+19195551215"},
     {"from", "+19195551213"},
     {"text", "Test2"}
   }
  };
  var results =  await Message.Create(client, messages);
```


Upload file 

```csharp
  await Media.Upload("avatar.png", fileStream, "image/png");
```

Make a call

```csharp
  var call = await Call.Create(new Dictionary<string, object>{{"from", "+19195551212"}, {"to", "+191955512142"}});
```

Reject incoming call

```csharp
  await call.RejectIncoming();
```

Play audio to a call

```csharp
  await call.PlayRecording("http://url/to/recording");
```

Create a gather
```csharp
    var gather = await call.CreateGather(new Dictionary<string,object>{{"maxDigits", 3}, {"interDigitTimeout", 5}, {"prompt": new Dictionary<string,object>{{"sentence": "Please enter 3 digits"}}}});
```

Start a conference
```csharp
  var conference = await Conference.Create(new Dictionary<string,object>{{"from", "+19195551212"}});
```
Connect 2 calls to a bridge

```csharp
  var bridge = await Bridge.Create(new Dictionary<string, object>{{"callIds", new[]{callId1, callId2}}});
```

Search available local numbers to buy

```csharp
  var numbers = await AvailableNumber.SearchLocal(new Dictionary<string, object>{{"state", "NC"}, {"city", "Cary"}});
```
Get CNAM info for a number

```csharp
  var info = await NumberInfo.Get("+19195551212");
```

Buy a phone number

```csharp
  var number = await PhoneNumber.Create(new Dictionary<string, object>{{"number", "+19195551212"}});
```

List recordings

```csharp
  var list = await Recording.List();
```


Generate Bandwidth XML

```csharp
    var response = new Response();
    var speakSentence = new SpeakSentence{Sentence = "Transferring your call, please wait.", Voice = "paul", Gender = "male", Locale = "en_US"};
    var transfer = new Transfer
    {
        TransferTo = "+13032288879", 
        TransferCallerId = "private",
        SpeakSentence = new SpeakSentence
        {
            Sentence = "Inner speak sentence.",
            Voice = "paul",
            Gender = "male",
            Locale = "en_US"
        }
    };
    var hangup = new Hangup();

    response.Add(speakSentence);
    response.Add(transfer);
    response.Add(hangup);

    //as alternative we can pass list of verbs to constructor of Response
    //response = new Response(speakSentence, transfer, hangup);

    Console.WriteLine(response.ToXml());

```



See directory `Samples` for more examples.
See [csharp-bandwidth-example](https://github.com/bandwidthcom/csharp-bandwidth-example) for more complex examples of using this module.


	
	
