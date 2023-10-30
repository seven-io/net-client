using System.Threading.Tasks;
using NUnit.Framework;
using seven_library.Api.Library;

namespace Seven.Api.Tests {
    [TestFixture]
    public class Voice {
        public static readonly VoiceParams TextParams = new VoiceParams {
            From = TestHelper.PhoneNumber,
            Text = "HI2U",
            To = TestHelper.PhoneNumber,
        };

        public static readonly VoiceParams XmlParams = new VoiceParams {
            From = TestHelper.PhoneNumber,
            Text = "<?xml version='1.0' encoding='UTF-8'?><Response><Say>Thanks for calling!</Say></Response>",
            To = TestHelper.PhoneNumber,
            Xml = true
        };

        private void AssertResponseObject(seven_library.Api.Library.Voice voice) {
            Assert.That(voice.Code, Is.TypeOf<ushort>());
            Assert.That(voice.Id, Is.TypeOf<uint>());
            Assert.That(voice.Cost, Is.TypeOf<double>());
        }

        [Test]
        public async Task Post() {
            AssertResponseObject(new seven_library.Api.Library.Voice(await BaseTest.Client.Voice(TextParams)));
        }

        [Test]
        public async Task PostXml() {
            AssertResponseObject(new seven_library.Api.Library.Voice(await BaseTest.Client.Voice(XmlParams)));
        }

        [Test]
        public async Task PostAndReturnJson() {
            AssertResponseObject(await BaseTest.Client.Voice(TextParams, true));
        }

        [Test]
        public async Task PostXmlAndReturnJson() {
            AssertResponseObject(await BaseTest.Client.Voice(XmlParams, true));
        }
    }
}