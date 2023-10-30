using System.Threading.Tasks;
using NUnit.Framework;

namespace Seven.Api.Tests {
    [TestFixture]
    public class Balance {
        [Test]
        public async Task TestBalance() {
            double balance = await BaseTest.Client.Balance();

            Assert.That(balance, Is.InstanceOf(typeof(double)));
        }
    }
}