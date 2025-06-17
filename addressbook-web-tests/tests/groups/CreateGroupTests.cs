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
        public void CreateGroup()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigation.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();
            app.Groups.FillGroupForm(new GroupData("TEST", "текст в поле group header (logo)", "текст в поле group footer (comment)"));
            app.Groups.SubmitGroupCreation();
            app.Navigation.ReturnToGroupPage();
            app.Auth.Logout();
        }
    }
}