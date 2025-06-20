﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ModificationContactTests : TestBase
    {
        [Test]
        public void ModifyContact_ThroughEditIcon()
        {
           ContactDetails newData = new ContactDetails
           (new PersonalInfo
               ("ffdsf", "sdfsf", "sdf", "sdfsdf"),
            new JobInfo
                ("", "", ""),
            new ContactInfo
                ("", "", "", "", "", "", ""),
            new WebInfo
                (""),
            new BirthdayInfo
                (10, "March", 1993),
            new AnniversaryInfo
                (25, "August", 2022));

            app.Contact.Edit(1, newData);
        }
        [Test]
        public void ModifyContact_ThroughDetailsPage()
        {
            ContactDetails newData = new ContactDetails
            (new PersonalInfo
                ("Mod1", "Mod2", "Mod3", "Mod4"),
             new JobInfo
                 ("", "", ""),
             new ContactInfo
                 ("", "", "", "", "", "", ""),
             new WebInfo
                 (""),
             new BirthdayInfo
                 (10, "March", 1993),
             new AnniversaryInfo
                 (25, "August", 2022));

            app.Contact.Modify(1, newData);
        }
    }
}
