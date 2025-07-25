using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            ShortDelay();
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.XPath("//h1[text()='Groups']")))
            {
                return;
            }

            ShortDelay();
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToAddNewContactPage()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php"
                && IsElementPresent(By.XPath("//h1[text()='Edit / add address book entry']")))
            {
                return;
            }

            ShortDelay();
            driver.FindElement(By.LinkText("add new")).Click();
        }

        // Переход по гиперссылке "group page", если она отображается после создания/удаления группы
        public void ReturnToGroupPage()
        {
            if (IsElementPresent(By.XPath("//div[@class='msgbox']//a[text()='group page']")))
            {
                driver.FindElement(By.LinkText("group page")).Click();
            }
        }

        // Переход по гиперссылке "home page", если после добавления контакта отображаются  гиперссылки "add next" и "home page"
        public void ReturnToHomePage()
        {
            if (IsElementPresent(By.LinkText("home page")))
            {
                driver.FindElement(By.LinkText("home page")).Click();
            }
        }

        // Переход по гиперссылке по её видимому тексту (например: "groups", "home")
        public void ClickLinkTextName(string name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }

        // Переход по значению href
        public void ClickLinkByHref(string href)
        {
            driver.FindElement(By.XPath($"//a[@href='{href}']")).Click();
        }
    }
}
