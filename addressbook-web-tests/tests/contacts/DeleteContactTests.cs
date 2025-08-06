using NUnit.Framework;
using System.Collections.Generic;
namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : AuthTestBase
    {
        [Test]
        public void DeleteContact_ExistingContactSelected()
        {
            // Precondition
            app.Contact.AddAtLeastOneContact();
            List<ContactDetails> oldContacts = app.Contact.GetContactList();
            ContactDetails deleted = oldContacts[0];

            // Action
            app.Contact.Delete(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            // Verification

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactDetails contact in newContacts)
            {
                Assert.AreNotEqual(deleted.Id, contact.Id);
            }
        }

        [Test]
        public void DeleteContact_AllContactsRemoved()
        {
            // Precondition
            app.Contact.AddAtLeastOneContact();
            List<ContactDetails> oldContacts = app.Contact.GetContactList();
            ContactDetails deleted = oldContacts[0];

            // Action
            app.Contact.DeleteAllContacts();
            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.Clear();

            // Verification
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactDetails contact in newContacts)
            {
                Assert.AreNotEqual(deleted.Id, contact.Id);
            }
        }
    }
}
