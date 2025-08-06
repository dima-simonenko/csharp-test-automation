using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactInfo
    {
        public ContactInfo(string home, string mobile, string work, string fax, string email, string email2, string email3)
        {
            Home = home;
            Mobile = mobile;
            Work = work;
            Fax = fax;
            Email = email;
            Email2 = email2;
            Email3 = email3;
        }
        public ContactInfo(string mobile, string email)
        {
            Mobile = mobile;
            Email = email;
        }
        public ContactInfo(string mobile)
        {
            Mobile = mobile;
        }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }
        
        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

    }
}
