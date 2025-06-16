using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContactTests : TestBase
    {
        [Test]
        public void AddNewContact()
        {
            //app.navigationHelper.OpenHomePage();
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.InitNewContact();
            //contactHelper.InitNewContact();

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

            app.Contact.FillContactForm(contact);
            app.Contact.SelectGroupFromDropdown("[none]");
            app.Contact.SubmitAddNewContact();
            app.Navigation.ReturnToHomePage();
            app.Auth.Logout();
        }
}
    }
