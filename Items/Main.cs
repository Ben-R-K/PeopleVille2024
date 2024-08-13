using Items.Interfaces;
using System;
using System.Collections.Generic;

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
        }

        public Item GiveStartItem()
        {

            return new Item();
        }

        public List<Item> LoadAllItems()
        {
            Console.WriteLine("Loading items...");
            List<Item> _loadedItems = new List<Item>();
            _loadedItems = _instantiateItems.LoadItems();

            return _loadedItems;
        }

        public void UnloadItems()
        {
            Console.WriteLine("Unloading items...");
            _loadedItems.Clear();
        }

        public void ReloadItems()
        {
            UnloadItems();
            LoadAllItems();
        }

        public IItem GetItemByName(string name)
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
