using System;
using System.Threading.Tasks;
using NUnit.Framework;
using seven_library.Api.Library;

namespace Seven.Api.Tests {
    [TestFixture]
    public class Status {
        private readonly StatusParams _statusParams = new StatusParams {MsgId = 77127422642};

        private void AssertStatus(seven_library.Api.Library.Status status) {
            var codes = Enum.GetNames(typeof(StatusCode));
            var pattern = string.Join("|", codes);
            var isValidDate = Util.IsValidDate(status.Timestamp, "yyyy-MM-dd HH:mm:ss.fff");

            StringAssert.IsMatch(pattern, status.Code);
            Assert.That(isValidDate, Is.True);
        }

        [Test]
        public async Task Retrieve() {
            string response = await BaseTest.Client.Status(_statusParams);
            seven_library.Api.Library.Status status = seven_library.Api.Library.Status.FromString(response);

            AssertStatus(status);
        }

        [Test]
        public async Task RetrieveJson() {
            seven_library.Api.Library.Status status = await BaseTest.Client.Status(_statusParams, true);

            AssertStatus(status);
        }
    }
}