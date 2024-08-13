using Items.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Items
{
    public class InstantiateItems
    {
        private readonly string _pluginsFolder;

        public InstantiateItems()
        {
            // Define the folder where the item-related DLLs are located
            _pluginsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ItemModules");
        }

        public List<Item> LoadItems()
        {
            var items = new List<Item>();

            if (Directory.Exists(_pluginsFolder))
            {
                var dllFiles = Directory.GetFiles(_pluginsFolder, "*.dll");

                foreach (var dll in dllFiles)
                {
                    try
                    {
                        var assembly = Assembly.LoadFrom(dll);

                        var itemTypes = assembly.GetTypes()
                            .Where(t => typeof(Item).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                        foreach (var type in itemTypes)
                        {
                            Item itemInstance = (Item)Activator.CreateInstance(type);
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
