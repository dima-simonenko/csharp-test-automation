using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteGroup_ExistingGroupSelected()
        {
            // Precondition
            app.Groups.AddAtLeastOneGroup();


            // Action
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Delete(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);

            // Verification
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}