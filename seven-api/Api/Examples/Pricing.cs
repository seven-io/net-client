using System;
using System.Threading.Tasks;
using seven_library.Api.Library;

namespace Seven.Api.Examples {
    class Pricing : BaseExample {
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