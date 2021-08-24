using System;
using System.Threading.Tasks;
using NUnit.Framework;
using sms77_library.Api.Library;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class Status {
        private readonly StatusParams _statusParams = new StatusParams {MsgId = 77127422642};

        private void AssertStatus(sms77_library.Api.Library.Status status) {
            var codes = Enum.GetNames(typeof(StatusCode));
            var pattern = string.Join("|", codes);
            var isValidDate = Util.IsValidDate(status.Timestamp, "yyyy-MM-dd HH:mm:ss.fff");

            StringAssert.IsMatch(pattern, status.Code);
            Assert.That(isValidDate, Is.True);
        }

        [Test]
        public async Task Retrieve() {
            string response = await BaseTest.Client.Status(_statusParams);
            sms77_library.Api.Library.Status status = sms77_library.Api.Library.Status.FromString(response);

            AssertStatus(status);
        }

        [Test]
        public async Task RetrieveJson() {
            sms77_library.Api.Library.Status status = await BaseTest.Client.Status(_statusParams, true);

            AssertStatus(status);
        }
    }
}