<img src="https://www.seven.io/wp-content/uploads/Logo.svg" width="250" />


# Official .NET API Client for the [seven SMS Gateway](https://www.seven.io)

## Installation

**.NET CLI**
```shell
dotnet add package sms77-api
```

**Package Manager**
```shell
Install-Package sms77-api
```

**Package Reference**
```xml
<PackageReference Include="sms77-api" />
```

**Paket**
```shell
paket add sms77-api
```

**F# Interactive**
```shell
#r "nuget: sms77-api, 1.2.0"
```


### Example

```c#
using System;
using System.Threading.Tasks;
using Client = Sms77.Api.Client;

class Program
{
    static async Task Main()
    {
        var apiKey = Environment.GetEnvironmentVariable("SMS77_API_KEY");
        var client = new Client(apiKey);
        var balance = await client.Balance();
        Console.WriteLine($"Current account balance: {balance}");
    }
}
```


#### Support
Need help? Feel free to [contact us](https://www.sms77.io/en/company/contact/).


##### License
[![MIT](https://img.shields.io/badge/License-MIT-teal.svg)](LICENSE)
