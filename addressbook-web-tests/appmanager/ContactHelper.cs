using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactDetails contact, string groupName)
        {
            manager.Navigation.GoToAddNewContactPage();
            FillContactForm(contact);
            SelectGroupFromDropdown(groupName);
            SubmitContactForm();
            manager.Navigation.ReturnToHomePage();
            return this;
        }

        //  Открывает форму редактирования контакта через иконку Edit (карандаш)
        public ContactHelper Edit(int index, ContactDetails newData)
        {
            InitEditContact(index);
            FillContactForm(newData);
            SubmitModificationContact();
            manager.Navigation.ReturnToHomePage();
            return this;
        }

        //  Открывает форму редактирования контакта через Details → Modify
        public ContactHelper Modify(int index, ContactDetails newData)
        {
            InitModifyContact(index);
            FillContactForm(newData);
            SubmitModificationContact();
            manager.Navigation.ReturnToHomePage();
            return this;
        }

        public ContactHelper Delete(int index)
        {
            SelectContactCheckboxByIndex(index);
            SubmitDeleteContact();
            return this;
        }

        public ContactHelper FillContactForm(ContactDetails contact)
        {
            FillPersonalInfo(contact.Personal);
            FillJobInfo(contact.Job);
            FillContactInfo(contact.Contact);
            FillWebInfo(contact.Web);
            FillBirthdayInfo(contact.Birthday);
            FillAnniversaryInfo(contact.Anniversary);
            return this;
        }

        public ContactHelper FillPersonalInfo(PersonalInfo person)
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
            return this;
        }

        public ContactHelper FillJobInfo(JobInfo job)
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
            return this;
        }

        public ContactHelper FillContactInfo(ContactInfo contactInfo)
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
            return this;
        }

        public ContactHelper FillWebInfo(WebInfo web)
        {
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(web.Homepage);
            return this;
        }

        public ContactHelper FillBirthdayInfo(BirthdayInfo bInfo)
        {
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(bInfo.Bday.ToString());
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(bInfo.Bmonth);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(bInfo.Byear.ToString());
            return this;
        }

        public ContactHelper FillAnniversaryInfo(AnniversaryInfo anniversary)
        {
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(anniversary.Aday.ToString());
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(anniversary.Amonth);
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(anniversary.Ayear.ToString());
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            return this;
        }

        public ContactHelper SubmitModificationContact()
        {
            ShortDelay();
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SubmitDeleteContact()
        {
            //driver.FindElement(By.Name("Delete")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        //  Выбор группы из списка (используется только при добавлении контакта)
        public ContactHelper SelectGroupFromDropdown(string groupName)
        {
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(groupName);
            return this;
        }

        public ContactHelper SelectContactCheckboxByIndex(int index)
        {
            driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + index + "]")).Click();
            return this;
        }

        //  На домашней странице клик по иконке "Edit" 
        public ContactHelper InitEditContact(int index)
        {
            var editIcons = driver.FindElements(By.XPath("//img[@alt='Edit']"));
            editIcons[index - 1].Click();
            //driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        //  На домашней странице клик по иконке Details  -> Нажатие на кнопку Modify
        public ContactHelper InitModifyContact(int index)
        {
            OpenDetailsContact(index);
            driver.FindElement(By.Name("modifiy")).Click();
            ShortDelay();
            return this;
        }

        public ContactHelper OpenDetailsContact(int index)
        {
            var detailIcons = driver.FindElements(By.XPath("//img[@alt='Details']"));
            detailIcons[index - 1].Click();
            return this;
        }
    }
}
