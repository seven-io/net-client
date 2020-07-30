using NUnit.Framework;

namespace Sms77Api.Tests {
    [SetUpFixture]
    public class BaseTest {
        internal static Client Client;

        [OneTimeSetUp]
        public void Setup() {
            TestHelper.CheckEnvironmentVariable();

            Client = new Client(TestHelper.ApiKey);
        }
    }
}