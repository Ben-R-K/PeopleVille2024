using Items.Interfaces;

namespace Bag.Bags
{
    internal class TheFeather : IItem
    {
        public int ID { get; }
        public string Name { get; }
        public string Type { get; }
        public double Price { get; }
        public double Weight { get; }
        public TheFeather()
        {
            ID = 10;
            Name = "The Feather";
            Price = 100000;
            Weight = 0.023;
            Type = "Bag";
        }

        public void Use(dynamic villager)
        {
        }
    }
}
