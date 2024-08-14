using Items;

namespace Food.SimpleFood
{
    internal class Tomato : Food
    {
        public Food TomatoItem { get; private set; }

        public Tomato()
        {
            ID = 1; 
            Name = "Tomato";
            Price = 10;
            Weight = 0.2;
            Nutrition = 10;
        }
    }
}
