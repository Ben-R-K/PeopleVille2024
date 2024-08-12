using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Interfaces
{
    internal interface IItemType
    {
        int ID { get; set; }
        string Name { get; set; }
    }
}
