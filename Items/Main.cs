



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
            List<Item> loadedItems = new List<Item>();
            loadedItems = _instantiateItems.LoadItems();

            List<Item> GiveStartItem() // This method is to provide the villager with one food item and 3 random items
            {
                List<Item> item = new List<Item>();

                int itemAmount = loadedItems.Count;
                Random random = new Random();

                int firstItem = random.Next(0, itemAmount);
                int secondItem = random.Next(0, itemAmount);
                int thirdItem = random.Next(0, itemAmount);


                item.Add(loadedItems[firstItem]);
                item.Add(loadedItems[secondItem]);
                item.Add(loadedItems[thirdItem]);

                item.Add(GetFoodItem());

                return item;
            }

            Item GetFoodItem()
            {
                return loadedItems.Find(item => item.Type.Equals("Food", StringComparison.OrdinalIgnoreCase));
            }
        }

        

        public List<Item> LoadAllItems() // This method is to load all items from the DLL's and returns them in a list
        {
            //Console.WriteLine("Loading items...");
            List<Item> loadedItems = new List<Item>();
            loadedItems = _instantiateItems.LoadItems();

            return loadedItems;
        }

        public void UnloadItems() // This method is to unload all items from the list
        {
            Console.WriteLine("Unloading items...");
            _loadedItems.Clear();
        }

        public void ReloadItems() // This method is to remove all items from the list and then load them again from the DLL's
        {
            UnloadItems();
            LoadAllItems();
        }

        public IItem GetItemByName(string name) // This method is to get an item by its name
        {
            if (_loadedItems.Count == 0)
            {
                Console.WriteLine("No items loaded.");
                return null;
            }

            return _loadedItems.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
