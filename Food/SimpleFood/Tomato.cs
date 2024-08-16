using Items;
using HungerSystem;
using PeopleVilleEngine;
using Items.Interfaces;

namespace Food.SimpleFood
{
    public class Tomato : IItem
    {
        public int ID { get; }
        public string Name { get; }
        public string Type { get; }
        public double Price { get; }
        public double Weight { get; }
        public int Nutrition { get; }

        public IItem TomatoItem { get; private set; }

        public Tomato()
        {
            ID = 1;
            Name = "Tomato";
            Price = 10;
            Weight = 0.2;
            Nutrition = 20;
            Type = "Food";
        }

        public void Use(dynamic villager) // Default method for using an food item 
        {
            try
            {
                villager.hunger.IncreaseHunger(this.Nutrition);
                villager.RemoveItem(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"{villager.FirstName} {villager.LastName} can't eat that tomato"); // If the food can't be eaten
            }
        }
    }
}
