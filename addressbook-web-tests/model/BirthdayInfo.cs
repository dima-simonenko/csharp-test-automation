using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class BirthdayInfo
    {
        public BirthdayInfo (int bday, string bmonth, int byear)
        {
            Bday = bday;
            Bmonth = bmonth;
            Byear = byear;
        }

        public int Bday { get; set; }

        public string Bmonth { get; set; }

        public int Byear { get; set; }
    }
}
