using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sms77Api.Tests {
    [TestFixture]
    public class Analytics {
        private void assertFirstListItem(Sms77Api.Analytics[] analytics) {
            if (0 == analytics.Length) {
                Assert.That(analytics.Length, Is.Zero);
            }
            else {
                var first = analytics.First();

                Assert.That(first, Is.InstanceOf(typeof(Sms77Api.Analytics)));
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
            assertFirstListItem(await BaseTest.Client.Analytics());
        }

        [Test]
        public async Task RetrieveByNonExistingLabel() {
            // TODO: fix API as it returns all msgs if label was not found!

            /*var analytics = await BaseTest.Client.Analytics(
                new AnalyticsParams {Label = "TestLabel"});

            Assert.That(analytics.Count, Is.Zero); */
        }

        [Test]
        public async Task RetrieveByAllSubaccounts() {
            assertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {Subaccounts = "all"}));
        }

        [Test]
        public async Task RetrieveGroupedBy() {
            assertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {GroupBy = "label"}));

            assertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {GroupBy = "subaccount"}));

            assertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {GroupBy = "country"}));
        }

        [Test]
        public async Task RetrieveByTimeFrame() {
            assertFirstListItem(await BaseTest.Client.Analytics(
                new AnalyticsParams {Start = "label", End = "label"}));
        }
    }
}