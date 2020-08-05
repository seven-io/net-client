using System;
using System.Threading.Tasks;
using Sms77Api.Tests;

namespace Sms77Api.Examples {
    class ValidateForVoice : Base {
        static async Task Retrieve() {
            var paras = new ValidateForVoiceParams {Number = TestHelper.PhoneNumber, Callback = "doma.in/cb.php"};

            Console.WriteLine(await Client.ValidateForVoice(paras));
        }
    }
}