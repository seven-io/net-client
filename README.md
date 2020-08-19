![Sms77.io Logo](https://www.sms77.io/wp-content/uploads/2019/07/sms77-Logo-400x79.png "sms77")
# sms77io SMS Gateway API Client for C#

## Installation
```
dotnet add package Sms77.Api
```

### Example
```c#
using Client = Sms77.Api.Client;
Client client = new Client("MySuperSecretApiKey!");
double balance = await Client.Balance();
Console.WriteLine($"Current account balance: {balance}");
```