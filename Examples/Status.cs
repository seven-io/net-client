using System;
using System.Threading.Tasks;
using Sms77Api.Tests;

namespace Sms77Api.Examples {
    class Status : Base {
        static async Task Retrieve() {
            Console.WriteLine(await Client.Status(TestHelper.MsgId));
        }
    }
}