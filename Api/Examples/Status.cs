using System;
using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Examples {
    class Status : BaseExample {
        static async Task Retrieve(ulong msgId) {
            var paras = new StatusParams {MsgId = msgId};

            Console.WriteLine(await Client.Status(paras));
        }
    }
}