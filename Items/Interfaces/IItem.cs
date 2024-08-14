using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Interfaces
{
    public interface IItem
    {
        int ID { get; set; }
        string Name { get; set; }
        ItemType Type { get; set; }
        double Price { get; set; }
        double Weight { get; set; } // in kg

        public void Use();
    }
}
