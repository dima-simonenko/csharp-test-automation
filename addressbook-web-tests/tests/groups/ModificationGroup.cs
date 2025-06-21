using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void ModificationGroup_UpdateExistingGroupDetails()
        {
            GroupData newData = new GroupData("Modification name")
            {
                Header = "Modification header",
                Footer = "Modification footer"
            };
            app.Groups.Modify(1, newData);
        }
    }
}
