using Items;

namespace Food.SimpleFood
{
    internal class Cheese : Food
    {

        public Food TomatoItem { get; private set; }

        public Cheese()
        {
            ItemType simpleFood = new ItemType(1, "SimpleFood");

            ID = 2;
            Name = "Cheese";
            Type = simpleFood;
            Price = 2;
            Weight = 0.01;
        }

    }
}
