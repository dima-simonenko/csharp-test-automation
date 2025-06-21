using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContactTests : TestBase
    {
        [Test]
        public void DeleteContact_ExistingContactSelected()
        {
            app.Contact.Delete(1);
        }
    }
}
