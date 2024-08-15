using Items.Interfaces;
using Items;

namespace Food
{
    public class Main
    {

    }

    public class Food : IItem //New food class that implements IItem for more organized code and to override the default use method
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get { return "bag"; } }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int Nutrition { get; set; }



        public void Use(dynamic entity) // Default method for using an food item
        {
            try 
            {
                //Eat(ID); // Call hunger system to eat the food
            }
            catch (Exception e)
            {
                Console.WriteLine("You can't eat that"); // If the food can't be eaten
            }
        }
    }
}
