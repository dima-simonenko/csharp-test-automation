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
            ContactDetails oldData = oldContacts[0];

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

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts[0] = newData;
            oldContacts.Sort();
            newContacts.Sort();

            // Verication
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactDetails contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Personal.Firstname, contact.Personal.Firstname);
                    Assert.AreEqual(newData.Personal.Lastname, contact.Personal.Lastname);
                }
            }
        }

        [Test]
        public void ModifyContact_ThroughDetailsPage()
        {
            // Precondition
            app.Contact.AddAtLeastOneContact();
            List<ContactDetails> oldContacts = app.Contact.GetContactList();
            ContactDetails oldData = oldContacts[0];

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

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts[0] = newData;
            oldContacts.Sort();
            newContacts.Sort();

            // Verication
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactDetails contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Personal.Firstname, contact.Personal.Firstname);
                    Assert.AreEqual(newData.Personal.Lastname, contact.Personal.Lastname);
                }
            }

        }
    }
}
