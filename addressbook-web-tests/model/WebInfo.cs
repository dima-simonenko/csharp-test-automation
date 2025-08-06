using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class WebInfo
    {
        public WebInfo(string homepage)
        {
            Homepage = homepage;
        }

        public string Homepage { get; set; }
    }
}
