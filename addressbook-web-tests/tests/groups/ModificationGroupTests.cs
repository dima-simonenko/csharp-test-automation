using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ModificationGroupTests : AuthTestBase
    {
        [Test]
        public void ModificationGroup_UpdateExistingGroupDetails()
        {
            // Precondition
            app.Groups.AddAtLeastOneGroup();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newData = new GroupData("Modification Text in Name")
            {
                Header = null,
                Footer = null
            };

            // Action
            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0] = newData;

            // Verification
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void ModificationGroup_UpdateExistingGroupDetailsNotNull()
        {
            // Precondition
            app.Groups.AddAtLeastOneGroup();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newData = new GroupData("Modification Text in Name")
            {
                Header = "Modification header",
                Footer = "Modification footer"
            };

            // Action
            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0] = newData;

            // Verification
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
