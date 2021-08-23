using System;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Tests;

namespace Sms77.Api.Examples {
    class ValidateForVoice : BaseExample {
        static async Task Retrieve() {
            var paras = new ValidateForVoiceParams {Number = TestHelper.PhoneNumber, Callback = "doma.in/cb.php"};

            Console.WriteLine(await Client.ValidateForVoice(paras));
        }
    }
}