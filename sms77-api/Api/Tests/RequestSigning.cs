using System.Threading.Tasks;
using NUnit.Framework;
using sms77_library.Api.Library;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class RequestSigning {
        [Test]
        public async Task Balance() {
            var balance = await BaseTest.Client.Balance();

            Assert.That(balance, Is.InstanceOf(typeof(double)));
        }
        
        [Test]
        public async Task Sms() {
            var smsParams = new SmsParams {
                Json = true,
                Text = "HI2U",
                To = "491771783130"
            };

            var obj = await BaseTest.Client.Sms(smsParams);

            Assert.AreEqual(obj.GetType(), typeof(sms77_library.Api.Library.Sms)); 
        }
    }
}