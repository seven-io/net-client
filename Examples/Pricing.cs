using System;
using System.Threading.Tasks;

namespace Sms77Api.Examples {
    class Pricing : Base {
        static async Task RetrieveAllAsCsv() {
            Console.WriteLine(await Client.Pricing());
        }

        static async Task RetrieveCountryGermanyAsCsv() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Country = "de"}));
        }

        static async Task RetrieveAllAsJson() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Format = "json"}));
        }

        static async Task RetrieveCountryGermanyAsJson() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Format = "json", Country = "de"}));
        }
    }
}