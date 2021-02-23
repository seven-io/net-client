![Sms77.io Logo](https://www.sms77.io/wp-content/uploads/2019/07/sms77-Logo-400x79.png "sms77")

# Official C# API Client for the Sms77.io SMS Gateway

## Installation
Open up a terminal and run the following command:
`dotnet add package sms77-api`

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

For further examples have a look at the [examples](./Api/Examples).


#### Support
Need help? Feel free to [contact us](https://www.sms77.io/en/company/contact/).


##### License
[![MIT](https://img.shields.io/badge/License-MIT-teal.svg)](./LICENSE)