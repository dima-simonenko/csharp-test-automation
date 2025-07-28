using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupTests : AuthTestBase
    {
        [Test]
        public void CreateGroup_FullFields()
        {
            // Precondition
            GroupData group = new GroupData("Text in name")
            {
                Header = "Text in header",
                Footer = "Text in footer"
            };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            // Action
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            // Verification
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void CreateGroup_WithEmptyFields()
        {
            // Precondition
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            // Action
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            // Verification
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void CreateGroup_WithSpecialCharactersInName()
        {
            // Precondition
            GroupData group = new GroupData("'test")
            {
                Header = "",
                Footer = ""
            };
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            // Action
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            // Verification
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        [TestCase("OnlyName", "", "", TestName = "CreateGroup_OnlyNameTest")]
        public void CreateGroup_WithTestCaseData(string name, string header, string footer)
        {
            // Precondition
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            // Action
            app.Groups.Create(new GroupData(name, header, footer));
            List<GroupData> newGroups = app.Groups.GetGroupList();

            // Verification
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}