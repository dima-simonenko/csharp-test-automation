using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

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
            app.Groups.Delete(1);

            // Verification

        }
    }
}