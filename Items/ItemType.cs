using Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    public class ItemType : IItemType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ItemType(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
