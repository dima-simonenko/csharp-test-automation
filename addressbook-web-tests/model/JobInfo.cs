using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class JobInfo
    {
        public JobInfo(string title, string company, string address)
        {
            Title = title;
            Company = company;
            Address = address;
        }
        public JobInfo(string title, string company)
        {
            Title = title;
            Company = company;
        }
        public JobInfo(string company)
        {
            Company = company;
        }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }
    }
}
