using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AnniversaryInfo
    {
        public AnniversaryInfo(int aday, string amonth, int ayear)
        {
            Aday = aday;
            Amonth = amonth;
            Ayear = ayear;
        }

        public int Aday { get; set; }

        public string Amonth { get; set; }

        public int Ayear { get; set; }
    }
}
