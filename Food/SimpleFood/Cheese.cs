namespace Food.SimpleFood
{
    public class Cheese : Food
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

        public void use(BaseVillager villager)
        {
            try
            {
                Cheese cheese = new Cheese();
                villager.hunger.IncreaseHunger(cheese.Nutrition);
                villager.RemoveItem(cheese);

            }
            catch (Exception e)
            {
                Console.WriteLine("Can't eat this food");
            }
        }

    }
}
