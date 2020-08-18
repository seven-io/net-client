using System;
using System.Threading.Tasks;

namespace Sms77Api.Examples {
    class Voice : Base {
        public async Task Post() {
            Console.WriteLine(await Client.Voice(Tests.Voice.TextParams));
        }

        public async Task PostXml() {
            Console.WriteLine(await Client.Voice(Tests.Voice.XmlParams));
        }

        public async Task PostAndReturnJson() {
            Console.WriteLine(await Client.Voice(Tests.Voice.TextParams, true));
        }

        public async Task PostXmlAndReturnJson() {
            Console.WriteLine(await Client.Voice(Tests.Voice.XmlParams, true));
        }
    }
}