using Items.Interfaces;

namespace Items
{
    public class ItemType : IItemType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ItemType(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
