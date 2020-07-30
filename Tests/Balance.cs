using System.Threading.Tasks;
using NUnit.Framework;

namespace Sms77Api.Tests {
    [TestFixture]
    [Parallelizable]
    public class Balance {
        [Test]
        [Parallelizable]
        public async Task TestAccountCopyIndexSameApp() {
            double balance = await BaseTest.Client.Balance();

            Assert.That(balance, Is.InstanceOf(typeof(double)));
        }
    }
}