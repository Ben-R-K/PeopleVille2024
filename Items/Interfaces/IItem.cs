namespace Items.Interfaces
{
    public interface IItem
    {
        int ID { get; set; }
        string Name { get; set; }
        ItemType Type { get; set; }
        double Price { get; set; }
        double Weight { get; set; } // in kg

        public void Use();
    }
}
