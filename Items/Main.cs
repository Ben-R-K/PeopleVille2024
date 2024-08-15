using Items.Interfaces;

namespace Items
{
    internal class Main
    {
        private readonly InstantiateItems _instantiateItems;
        private List<IItem> _loadedItems;

        public Main()
        {
            _instantiateItems = new InstantiateItems();
            _loadedItems = new List<IItem>();
            _loadedItems = _instantiateItems.LoadItems();
        }

        public List<IItem> GiveStartItems() // This method is to provide the villager with one food item and 3 random items
        {
            List<IItem> items = new List<IItem> {};

            int itemAmount = _loadedItems.Count;
            Random random = new Random();

            int firstItem = random.Next(0, itemAmount);
            int secondItem = random.Next(0, itemAmount);
            int thirdItem = random.Next(0, itemAmount);


            items.Add(_loadedItems[firstItem]);
            items.Add(_loadedItems[secondItem]);
            items.Add(_loadedItems[thirdItem]);

            items.Add(GetFoodItem());

            return items;
        }

        private IItem GetFoodItem()
        {
            return _loadedItems.Find(item => item.Type.Equals("Food", StringComparison.OrdinalIgnoreCase));
        }
    }
}
