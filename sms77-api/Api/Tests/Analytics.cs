using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using sms77_library.Api.Library;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class Analytics {
        private static void AssertFirstListItem(sms77_library.Api.Library.Analytics[] analytics) {
            if (0 == analytics.Length) {
                Assert.That(analytics.Length, Is.Zero);
            }
            else {
                var first = analytics.First();

                Assert.That(first, Is.InstanceOf(typeof(sms77_library.Api.Library.Analytics)));
                Assert.That(first.Date, Is.Not.Empty);
                Assert.That(first.Economy, Is.Not.Negative);
                Assert.That(first.Direct, Is.Not.Negative);
                Assert.That(first.Voice, Is.Not.Negative);
                Assert.That(first.Hlr, Is.Not.Negative);
                Assert.That(first.Mnp, Is.Not.Negative);
                Assert.That(first.Inbound, Is.Not.Negative);
                Assert.That(first.UsageEur, Is.TypeOf<double>());
            }
        }

        [Test]
        public async Task RetrieveAll() {
            AssertFirstListItem(await BaseTest.Client.Analytics());
        }

        [Test]
        public async Task RetrieveByNonExistingLabel() {
            // API eturns all msgs if label was not found

            var analytics = await BaseTest.Client.Analytics(
                new AnalyticsParams {Label = "TestLabel"});

            AssertFirstListItem(analytics);
        }

        [Test]
        public async Task RetrieveByAllSubaccounts() {
            AssertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {Subaccounts = "all"}));
        }

        [Test]
        public async Task RetrieveGroupedBy() {
            AssertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {GroupBy = "label"}));

            AssertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {GroupBy = "subaccount"}));

            AssertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {GroupBy = "country"}));
        }

        [Test]
        public async Task RetrieveByTimeFrame() {
            AssertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {Start = "label", End = "label"}));
        }
    }
}