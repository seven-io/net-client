using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sms77Api.Tests {
    [TestFixture]
    public class Contacts {
        private const int WriteEditContactId = 3172517;
        private const int DelContactId = 4798034;
        private const int NonExistingContactId = 0000000;
        private const int ErrorCode = 151;
        private const int SuccessCode = 152;

        private void AssertContact(Contact contact) {
            Assert.That(contact.Number, Is.Not.Null);
            Assert.That(contact.Name, Is.Not.Null);
            Assert.That(contact.Id, Is.Positive);
        }

        private void AssertDelContact(DelContact contact) {
            Assert.That(contact.Return, Is.EqualTo(SuccessCode));
        }

        private void AssertDelNonExistingContact(DelContact contact) {
            Assert.That(contact.Return, Is.EqualTo(ErrorCode));
        }

        private void AssertWriteContact(WriteContact contact) {
            Assert.That(contact.Return, Is.EqualTo(SuccessCode));
            Assert.That(contact.Id, Is.Positive);
        }

        [Test]
        public async Task ReadContactCsv() {
            ContactsParams paras = new ContactsParams {Action = ContactsAction.read, Id = WriteEditContactId};
            string response = await BaseTest.Client.Contacts(paras);
            Contact contact = Contact.FromCsv(response);

            AssertContact(contact);
        }

        [Test]
        public async Task ReadContactsCsv() {
            var csv = await BaseTest.Client.Contacts(
                new ContactsParams {Action = ContactsAction.read});

            foreach (var contact in Util.SplitByLine(csv)) {
                AssertContact(Contact.FromCsv(contact));
            }
        }

        [Test]
        public async Task ReadContactJson() {
            Contact[] contacts = await BaseTest.Client.Contacts(
                new ContactsParams {Action = ContactsAction.read, Id = WriteEditContactId, Json = true});

            AssertContact(contacts.First());
        }

        [Test]
        public async Task ReadContactsJson() {
            Contact[] contacts = await BaseTest.Client.Contacts(
                new ContactsParams {Action = ContactsAction.read, Json = true});

            foreach (var contact in contacts) {
                AssertContact(contact);
            }
        }

        [Test]
        public async Task WriteContactCsv() {
            AssertWriteContact(WriteContact.FromCsv(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "004901234567890",
                Nick = "Peter Pan"
            })));
        }

        [Test]
        public async Task WriteContactJson() {
            AssertWriteContact(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "004901234567890",
                Nick = "Peter Pan",
                Json = true
            }));
        }

        [Test]
        public async Task EditContactCsv() {
            AssertWriteContact(WriteContact.FromCsv(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "+4901234567890",
                Nick = "PeterPan",
                Id = WriteEditContactId
            })));
        }

        [Test]
        public async Task EditContactJson() {
            AssertWriteContact(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "+4901234567890",
                Nick = "PeterPan",
                Id = WriteEditContactId,
                Json = true
            }));
        }

        [Test]
        public async Task DelContactCsv() {
            AssertDelContact(DelContact.FromCsv(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = DelContactId
            })));
        }

        [Test]
        public async Task DelContactJson() {
            AssertDelContact(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = DelContactId,
                Json = true
            }));
        }

        [Test]
        public async Task DelNonExistingContactCsv() {
            AssertDelNonExistingContact(DelContact.FromCsv(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = NonExistingContactId,
            })));
        }

        [Test]
        public async Task DelNonExistingContactJson() {
            AssertDelNonExistingContact(await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = NonExistingContactId,
                Json = true
            }));
        }
    }
}