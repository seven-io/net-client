using System;
using System.Threading.Tasks;

namespace Sms77Api.Examples {
    class Pricing : Base {
        static async Task RetrieveAllAsCsv() {
            Console.WriteLine(await Client.Pricing());
        }

        static async Task RetrieveCountryGermanyAsCsv() {
            Console.WriteLine(await Client.Pricing(ResponseFormat.Csv, "de"));
        }

        static async Task RetrieveAllAsJson() {
            Console.WriteLine(await Client.Pricing(ResponseFormat.Json));
        }

        static async Task RetrieveCountryGermanyAsJson() {
            Console.WriteLine(await Client.Pricing(ResponseFormat.Json, "de"));
        }
    }
}