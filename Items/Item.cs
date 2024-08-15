using Items.Interfaces;

namespace Items
{
    public class Item : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; }
        public double Price { get; set; }
        public double Weight { get; set; }


        public void Use(dynamic entity)
        {
            //This depends on item
        }
    }
}
