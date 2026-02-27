<p align="center">
  <img src="https://www.seven.io/wp-content/uploads/Logo.svg" width="250" alt="seven logo" />
</p>

<h1 align="center">Official .NET API Client</h1>

<p align="center">
  Send SMS, make voice calls, look up phone numbers, and more — via the <a href="https://www.seven.io">seven</a> API.
</p>

<p align="center">
  <a href="https://www.nuget.org/packages/seven-library"><img src="https://img.shields.io/nuget/v/seven-library?style=flat-square" alt="NuGet Version" /></a>
  <a href="LICENSE"><img src="https://img.shields.io/badge/License-MIT-teal.svg?style=flat-square" alt="MIT License" /></a>
  <img src="https://img.shields.io/badge/.NET-Standard%202.0-blue?style=flat-square" alt=".NET Standard 2.0" />
</p>

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

## Features

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

For detailed usage of each feature, see the [examples](seven-api/Api/Examples).

## Support

Need help? Feel free to [contact us](https://www.seven.io/en/company/contact/) or [open an issue](https://github.com/seven-io/net-client/issues).

## License

[![MIT](https://img.shields.io/badge/License-MIT-teal.svg)](LICENSE)
