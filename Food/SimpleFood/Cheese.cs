using Items;

namespace Food.SimpleFood
{
    internal class Cheese : Food
    {

        public Food TomatoItem { get; private set; }

        public Cheese()
        {
            ItemType type = new ItemType(1, "Food");

            ID = 2;
            Name = "Cheese";
            Type = type;
            Price = 2;
            Weight = 0.01;
        }

    }
}
