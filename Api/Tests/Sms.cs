using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using sms77_library.Api.Library;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class Sms {
        private readonly string _successCode = "100";

        [Test]
        public async Task Single() {
            Assert.That(await BaseTest.Client.Sms(new SmsParams {
                    Text = "HI2U!",
                    To = TestHelper.MyPhoneNumber,
                    Flash = true,
                    From = TestHelper.PhoneNumber,
                    Delay = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60}",
                    Label = "TestLabel",
                    Ttl = 300000,
                    NoReload = true,
                    PerformanceTracking = true,
                    ForeignId = "MyTestForeignId",
                }),
                Is.EqualTo(_successCode));
        }

        [Test]
        public async Task SingleDetailed() {
            SmsParams paras = new SmsParams
                {Text = "HI2U!", To = TestHelper.MyPhoneNumber, From = TestHelper.PhoneNumber, Details = true};

            AssertDetailed(Util.SplitByLine(await BaseTest.Client.Sms(paras)), paras.Text);
        }

        [Test]
        public async Task SingleReturnMsgId() {
            string[] lines = Util.SplitByLine(await BaseTest.Client.Sms(new SmsParams
                {Text = "HI2U!", To = TestHelper.MyPhoneNumber, From = TestHelper.PhoneNumber, ReturnMsgId = true}));

            Assert.That(lines[0], Is.EqualTo(_successCode));
            Assert.That(lines[1], Is.EqualTo("1234567890"));
        }

        [Test]
        public async Task SingleDetailedWithMsgId() {
            SmsParams paras = new SmsParams {
                Text = "HI2U!", To = TestHelper.MyPhoneNumber, From = TestHelper.PhoneNumber, ReturnMsgId = true,
                Details = true
            };

            string[] lines = Util.SplitByLine(await BaseTest.Client.Sms(paras));

            AssertDetailed(lines.Where((source, index) => index != 1).ToArray(), paras.Text);
        }

        [Test]
        public async Task SingleJson() {
            SmsParams paras = new SmsParams {
                Text = "HI2U!", To = TestHelper.MyPhoneNumber, From = TestHelper.PhoneNumber, Json = true
            };

            AssertJson(await BaseTest.Client.Sms(paras));
        }

        private void AssertJson(sms77_library.Api.Library.Sms sms) {
            bool debug = "true" == sms.Debug;
            double totalPrice = 0;

            foreach (var message in sms.Messages) {
                totalPrice += message.Price;

                AssertMessage(message, debug);
            }

            Assert.That(sms.Balance, Is.Positive);
            Assert.That(sms.Debug, Is.EqualTo(debug ? "true" : "false"));
            Assert.That(sms.Messages, Is.Not.Empty);
            Assert.That(sms.Success, Is.EqualTo(_successCode));
            StringAssert.IsMatch("direct|economy", sms.SmsType);
            Assert.That(sms.TotalPrice, Is.EqualTo(totalPrice));
        }

        private void AssertMessage(Message msg, bool debug) {
            Assert.That(msg.Encoding, Is.Not.Empty);
            Assert.That(msg.Error, Is.Null);
            Assert.That(msg.ErrorText, Is.Null);
            Assert.That(msg.Parts, Is.Positive);
            Assert.That(msg.Recipient, Is.Not.Empty);
            Assert.That(msg.Sender, Is.Not.Empty);
            Assert.That(msg.Success, Is.True);
            Assert.That(msg.Text, Is.Not.Empty);

            if (debug) {
                Assert.That(msg.Id, Is.Null);
                Assert.That(msg.Price, Is.Zero);
            }
            else {
                Assert.That(msg.Id, Is.Positive);
                Assert.That(msg.Price, Is.Positive);
            }
        }

        private void AssertDetailed(string[] lines, string text) {
            Assert.That(lines[0], Is.EqualTo(_successCode));
            StringAssert.StartsWith("Verbucht: ", lines[1]);
            StringAssert.StartsWith("Preis: ", lines[2]);
            StringAssert.StartsWith("Guthaben: ", lines[3]);
            Assert.That(lines[4], Is.EqualTo($"Text: {text}"));
            Assert.That(lines[5], Is.EqualTo("SMS-Typ: direct"));
            Assert.That(lines[6], Is.EqualTo("Flash SMS: false"));
            Assert.That(lines[7], Is.EqualTo("Encoding: gsm"));
            Assert.That(lines[8], Is.EqualTo("GSM0338: true"));
            Assert.That(lines[9], Is.EqualTo("Debug: true"));
        }
    }
}