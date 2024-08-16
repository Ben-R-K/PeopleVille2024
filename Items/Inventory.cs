using Items.Interfaces;
using Items;

namespace Items
{
    public class Inventory
    {
        private List<IItem> _items;
        private int _maxWeight;
        private double _currentWeight;
        private int _slots;
        private Main _main;

        public Inventory(int Age)
        {
            _items = new List<IItem>();


            Random random = new Random();

            _main = new Main();

            ProvideStartItems(_main);

            int AgeFactor = CalculateAgeFactor(Age);

            _maxWeight = random.Next(5, 15) * AgeFactor;
            _slots = random.Next(3, 7) * AgeFactor;

            _currentWeight = 0;
        }

        private int CalculateAgeFactor(int Age)
        {
            if (Age < 10)
                return 1;
            else if (Age < 20)
                return Age / 2;
            else if (Age <= 40)
                return Age;
            else if (Age <= 60)
                return 60 - Age;
            else
                return 1;
        }

        public void AddItem(IItem item)
        {
            if (_currentWeight + item.Weight > _maxWeight)
                throw new Exception("Inventory is full");

            if (_items.Count >= _slots)
                throw new Exception("Inventory is full");

            _items.Add(item);
            _currentWeight += item.Weight;
        }

        public void RemoveItem(IItem item)
        {
            if (!_items.Contains(item))
                return;

            _items.Remove(item);
            _currentWeight -= item.Weight;
        }

        public IItem GetItemByName(string name)
        {
            return _items.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IItem getItemByType(string type)
        {
            return _items.Find(item => item.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        public List<IItem> GetAllItems()
        {
            return _items;
        }

        public void Clear()
        {
            _items.Clear();
            _currentWeight = 0;
        }

        private void ProvideStartItems(Main main)
        {
            List<IItem> items = new List<IItem> { };

            items.Concat(main.GiveStartItems());
        }

        public IItem BuyItem(string type, double balance)
        {
            List<IItem> foodItems = _main.LoadedItems.FindAll(item => item.Type.Equals(type, StringComparison.OrdinalIgnoreCase) && item.Price <= balance);
            if (foodItems == null || foodItems.Count == 0)
            {
                return null;
            }

            Random random = new Random();

            return foodItems[random.Next(0, foodItems.Count)];
        }
    }
}