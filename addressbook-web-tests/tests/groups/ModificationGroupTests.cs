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
            GroupData oldData = oldGroups[0];


            GroupData newData = new GroupData("Modification Text in Name")
            {
                Header = null,
                Footer = null
            };

            // Action
            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            // Verification
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

        [Test]
        public void ModificationGroup_UpdateExistingGroupDetailsNotNull()
        {
            // Precondition
            app.Groups.AddAtLeastOneGroup();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            GroupData newData = new GroupData("Modification Text in Name")
            {
                Header = "Modification header",
                Footer = "Modification footer"
            };

            // Action
            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            // Verification
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
