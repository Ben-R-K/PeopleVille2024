namespace Items.Interfaces
{
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        string Type { get; }
        double Price { get; }
        double Weight { get; } // in kg

        public void Use(dynamic entity);
    }
}
