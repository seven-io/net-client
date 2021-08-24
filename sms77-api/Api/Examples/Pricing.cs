using System;
using System.Threading.Tasks;
using sms77_library.Api.Library;

namespace Sms77.Api.Examples {
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