using System.Threading.Tasks;
using NUnit.Framework;
using seven_library.Api.Library;

namespace Seven.Api.Tests {
    [TestFixture]
    public class Pricing {
        [Test]
        public async Task TestPricingGlobalCsv() {
            string pricing = await BaseTest.Client.Pricing();

            Assert.That(pricing, Is.Not.Empty);
        }

        [Test]
        public async Task TestPricingGlobalJson() {
            seven_library.Api.Library.Pricing pricing = await BaseTest.Client.Pricing(new PricingParams {Format = "json"});

            Assert.That(pricing, Is.InstanceOf(typeof(seven_library.Api.Library.Pricing)));
            Assert.That(pricing.CountCountries, Is.Positive);
        }

        [Test]
        public async Task TestPricingGermanyCsv() {
            string pricing = await BaseTest.Client.Pricing(new PricingParams {Country = "de"});

            Assert.That(pricing, Is.Not.Empty);
        }

        [Test]
        public async Task TestPricingGermanyJson() {
            seven_library.Api.Library.Pricing pricing = await BaseTest.Client.Pricing(
                new PricingParams {Country = "de", Format = "json"});

            Assert.That(pricing, Is.InstanceOf(typeof(seven_library.Api.Library.Pricing)));
            Assert.That(pricing.CountCountries, Is.EqualTo(1));
        }
    }
}