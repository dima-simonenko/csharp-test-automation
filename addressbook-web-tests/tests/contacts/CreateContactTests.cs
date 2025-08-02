using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateContactTests : AuthTestBase
    {
        [Test]
        public void CreateContact_WithAllFieldsFilled()
        {
            // Precondition
            ContactDetails contact = new ContactDetails
            (new PersonalInfo
                ("Ivan", "Petrovich", "Smirnov", "QwErTy"),
            new JobInfo
                ("QA Lead", "AutomationCorp", "ул. Ленина, д. 10"),
            new ContactInfo
                ("+7(495)987-65-43", "+7(926)111-22-33", "+7(812)333-22-11", "99887766", "alex.ivanov@example.com", "petrov.qa@mail.ru", "test.dev@gmail.com"),
            new WebInfo
                ("https://alexeyqa.dev"),
            new BirthdayInfo
                (10, "March", 1993),
            new AnniversaryInfo
                (25, "August", 2022));

            List<ContactDetails> oldContacts = app.Contact.GetContactList();

            // Action
            app.Contact.Create(contact, "[none]");
            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            // Verification
            Assert.AreEqual(oldContacts, newContacts);
        }
        
        [Test]
        public void CreateContact_WithEmptyFields()
        {
            // Precondition
            ContactDetails contact = new ContactDetails
            (new PersonalInfo
                ("", "", "", ""),
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

            List<ContactDetails> oldContacts = app.Contact.GetContactList();

            // Action
            app.Contact.Create(contact, "[none]");
            List<ContactDetails> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            // Verification
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
