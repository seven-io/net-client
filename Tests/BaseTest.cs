using System;
using NUnit.Framework;

namespace Sms77Api.Tests {
    [SetUpFixture]
    public class BaseTest {
        internal static Client Client;

        [OneTimeSetUp]
        public void Setup() {
            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SMS77_DUMMY_API_KEY"))) {
                throw new ArgumentNullException("Please set environment variable 'SMS77_DUMMY_API_KEY'!");
            }

            Client = new Client(TestHelper.ApiKey);
        }
    }
}