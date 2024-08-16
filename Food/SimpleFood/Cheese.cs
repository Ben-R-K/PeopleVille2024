using Items.Interfaces;

namespace Food.SimpleFood
{
    public class Cheese : IItem
    {
        public int ID { get; }
        public string Name { get; }
        public string Type { get; }
        public double Price { get; }
        public double Weight { get; }
        public int Nutrition { get; }

        public IItem TomatoItem { get; private set; }

        public Cheese()
        {
            ID = 2;
            Name = "Cheese";
            Price = 2;
            Weight = 0.01;
            Nutrition = 20;
            Type = "Food";
        }

        public void Use(dynamic villager)
        {
            try
            {
                villager.hunger.IncreaseHunger(this.Nutrition);
                villager.RemoveItem(this);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Can't eat this food");
            }
        }

    }
}
