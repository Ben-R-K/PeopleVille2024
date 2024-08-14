using Items.Interfaces;
using System;

namespace Items
{
    public class Item : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }


        public void Use()
        {
            //This depends on item
        }
    }
}
