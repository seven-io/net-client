![seven logo](https://www.seven.io/wp-content/uploads/Logo.svg)

# Official .NET API Client

Send SMS, make voice calls, look up phone numbers, and more — via the [seven](https://www.seven.io) API.

[![NuGet Version](https://img.shields.io/nuget/v/seven-library?style=flat-square)](https://www.nuget.org/packages/seven-library)
[![MIT License](https://img.shields.io/badge/License-MIT-teal.svg?style=flat-square)](LICENSE)
![.NET Standard 2.0](https://img.shields.io/badge/.NET-Standard%202.0-blue?style=flat-square)

---

## Prerequisites

- .NET Standard 2.0 compatible project (.NET Core 2.0+, .NET Framework 4.6.1+, .NET 5+)
- A [seven account](https://www.seven.io) with API key ([How to get your API key](https://help.seven.io/en/api-key-access))

## Installation

**.NET CLI**
```shell
dotnet add package seven-library
```

**Package Manager**
```shell
Install-Package seven-library
```

**Package Reference**
```xml
<PackageReference Include="seven-library" />
```

## Quick Start

```csharp
using System;
using System.Threading.Tasks;
using seven_library.Api;

class Program
{
    static async Task Main()
    {
        var client = new Client("YOUR_API_KEY");

        var balance = await client.Balance();
        Console.WriteLine($"Balance: {balance}");

        var sms = await client.Sms(new SmsParams
        {
            To = "+491234567890",
            Text = "Hello from seven!"
        });
    }
}
```

## Usage Examples

### Send SMS

```csharp
var response = await client.Sms(new SmsParams
{
    To = "+491234567890",
    Text = "Hello from seven!",
    From = "MyApp"
});
```

### Text-to-Speech Voice Call

```csharp
var response = await client.Voice(new VoiceParams
{
    To = "+491234567890",
    Text = "Hello, this is a test call from seven."
});
```

### Phone Number Lookup

```csharp
var result = await client.Lookup(new LookupParams
{
    Number = "+491234567890",
    Type = LookupType.mnp,
    Json = true
});
```

### Check Balance

```csharp
var balance = await client.Balance();
```

## All Features

| Feature | Description |
|---------|-------------|
| **SMS** | Send SMS messages |
| **Voice** | Text-to-speech voice calls |
| **RCS** | Send RCS messages |
| **Lookup** | Phone number lookups (HLR, CNAM, MNP, Format) |
| **Contacts** | Manage address book contacts |
| **Hooks** | Manage webhooks |
| **Balance** | Retrieve account balance |
| **Analytics** | Retrieve account analytics |
| **Journal** | Retrieve message journal |
| **Pricing** | Retrieve pricing information |
| **Status** | Retrieve message delivery status |
| **ValidateForVoice** | Validate phone numbers for voice calls |
| **Subaccounts** | Manage subaccounts |

For more examples, see the [examples directory](seven-api/Api/Examples).

## Request Signing

For [request signing](https://www.seven.io/en/docs/gateway/http-api/signing-of-requests) pass your signing secret (found in your [developer dashboard](https://app.seven.io/developer)) as the fourth parameter:

```csharp
var client = new Client("YOUR_API_KEY", "CSharp", false, "YOUR_SIGNING_SECRET");
```

## Support

Need help? Feel free to [contact us](https://www.seven.io/en/company/contact/) or [open an issue](https://github.com/seven-io/net-client/issues).

## License

[![MIT](https://img.shields.io/badge/License-MIT-teal.svg)](LICENSE)
