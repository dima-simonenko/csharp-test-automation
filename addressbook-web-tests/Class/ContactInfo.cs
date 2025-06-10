using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactInfo
    {
        private string home;
        private string mobile;
        private string work;
        private string fax;
        private string email;
        private string email2;
        private string email3;

        public ContactInfo(string home, string mobile, string work, string fax, string email, string email2, string email3)
        {
            this.home = home;
            this.mobile = mobile;
            this.work = work;
            this.fax = fax;
            this.email = email;
            this.email2 = email2;
            this.email3 = email3;
        }
        public ContactInfo(string mobile, string email)
        {
            this.mobile = mobile;
            this.email = email;
        }
        public ContactInfo(string mobile)
        {
            this.mobile = mobile;
        }

        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

    }
}
