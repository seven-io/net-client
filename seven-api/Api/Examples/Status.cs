using System;
using System.Threading.Tasks;
using seven_library.Api.Library;

namespace Seven.Api.Examples {
    class Status : BaseExample {
        static async Task Retrieve(ulong msgId) {
            var paras = new StatusParams {MsgId = msgId};

            Console.WriteLine(await Client.Status(paras));
        }
    }
}