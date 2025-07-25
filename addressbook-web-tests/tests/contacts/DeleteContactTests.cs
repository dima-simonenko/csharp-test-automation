using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : AuthTestBase
    {
        [Test]
        public void DeleteContact_ExistingContactSelected()
        {
            // Precondition
            app.Contact.AddAtLeastOneContact();

            // Action
            app.Contact.Delete(1);

            // Verification

        }
    }
}
