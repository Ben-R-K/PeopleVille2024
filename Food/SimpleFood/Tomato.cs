using Items;
using Items.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Food.SimpleFood
{
    internal class Tomato : Food
    {
        public Food TomatoItem { get; private set; }

        public Tomato()
        {
            ItemType simpleFood = new ItemType(1, "SimpleFood");

            ID = 1; 
            Name = "Tomato";
            Type = simpleFood;
            Price = 10;
            Weight = 0.2;        
        }
    }
}
