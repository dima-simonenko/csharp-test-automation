using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class BirthdayInfo
    {
        private int bday;
        private string bmonth;
        private int byear;

        public BirthdayInfo (int bday, string bmonth, int byear)
        {
            this.bday = bday;
            this.bmonth = bmonth;
            this.byear = byear;
        }

        public int Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }

        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public int Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
    }
}
