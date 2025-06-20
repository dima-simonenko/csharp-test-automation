using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Text;
using System.Threading;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        
        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Auth.Logout();
            app.Stop();
        }
    }
}