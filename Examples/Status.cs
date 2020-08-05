using System;
using System.Threading.Tasks;
using Sms77Api.Tests;

namespace Sms77Api.Examples {
    class Status : Base {
        static async Task Retrieve() {
            var paras = new StatusParams {MsgId = TestHelper.MsgId};

            Console.WriteLine(await Client.Status(paras));
        }
    }
}