using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Interfaces
{
    public interface IItemType
    {
        int ID { get; set; }
        string Name { get; set; }
    }
}
