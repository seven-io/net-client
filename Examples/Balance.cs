using System;
using System.Threading.Tasks;

namespace Sms77Api.Examples {
    class Balance {
        static async Task Main() {
            Client client = new Client(Environment.GetEnvironmentVariable("SMS77_DUMMY_API_KEY"));

            Console.WriteLine(await client.Balance());
        }
    }
}