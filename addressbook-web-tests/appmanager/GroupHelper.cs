using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) 
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigation.GoToGroupsPage();
            InitCreationNewGroup();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigation.ReturnToGroupPage();
            return this;
        }

        public GroupHelper Delete(int index)
        {
            manager.Navigation.GoToGroupsPage();
            SelectGroupCheckboxByIndex(index);
            SubmitDeleteGroup();
            manager.Navigation.ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigation.GoToGroupsPage();
            SelectGroupCheckboxByIndex(index);
            InitEditGroup();
            FillGroupForm(newData);
            SubmitUpdateGroup();
            manager.Navigation.ReturnToGroupPage();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
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
            return this;
        }

        public GroupHelper InitCreationNewGroup()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper InitEditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitUpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper SubmitDeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroupCheckboxByIndex(int index)
        {
            driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + index + "]")).Click();
            return this;
        }
    }
}
