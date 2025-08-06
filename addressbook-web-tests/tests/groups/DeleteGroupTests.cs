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
            // Precondition: убедиться, что существует хотя бы одна группа
            app.Groups.AddAtLeastOneGroup();
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            // Action: удалить первую группу
            app.Groups.Delete(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            
            List<GroupData> newGroups = app.Groups.GetGroupList();



            // Verification: сравнение списков групп до и после удаления
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}