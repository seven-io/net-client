![](https://www.seven.io/wp-content/uploads/Logo.svg "seven Logo")

# Official C# API Client for [seven](https://www.seven.io)

## Installation

**.NET CLI**
```shell
dotnet add package seven-api
```

**Package Manager**
```shell
Install-Package seven-api
```

**Package Reference**
```xml
<PackageReference Include="seven-api" />
```

**Paket**
```shell
paket add seven-api
```

**F# Interactive**
```shell
#r "nuget: seven-api, 1.2.0"
```


### Example

```c#
using System;
using System.Threading.Tasks;
using Client = Seven.Api.Client;

class Program
{
    static async Task Main()
    {
        var apiKey = Environment.GetEnvironmentVariable("SEVEN_API_KEY");
        var client = new Client(apiKey);
        var balance = await client.Balance();
        Console.WriteLine($"Current account balance: {balance}");
    }
}
```

For [request signing](https://www.seven.io/en/docs/gateway/http-api/signing-of-requests) set the fourth `Client` parameter to your signing secret which you can find in your [developer dashboard](https://app.seven.io/developer).
```csharp
new Client(TestHelper.ApiKey, "CSharp", true, Environment.GetEnvironmentVariable("SEVEN_SIGNING_KEY"));
```

For further examples have a look at the [examples](https://github.com/seven-io/net-client/tree/master/seven-api/Api/Examples).


#### Support
Need help? Feel free to [contact us](https://www.seven.io/en/company/contact).


##### License
[![MIT](https://img.shields.io/badge/License-MIT-teal.svg)](LICENSE)