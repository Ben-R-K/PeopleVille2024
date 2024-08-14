using Items;
using Items.Interfaces;

namespace Bag
{
    public class Main
    {

    }

    internal class Bag : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public void Use()
        {
            throw new NotImplementedException();
        }
    }
}
