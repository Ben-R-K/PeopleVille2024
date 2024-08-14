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
        }

        public void Use() // Default method for using an food item 
        {
            try
            {
                int Nutrition = 10;
                //Eat(ID); // Call hunger system to eat the food


            }
            catch (Exception e)
            {
                Console.WriteLine("You can't eat that"); // If the food can't be eaten
            }
        }
    }
}
