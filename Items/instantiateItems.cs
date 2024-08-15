using System.Reflection;
using Items.Interfaces;

namespace Items
{
    public class InstantiateItems
    {
        private readonly string _pluginsFolder;

        public InstantiateItems()
        {
            // Define the folder where the item-related DLLs are located
            _pluginsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory/*, "ItemModules"*/);
        }

        public List<IItem> LoadItems()
        {
            var items = new List<IItem>();

            if (Directory.Exists(_pluginsFolder))
            {
                var dllFiles = Directory.GetFiles(_pluginsFolder, "*.dll");

                foreach (var dll in dllFiles)
                {
                    try
                    {
                        var assembly = Assembly.LoadFrom(dll);
                        
                        var itemTypes = assembly.GetTypes()
                            .Where(t => typeof(IItem).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                        foreach (var type in itemTypes)
                        {
                            IItem itemInstance = (IItem)Activator.CreateInstance(type);
                            items.Add(itemInstance);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading items from {dll}: {ex.Message}");
                    }
                }
            }
            return items;
        }
    }
}
