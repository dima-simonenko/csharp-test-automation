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
        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }

        //   Жёсткий переход по указанной ссылке
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        //   Мягкий переход по гиперссылке
        public void GoToGroupsPage()
        {
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToGroupPage()
        {
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void ReturnToHomePage()
        {
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("home page")).Click();
        }

        //   Поиск по наименованию (передаётся как параметр)
        public void ClickLinkTextName(string name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }

        //   Переход по гиперссылке (передаётся как параметр)
        public void ClickLinkByHref(string href)
        {
            Thread.Sleep(500);
            driver.FindElement(By.XPath($"//a[@href='{href}']")).Click();
        }
    }
}
