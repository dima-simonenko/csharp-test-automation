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

        public bool CheckEntityPresence()
        {
            manager.Navigation.GoToGroupsPage();
            return driver.FindElements(By.Name("selected[]")).Count > 0;
        }

        public void AddAtLeastOneGroup()
        {
            if (!CheckEntityPresence())
            {
                Create(new GroupData("Default Name")
                {
                    Header = "Default Header",
                    Footer = "Default Footer"
                });
            }
        }

        public GroupHelper Delete(int index)
        {
            manager.Navigation.GoToGroupsPage();
            SelectCheckboxByIndex(index);
            //SelectGroupCheckbox(index);
            SubmitDeleteGroup();
            manager.Navigation.ReturnToGroupPage();
            return this;
        }



        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigation.GoToGroupsPage();
            SelectCheckboxByIndex(index);
            //SelectGroupCheckbox(index);
            InitEditGroup();
            FillGroupForm(newData);
            SubmitUpdateGroup();
            manager.Navigation.ReturnToGroupPage();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        private void ClickButtonByName(string name)
        {
            driver.FindElement(By.Name(name)).Click();
        }

        public GroupHelper InitCreationNewGroup()
        {
            if (IsElementPresent(By.Name("new")))
            {
                driver.FindElement(By.Name("new")).Click();
                ShortDelay();
            }
            else
            {
                throw new Exception("Кнопка 'New group' (name='new') не найдена. Убедись, что ты на странице групп.");
            }
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            if (IsElementPresent(By.Name("submit")))
            {
                driver.FindElement(By.Name("submit")).Click();
                ShortDelay();
            }
            else
            {
                throw new Exception("Кнопка 'Submit' (name='submit') не найдена. Возможно, форма создания не открыта.");
            }
            return this;
        }

        public GroupHelper InitEditGroup()
        {
            if (IsElementPresent(By.Name("edit")))
            {
                driver.FindElement(By.Name("edit")).Click();
                ShortDelay();
            }
            else
            {
                throw new Exception("Кнопка 'Edit' (name='edit') не найдена.");
            }
            return this;
        }

        public GroupHelper SubmitUpdateGroup()
        {
            if (IsElementPresent(By.Name("update")))
            {
                driver.FindElement(By.Name("update")).Click();
                ShortDelay();
            }
            else
            {
                throw new Exception("Кнопка 'Update' (name='update') не найдена.");
            }
            return this;
        }

        public GroupHelper SubmitDeleteGroup()
        {
            if (IsElementPresent(By.Name("delete")))
            {
                driver.FindElement(By.Name("delete")).Click();
                ShortDelay();
            }
            else
            {
                throw new Exception("Кнопка 'Delete' (name='delete') не найдена.");
            }
            return this;
        }

        //public GroupHelper SelectGroupCheckbox(int index)
        //{
        //    driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + index + "]")).Click();
        //    return this;
        //}

        //public GroupHelper SelectGroupCheckbox(int index)
        //{
        //    driver.FindElement(By.XPath("(//input[@name = 'selected[]'])[" + (index+1) + "]")).Click();
        //    return this;
        //}


        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigation.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            
            foreach (IWebElement element in elements) 
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
