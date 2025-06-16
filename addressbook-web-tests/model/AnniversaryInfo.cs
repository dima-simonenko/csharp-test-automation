using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AnniversaryInfo
    {
        private int aday;
        private string amonth;
        private int ayear;

        public AnniversaryInfo(int aday, string amonth, int ayear)
        {
            this.aday = aday;
            this.amonth = amonth;
            this.ayear = ayear;
        }

        public int Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }
        public int Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
    }
}
