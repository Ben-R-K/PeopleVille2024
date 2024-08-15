using Items;
using HungerSystem;
using PeopleVilleEngine;

namespace Food.SimpleFood
{
    public class Tomato : Food
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

        public void Use(BaseVillager villager) // Default method for using an food item 
        {
            try
            {
                Tomato tomato = new Tomato();
                villager.hunger.IncreaseHunger(tomato.Nutrition);
                villager.RemoveItem(tomato);
            }
            catch (Exception e)
            {
                Console.WriteLine("You can't eat that"); // If the food can't be eaten
            }
        }
    }
}
