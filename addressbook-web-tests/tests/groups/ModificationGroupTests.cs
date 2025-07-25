using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Action
            GroupData newData = new GroupData("Modification Text in Name")
            {
                Header = null,
                Footer = null
            };
            app.Groups.Modify(1, newData);

            // Verification

        }

        [Test]
        public void ModificationGroup_UpdateExistingGroupDetailsNotNull()
        {
            // Precondition
            app.Groups.AddAtLeastOneGroup();

            // Action
            GroupData newData = new GroupData("Modification Text in Name")
            {
                Header = "Modification header",
                Footer = "Modification footer"
            };
            app.Groups.Modify(1, newData);

            // Verification

        }
    }
}
