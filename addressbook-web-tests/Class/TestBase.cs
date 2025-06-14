using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Threading;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected string baseURL;
        private StringBuilder verificationErrors;

        // ===================================================
        //              1. Жизненный цикл теста
        // ===================================================
        #region Setup / Teardown

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

        #endregion

        // ===================================================
        //              2. Навигация по страницам
        // ===================================================
        #region Навигация

       //   жёсткий переход по указанной ссылке
        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        //   мягкий переход по гиперссылке
        protected void GoToGroupsPage()
        {
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void ReturnToGroupPage()
        {
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void ReturnToHomePage()
        {
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("home page")).Click();
        }

        //Переход по гиперссылке
        protected void ClickLinkByHref(string href)
        {
            Thread.Sleep(500);
            driver.FindElement(By.XPath($"//a[@href='{href}']")).Click();
        }


        #endregion

        // ===================================================
        //              3. Аутентификация
        // ===================================================
        #region Аутентификация

        protected void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        #endregion

        // ===================================================
        //              4. Работа с группами
        // ===================================================
        #region Работа с группами

        //  Инициировать создание группы
        protected void InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }

        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        //   Выбор группы через активацию чек-бокса
        protected void SelectGroupCheckbox(int index)
        {
            driver.FindElement(By.XPath($"//div[@id='content']/form/span[{index}]/input")).Click();
        }

        protected void DeleteGroups()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        //   Выбор группы из списка
        protected void SelectGroupFromDropdown(string groupName)
        {
            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(groupName);
        }

        #endregion

        // ===================================================
        //              5. Работа с контактами
        // ===================================================
        #region Работа с контактами

          //   Создание контакта
        protected void InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void FillContactForm(ContactDetails contact)
        {
            FillPersonalInfo(contact.Personal);
            FillJobInfo(contact.Job);
            FillContactInfo(contact.Contact);
            FillWebInfo(contact.Web);
            FillBirthdayInfo(contact.Birthday);
            FillAnniversaryInfo(contact.Anniversary);
        }

        protected void SubmitAddNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
        }

        //   Заполнение блоков формы
        protected void FillPersonalInfo(PersonalInfo person)
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

        protected void FillJobInfo(JobInfo job)
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

        protected void FillContactInfo(ContactInfo contactInfo)
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

        protected void FillWebInfo(WebInfo web)
        {
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(web.Homepage);
        }

        protected void FillBirthdayInfo(BirthdayInfo bInfo)
        {
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(bInfo.Bday.ToString());
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(bInfo.Bmonth);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(bInfo.Byear.ToString());
        }

        protected void FillAnniversaryInfo(AnniversaryInfo anniversary)
        {
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(anniversary.Aday.ToString());
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(anniversary.Amonth);
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(anniversary.Ayear.ToString());
        }

        #endregion

        // ===================================================
        //              6. Вспомогательные действия
        // ===================================================
        #region Вспомогательные действия

        protected void ClickLinkTextName(string name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }

        #endregion
    }
}
