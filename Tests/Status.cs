using System.Threading.Tasks;
using NUnit.Framework;

namespace Sms77Api.Tests {
    [TestFixture]
    public class Status {
        [Test]
        public async Task Retrieve() {
            Sms77Api.Status status = await BaseTest.Client.Status(new StatusParams {MsgId = TestHelper.MsgId});

            Assert.That(status, Is.InstanceOf(typeof(Sms77Api.Status)));
            Assert.That(status.Code, Is.Not.Empty);
            Assert.That(status.Timestamp, Is.Not.Empty);
        }
    }
}