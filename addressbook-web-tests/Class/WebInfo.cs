using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    internal class WebInfo
    {
        private string homepage;

        public WebInfo(string homepage)
        {
            this.homepage = homepage;
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
    }
}
