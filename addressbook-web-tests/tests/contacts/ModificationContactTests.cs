using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ModificationContactTests : AuthTestBase
    {
        [Test]
        public void ModifyContact_ThroughEditIcon()
        {
            // Precondition
            app.Contact.AddAtLeastOneContact();
            List<ContactDetails> oldContacts = app.Contact.GetContactList();

            ContactDetails newData = new ContactDetails
           (new PersonalInfo
               ("ffdsf", "sdfsf", "sdf", "sdfsdf"),
            new JobInfo
                ("", "", ""),
            new ContactInfo
                ("", "", "", "", "", "", ""),
            new WebInfo
                (""),
            new BirthdayInfo
                (10, "March", 1993),
            new AnniversaryInfo
                (25, "August", 2022));

            // Action
            app.Contact.Modify(0, newData);
            oldContacts[0] = newData;
            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();

            // Verication
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ModifyContact_ThroughDetailsPage()
        {
            // Precondition
            app.Contact.AddAtLeastOneContact();
            List<ContactDetails> oldContacts = app.Contact.GetContactList();

            ContactDetails newData = new ContactDetails
            (new PersonalInfo
                ("Mod1", "Mod2", "Mod3", "Mod4"),
             new JobInfo
                 ("", "", ""),
             new ContactInfo
                 ("", "", "", "", "", "", ""),
             new WebInfo
                 (""),
             new BirthdayInfo
                 (10, "March", 1993),
             new AnniversaryInfo
                 (25, "August", 2022));

            // Action
            app.Contact.Modify(0, newData);
            oldContacts[0] = newData;
            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();

            // Verication
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
