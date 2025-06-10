using System;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddNewContactTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheAddNewContact()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContact();

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

            FillContactForm(contact);
            SelectGroup("[none]");
            SubmitAddNewContact();
            ReturnToHomePage();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        private void  InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }


        private void FillContactForm(ContactDetails contact)
        {
            FillPersonalInfo(contact.Personal);
            FillJobInfo(contact.Job);
            FillContactInfo(contact.Contact);
            FillWebInfo(contact.Web);
            FillBirthdayInfo(contact.Birthday);
            FillAnniversaryInfo(contact.Anniversary);
        }

        private void FillPersonalInfo(PersonalInfo person)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(person.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(person.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(person.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(person.Nickname);
        }

        private void FillJobInfo(JobInfo job)
        {
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(job.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(job.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(job.Address);
        }

        private void FillContactInfo(ContactInfo contactInfo)
        {
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contactInfo.Home);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contactInfo.Mobile);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contactInfo.Work);
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contactInfo.Fax);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contactInfo.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contactInfo.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contactInfo.Email3);
        }

        private void FillWebInfo(WebInfo web)
        {
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(web.Homepage);
        }

        private void FillBirthdayInfo(BirthdayInfo bInfo)
        {
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(bInfo.Bday.ToString());
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(bInfo.Bmonth);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(bInfo.Byear.ToString());
        }

        private void FillAnniversaryInfo(AnniversaryInfo anniversary)
        {
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(anniversary.Aday.ToString());
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(anniversary.Amonth);
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(anniversary.Ayear.ToString());
        }
        private void SelectGroup(string groupName)
        {
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(groupName);
        }

        private void SubmitAddNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }

        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
