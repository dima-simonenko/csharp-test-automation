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
            ShortDelay();
            manager.Navigation.ReturnToHomePage();
            return this;
        }

        private List<ContactDetails> contactCache = null;
        public List<ContactDetails> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactDetails>();
                manager.Navigation.GoToHomePage();
                ICollection<IWebElement> rows = driver.FindElements(By.Name("entry"));

                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    string lastname = cells[1].Text;
                    string firstname = cells[2].Text;

                    contactCache.Add(new ContactDetails(
                        new PersonalInfo(firstname, "", lastname, ""),
                        new JobInfo("", "", ""),
                        new ContactInfo("", "", "", "", "", "", ""),
                        new WebInfo(""),
                        new BirthdayInfo(0, "", 0),
                        new AnniversaryInfo(0, "", 0)
                    ));
                }
            }

            return new List<ContactDetails>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }
        //public List<ContactDetails> GetContactList()
        //{
        //    List<ContactDetails> contacts = new List<ContactDetails>();
        //    manager.Navigation.GoToHomePage();
        //    ICollection<IWebElement> rows = driver.FindElements(By.Name("entry"));

        //    foreach (IWebElement row in rows)
        //    {
        //        IList<IWebElement> cells = row.FindElements(By.TagName("td"));

        //        string lastName;
        //        if (cells.Count > 1)
        //        {
        //            lastName = cells[1].Text;
        //        }
        //        else
        //        {
        //            lastName = "";
        //        }

        //        string firstName;
        //        if (cells.Count > 2)
        //        {
        //            firstName = cells[2].Text;
        //        }
        //        else
        //        {
        //            firstName = "";
        //        }

        //        contacts.Add(new ContactDetails(new PersonalInfo(firstName, "", lastName, ""), null, null, null, null, null));
        //    }

        //    return contacts;
        //}


        //  Открывает форму редактирования контакта через иконку Edit (карандаш)
        public ContactHelper Edit(int index, ContactDetails newData)
        {
            InitEditContact(index);
            FillContactForm(newData);
            SubmitModificationContact();
            ShortDelay();
            manager.Navigation.ReturnToHomePage();

            contactCache = null;
            return this;
        }

        //  Открывает форму редактирования контакта через Details → Modify
        public ContactHelper Modify(int index, ContactDetails newData)
        {
            InitModifyContact(index);
            FillContactForm(newData);
            SubmitModificationContact();
            ShortDelay();
            manager.Navigation.ReturnToHomePage();

            contactCache = null;
            return this;
        }

        public ContactDetails DefaultContact()
        {
            return new ContactDetails(
                new PersonalInfo("Default", "", "", ""),
                new JobInfo("", "", ""),
                new ContactInfo("", "", "", "", "", "", ""),
                new WebInfo(""),
                new BirthdayInfo(1, "January", 1990),
                new AnniversaryInfo(1, "January", 2000)
            );
        }

        public bool CheckEntityPresence()
        {
            manager.Navigation.GoToHomePage();
            return driver.FindElements(By.Name("selected[]")).Count > 0;
        }

        public void AddAtLeastOneContact()
        {
            if (!CheckEntityPresence())
            {
                Create(DefaultContact(), "[none]");
            }
        }

        public ContactHelper Delete(int index)
        {
            SelectCheckboxByIndex(index);
            SubmitDeleteContact();

            contactCache = null;
            return this;
        }


        public ContactHelper DeleteAllContacts()
        {
            ClickSelectAllCheckbox();
            SubmitDeleteContact();

            contactCache = null;
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
            Type(By.Name("firstname"), person.Firstname);
            Type(By.Name("middlename"), person.Middlename);
            Type(By.Name("lastname"), person.Lastname);
            Type(By.Name("nickname"), person.Nickname);
            return this;
        }

        public ContactHelper FillJobInfo(JobInfo job)
        {
            Type(By.Name("title"), job.Title);
            Type(By.Name("company"), job.Company);
            Type(By.Name("address"), job.Address);
            return this;
        }

        public ContactHelper FillContactInfo(ContactInfo contactInfo)
        {
            Type(By.Name("home"), contactInfo.Home);
            Type(By.Name("mobile"), contactInfo.Mobile);
            Type(By.Name("work"), contactInfo.Work);
            Type(By.Name("fax"), contactInfo.Fax);
            Type(By.Name("email"), contactInfo.Email);
            Type(By.Name("email2"), contactInfo.Email2);
            Type(By.Name("email3"), contactInfo.Email3);
            return this;
        }

        public ContactHelper FillWebInfo(WebInfo web)
        {
            Type(By.Name("homepage"), web.Homepage);
            return this;
        }

        public ContactHelper FillBirthdayInfo(BirthdayInfo bInfo)
        {
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(bInfo.Bday.ToString());

            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(bInfo.Bmonth);

            Type(By.Name("byear"), bInfo.Byear.ToString());
            return this;
        }

        public ContactHelper FillAnniversaryInfo(AnniversaryInfo anniversary)
        {
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(anniversary.Aday.ToString());

            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(anniversary.Amonth);

            Type(By.Name("ayear"), anniversary.Ayear.ToString());
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            if (IsElementPresent(By.CssSelector("input[type='submit']")))
            {
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();
                contactCache = null;
            }
            else
            {
                throw new Exception("При создании контакта не найдена кнопка 'Submit'.");
            }
            return this;
        }

        public ContactHelper SubmitModificationContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitDeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        //  Выбор группы из списка (используется только при добавлении контакта)
        public ContactHelper SelectGroupFromDropdown(string groupName)
        {
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(groupName);
            return this;
        }

        public ContactHelper ClickSelectAllCheckbox()
        {
            if (IsElementPresent(By.Id("MassCB")))
            {
                driver.FindElement(By.Id("MassCB")).Click();
            }
            else
            {
                throw new Exception("Чекбокс 'Select All' (id='MassCB') не найден.");
            }

            return this;
        }

        //  На домашней странице клик по иконке "Edit" 
        public ContactHelper InitEditContact(int index)
        {
            var editIcons = driver.FindElements(By.XPath("//img[@alt='Edit']"));

            if (editIcons.Count >= index)
            {
                editIcons[index - 1].Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Не найден элемент Edit с индексом {index}.");
            }

            return this;
        }

        //  На домашней странице клик по иконке Details  -> Нажатие на кнопку Modify
        public ContactHelper InitModifyContact(int index)
        {
            OpenDetailsContact(index);

            if (IsElementPresent(By.Name("modifiy")))
            {
                driver.FindElement(By.Name("modifiy")).Click();
            }
            else
            {
                throw new Exception("Кнопка 'Modify' не найдена на странице Details.");
            }

            return this;
        }

        public ContactHelper OpenDetailsContact(int index)
        {
            var detailIcons = driver.FindElements(By.XPath("//img[@alt='Details']"));
            //detailIcons[index - 1].Click();
            detailIcons[index].Click();
            return this;
        }
    }
}
