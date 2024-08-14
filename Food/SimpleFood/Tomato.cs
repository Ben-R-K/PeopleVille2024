using Items;

namespace Food.SimpleFood
{
    internal class Tomato : Food
    {
        public Food TomatoItem { get; private set; }

        public Tomato()
        {
            ItemType type = new ItemType(1, "Food");

            ID = 1; 
            Name = "Tomato";
            Type = type;
            Price = 10;
            Weight = 0.2;
        }
    }
}
