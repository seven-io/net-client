using System;
using System.Threading.Tasks;
using seven_library.Api.Library;

namespace Seven.Api.Examples {
    class Journal : BaseExample {
        static async Task Inbound() {
            var journalParams = new JournalParams {Type = JournalType.inbound};
            var list = await Client.Journal(journalParams);
            Console.WriteLine(list);
        }
        
        static async Task Outbound() {
            var journalParams = new JournalParams {Type = JournalType.outbound};
            var list = await Client.Journal(journalParams);
            Console.WriteLine(list);
        }
        
        static async Task Replies() {
            var journalParams = new JournalParams {Type = JournalType.replies};
            var list = await Client.Journal(journalParams);
            Console.WriteLine(list);
        }
        
        static async Task Voice() {
            var journalParams = new JournalParams {Type = JournalType.voice};
            var list = await Client.Journal(journalParams);
            Console.WriteLine(list);
        }
    }
}