#nullable enable
using System.Threading.Tasks;
using NUnit.Framework;
using sms77_library.Api.Library;
using sms77_library.Api.Library.Hooks;
using Action = sms77_library.Api.Library.Hooks.Action;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class Hooks {
        [Test]
        public async Task Read() {
            var paras = new Params {Action = Action.read};

            Read read = await BaseTest.Client.Hooks(paras);

            foreach (var entry in read.Entries) {
                Assert.That(entry.Created, Is.Not.Empty);
                Assert.That(entry.Id, Is.Positive);
                Assert.That(entry.TargetUrl, Is.Not.Empty);
            }
        }

        [Test]
        public async Task Subscribe() {
            foreach (var eventType in Util.GetEnumValues<EventType>()) {
                foreach (var requestMethod in Util.GetEnumValues<RequestMethod>()) {
                    var subscribed = await Subscription(eventType, requestMethod);

                    Assert.That(subscribed.Id, Is.Positive);
                    Assert.That(subscribed.Success, Is.True);

                    System.Threading.Thread.Sleep(250);

                    await Unsubscription(subscribed.Id);

                    System.Threading.Thread.Sleep(250);
                }
            }
        }

        [Test]
        public async Task SubscribeFail() {
            var subscribed = await Subscription(EventType.dlr, RequestMethod.GET, "IamNoValidUrl");

            Assert.That(subscribed.Success, Is.False);
            Assert.That(subscribed.Id, Is.Zero);
        }

        [Test]
        public async Task Unsubscribe() {
            var subscribed = await Subscription(EventType.dlr);
            var unsubscribed = await Unsubscription(subscribed.Id);

            Assert.That(unsubscribed.Success, Is.True);
        }

        private static async Task<Subscription> Subscription(
            EventType eventType,
            RequestMethod requestMethod = RequestMethod.POST,
            string? targetUrl = null) {
            Subscription subscribed = await BaseTest.Client.Hooks(new Params {
                Action = Action.subscribe,
                EventType = eventType,
                RequestMethod = requestMethod,
                TargetUrl = targetUrl ?? TestHelper.CreateRandomUrl()
            });

            return subscribed;
        }

        private static async Task<Unsubscription> Unsubscription(int id) {
            return await BaseTest.Client.Hooks(new Params {
                Action = Action.unsubscribe,
                Id = id
            });
        }
    }
}