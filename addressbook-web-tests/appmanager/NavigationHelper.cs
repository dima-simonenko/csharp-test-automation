using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        // Жёсткий переход на главную страницу по baseURL
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        // Переход по гиперссылке "groups"
        public void GoToGroupsPage()
        {
            ShortDelay();
            driver.FindElement(By.LinkText("groups")).Click();
        }

        // Переход по гиперссылке "add new" на страницу создания контакта
        public void GoToAddNewContactPage()
        {
            ShortDelay();
            driver.FindElement(By.LinkText("add new")).Click();
        }

        // Переход по гиперссылке "group page" после создания/удаления группы
        public void ReturnToGroupPage()
        {
            ShortDelay();
            driver.FindElement(By.LinkText("group page")).Click();
        }

        // Переход по гиперссылке "home page" (после создания контакта)
        public void ReturnToHomePage()
        {
            ShortDelay();
            driver.FindElement(By.LinkText("home page")).Click();
        }

        // Переход по гиперссылке по её видимому тексту (например: "groups", "home")
        public void ClickLinkTextName(string name)
        {
            ShortDelay();
            driver.FindElement(By.LinkText(name)).Click();
        }

        // Переход по значению href
        public void ClickLinkByHref(string href)
        {
            ShortDelay();
            driver.FindElement(By.XPath($"//a[@href='{href}']")).Click();
        }
    }
}
