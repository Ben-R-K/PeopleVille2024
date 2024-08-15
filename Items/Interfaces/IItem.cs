namespace Items.Interfaces
{
    public interface IItem
    {
        int ID { get; set; }
        string Name { get; set; }
        string Type { get; }
        double Price { get; set; }
        double Weight { get; set; } // in kg

        public void Use(dynamic entity);
    }
}
