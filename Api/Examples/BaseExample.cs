using Sms77.Api.Library;
using Sms77.Api.Tests;

namespace Sms77.Api.Examples {
    class BaseExample {
        protected static readonly Client Client = new Client(TestHelper.ApiKey);
    }
}