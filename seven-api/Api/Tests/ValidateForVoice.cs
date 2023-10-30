using System.Threading.Tasks;
using NUnit.Framework;
using seven_library.Api.Library;

namespace Seven.Api.Tests {
    [TestFixture]
    public class ValidateForVoice {
        [Test]
        public async Task Retrieve() {
            seven_library.Api.Library.ValidateForVoice validation =
                await BaseTest.Client.ValidateForVoice(new ValidateForVoiceParams {Number = TestHelper.PhoneNumber});

            Assert.That(validation.Success, Is.True);
            Assert.That(validation.Code, Is.TypeOf<string>());
            Assert.That(validation.Error, Is.Null);
        }

        [Test]
        public async Task RetrieveInvalidNumber() {
            var number = "ThisAintGonnaWork!";

            seven_library.Api.Library.ValidateForVoice validation =
                await BaseTest.Client.ValidateForVoice(new ValidateForVoiceParams {Number = number});

            Assert.That(validation.Success, Is.False);
            Assert.That(validation.Id, Is.Null);
            Assert.That(validation.FormattedOutput, Is.Null);
            Assert.That(validation.Error, Is.Not.Null);
            Assert.That(validation.Voice, Is.False);
            Assert.AreEqual(validation.Sender, number);
        }
    }
}