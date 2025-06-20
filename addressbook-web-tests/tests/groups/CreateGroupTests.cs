using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupTests : TestBase
    {
        [Test]
        public void CreateGroup_FullFields()
        {
            GroupData group = new GroupData("Text in name");
            group.Header = "Text in header";
            group.Footer = "Text in footer";

            app.Navigation.GoToGroupsPage();
            app.Groups.Create(group);
            app.Navigation.ReturnToGroupPage();
        }
        [Test]
        public void CreateGroup_WithEmptyFields()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Navigation.GoToGroupsPage();
            app.Groups.Create(group);
            app.Navigation.ReturnToGroupPage();
        }

        [Test]
        [TestCase("", "", "", TestName = "TC_CreateGroup_WithEmptyFieldsTest")]
        [TestCase("Группа 1", "Header", "Footer", TestName = "TC_CreateGroup_FullFieldsTest")]
        [TestCase("OnlyName", "", "", TestName = "TC_CreateGroup_OnlyNameTest")]
        public void CreateGroups_WithTestCaseData(string name, string header, string footer)
        {
            app.Navigation.GoToGroupsPage();
            app.Groups.Create(new GroupData(name, header, footer));
            app.Navigation.ReturnToGroupPage();
        }
    }
}