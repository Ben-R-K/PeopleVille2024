namespace PeopleVilleEngine;
using PeopleVilleEngine.Villagers.Creators;
using PeopleVilleEngine.Locations;
using System.Reflection;
using System.Linq;

public class Village
{
    private readonly RNG _random = RNG.GetInstance();
    public List<BaseVillager> Villagers { get; } = new();
    public List<ILocation> Locations { get; } = new();
    public VillagerNames VillagerNameLibrary { get; } = VillagerNames.GetInstance();
    private Dictionary<string, Action<BaseVillager>> OnVillagerSpawn;

    public Village()
    {
        Console.WriteLine("Creating villager");
        SetupVillage();
    }


    private void SetupVillage()
    {
        var villagers = _random.Next(25, 100);
        Console.ForegroundColor = ConsoleColor.Red;

        var villageCreators = LoadVillagerCreatorFactories();
        Console.ResetColor();
        Console.WriteLine();

        CreateVillagers(villagers, villageCreators);
    }

    public string SubscribeToVillagerSpawn(Action<BaseVillager> subscriber)
    {
        string guid = Guid.NewGuid().ToString();
        OnVillagerSpawn.Add(guid, subscriber);
        return guid;
    }

    private void CreateVillagers(int villagers, List<IVillagerCreator> villageCreators)
    {
        int villageCreatorindex = 0;

        for (int i = 0; i < villagers; i++)
        {
            BaseVillager villager;
            do
            {
                villager = villageCreators[villageCreatorindex].CreateVillager(this);
                villageCreatorindex = villageCreatorindex + 1 < villageCreators.Count ? villageCreatorindex + 1 : 0;
            } while (villager == null);
            foreach (Action<BaseVillager> action in OnVillagerSpawn.Values)
            {
                action(villager);
            }
        }

        Console.ResetColor();
    }

    private List<IVillagerCreator> LoadVillagerCreatorFactories()
    {
        var villageCreators = new List<IVillagerCreator>();
        //Load from this Assembly
        IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes());
        LoadVillagerCreatorFactoriesFromType(
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()),
            villageCreators);

        //Load from library Files
        var libraryFiles = Directory.EnumerateFiles("lib").Where(f => Path.GetExtension(f) == ".dll");
        foreach (var libraryFile in libraryFiles)
        {
            LoadVillagerCreatorFactoriesFromType(
                Assembly.LoadFrom(libraryFile).ExportedTypes,
                villageCreators);
        }
        return villageCreators;
    }

    private void LoadVillagerCreatorFactoriesFromType(IEnumerable<Type> inputTypes, List<IVillagerCreator> outputVillagerCreators)
    {
        var createVillagerInterface = typeof(IVillagerCreator);
        var createrTypes = inputTypes.Where(p => createVillagerInterface.IsAssignableFrom(p) && !p.IsInterface).ToList();
        foreach (var type in createrTypes)
        {
            Console.WriteLine($"Village Creeater loaded: {type}");
            outputVillagerCreators.Add((IVillagerCreator)Activator.CreateInstance(type));
        }
    }

    public override string ToString()
    {
        return $"Village have {Villagers.Count} villagers, where {Villagers.Count(v => v.HasHome() == false)} are homeless.";
    }
}