using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Interfaces
{
    internal interface IItem
    {
        string Name { get; set; }
        string Type { get; set; }
        int Price { get; set; }


        public void use()
        {
            // Use the item
        }
    }

    
}
