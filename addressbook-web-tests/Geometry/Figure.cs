﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    internal class Figure
    {
        private bool colored = false;
        public bool Colored
        {
            get
            {
                return colored;
            }
            set
            {
                colored = value;
            }
        }
    }
}
