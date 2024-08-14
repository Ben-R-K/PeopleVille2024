using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bag.Bags
{
    internal class TheFeather : Bag
    {
        public Bag TomatoItem { get; private set; }

        public TheFeather()
        {
            ID = 10;
            Name = "The Feather";
            Price = 100000;
            Weight = 0.023;
        }


    }
}
