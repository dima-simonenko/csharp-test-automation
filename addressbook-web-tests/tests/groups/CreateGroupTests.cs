using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
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
            GroupData group = new GroupData("Text in name")
            {
                Header = "Text in header",
                Footer = "Text in footer"
            };

            app.Groups.Create(group);
        }
        [Test]
        public void CreateGroup_WithEmptyFields()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            
            app.Groups.Create(group);
        }

        [Test]
        [TestCase("OnlyName", "", "", TestName = "CreateGroup_OnlyNameTest")]
        public void CreateGroup_WithTestCaseData(string name, string header, string footer)
        {
            app.Groups.Create(new GroupData(name, header, footer));
        }
    }
}