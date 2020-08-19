using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sms77Api.Tests {
    [TestFixture]
    public class Status {
        private readonly StatusParams _statusParams = new StatusParams {MsgId = 77127422642};

        private void AssertStatus(Sms77Api.Status status) {
            var codes = Enum.GetNames(typeof(StatusCode));
            var pattern = string.Join("|", codes);
            var isValidDate = Util.IsValidDate(status.Timestamp, "yyyy-MM-dd HH:mm:ss.fff");

            StringAssert.IsMatch(pattern, status.Code);
            Assert.That(isValidDate, Is.True);
        }

        [Test]
        public async Task Retrieve() {
            string response = await BaseTest.Client.Status(_statusParams);
            Sms77Api.Status status = Sms77Api.Status.FromString(response);

            AssertStatus(status);
        }

        [Test]
        public async Task RetrieveJson() {
            Sms77Api.Status status = await BaseTest.Client.Status(_statusParams, true);

            AssertStatus(status);
        }
    }
}