using Items;

namespace Food.SimpleFood
{
    internal class Cheese : Food
    {

        public Food TomatoItem { get; private set; }

        public Cheese()
        {
            ID = 2;
            Name = "Cheese";
            Price = 2;
            Weight = 0.01;
            Nutrition = 2;
        }

    }
}
