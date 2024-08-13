using Items.Interfaces;
using Items;

namespace Food
{
    public class Main
    {

    }

    internal class Food : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }


        public void Use()
        {
            try 
            {
                //Eat(ID);
            }
            catch (Exception e)
            {
                Console.WriteLine("You can't eat that");
            }
        }
    }
}
