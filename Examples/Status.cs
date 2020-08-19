using System;
using System.Threading.Tasks;

namespace Sms77Api.Examples {
    class Status : Base {
        static async Task Retrieve(ulong msgId) {
            var paras = new StatusParams {MsgId = msgId};

            Console.WriteLine(await Client.Status(paras));
        }
    }
}