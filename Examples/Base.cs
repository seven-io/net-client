using Sms77Api.Tests;

namespace Sms77Api.Examples {
    class Base {
        protected static readonly Client Client = new Client(TestHelper.ApiKey);
    }
}