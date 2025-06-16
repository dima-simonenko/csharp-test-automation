using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class JobInfo
    {
        private string title;
        private string company;
        private string address;

        public JobInfo(string title, string company, string address)
        {
            this.title = title;
            this.company = company;
            this.address = address;
        }
        public JobInfo(string title, string company)
        {
            this.title = title;
            this.company = company;
        }
        public JobInfo(string company)
        {
            this.company = company;
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
    }
}
