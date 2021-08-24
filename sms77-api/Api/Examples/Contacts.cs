using System;
using System.Linq;
using System.Threading.Tasks;
using sms77_library.Api.Library;

namespace Sms77.Api.Examples {
    class Contacts : BaseExample {
        public async Task ReadContactCsv() {
            Console.WriteLine(Contact.FromCsv(await Client.Contacts(
                new ContactsParams {Action = ContactsAction.read, Id = 15161613})));
        }

        public async Task ReadContactsCsv() {
            var csv = await Client.Contacts(
                new ContactsParams {Action = ContactsAction.read});

            foreach (var contact in Util.SplitByLine(csv)) {
                Console.WriteLine(Contact.FromCsv(contact));
            }
        }

        public async Task ReadContactJson() {
            Contact[] contacts = await Client.Contacts(
                new ContactsParams {Action = ContactsAction.read, Id = 15161613, Json = true});

            Console.WriteLine(contacts.First());
        }

        public async Task ReadContactsJson() {
            Contact[] contacts = await Client.Contacts(
                new ContactsParams {Action = ContactsAction.read, Json = true});

            foreach (var contact in contacts) {
                Console.WriteLine(contact);
            }
        }

        public async Task WriteContactCsv() {
            Console.WriteLine(WriteContact.FromCsv(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "004901234567890",
                Nick = "Peter Pan"
            })));
        }

        public async Task WriteContactJson() {
            Console.WriteLine(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "004901234567890",
                Nick = "Peter Pan",
                Json = true
            }));
        }

        public async Task EditContactCsv() {
            Console.WriteLine(WriteContact.FromCsv(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "+4901234567890",
                Nick = "PeterPan",
                Id = 6351513
            })));
        }

        public async Task EditContactJson() {
            Console.WriteLine(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "+4901234567890",
                Nick = "PeterPan",
                Id = 63125314,
                Json = true
            }));
        }

        public async Task DelContactCsv() {
            Console.WriteLine(DelContact.FromCsv(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = 13513516
            })));
        }

        public async Task DelContactJson() {
            Console.WriteLine(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = 6134133,
                Json = true
            }));
        }

        public async Task DelNonExistingContactCsv() {
            Console.WriteLine(DelContact.FromCsv(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = 51341255,
            })));
        }

        public async Task DelNonExistingContactJson() {
            Console.WriteLine(await Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = 63653151,
                Json = true
            }));
        }
    }
}