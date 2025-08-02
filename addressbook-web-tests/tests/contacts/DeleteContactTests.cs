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

            // Action
            ContactDetails deleted = oldContacts[0];
            app.Contact.Delete(0);
            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            // Verification

            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void DeleteContact_AllContactsRemoved()
        {
            // Precondition
            app.Contact.AddAtLeastOneContact();
            List<ContactDetails> oldContacts = app.Contact.GetContactList();

            // Action
            app.Contact.DeleteAllContacts();
            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.Clear();

            // Verification
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
