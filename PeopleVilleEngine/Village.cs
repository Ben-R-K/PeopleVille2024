namespace PeopleVilleEngine;
using System.Reflection;
using PeopleVilleEngine.Villagers.Creators;
using LocationsEngine;
using System.Linq;
using LocationsEngine.Creators;

public class Village
{
    private readonly RNG _random = RNG.GetInstance();
    public List<BaseVillager> Villagers { get; } = new();
    public List<FunktionalBuilding> Locations { get; } = new();
    public List<ResidentialBuilding> Homes { get; } = new();
    public VillagerNames VillagerNameLibrary { get; } = VillagerNames.GetInstance();
    private Dictionary<string, Action<BaseVillager>> OnVillagerSpawn;

    public Village()
    {
        OnVillagerSpawn = new Dictionary<string, Action<BaseVillager>>();
        Console.WriteLine("Creating villager");
    }

    public void CreateVillage()
    {
        ResidentialBuildingsCreator residentialBuildingscreator = new ResidentialBuildingsCreator();
        FunktionalBuildingsCreator funktionalBuildingscreator = new FunktionalBuildingsCreator();

        residentialBuildingscreator.CreateBuildings();
        funktionalBuildingscreator.CreateBuildings();

        int BuildingCount = 5;
        for (int i = 0; i < BuildingCount; i++)
        {
            ResidentialBuilding RB = residentialBuildingscreator.RBs[_random.Next(0, residentialBuildingscreator.RBs.Count)];
            var locationStatus = RB.Name;
            Homes.Add(RB);
            Console.WriteLine(locationStatus + " build.");
        }

        foreach (FunktionalBuilding FB in funktionalBuildingscreator.FBs)
        {
            var locationStatus = FB.Name;
            Locations.Add(FB);
            Console.WriteLine(locationStatus + " build.");
        }

        int livingSpace = 0;
        foreach(ResidentialBuilding RB in Homes)
        {
            livingSpace += RB.MaxPopulation;
        }

        var villagers = _random.Next(Convert.ToInt32(livingSpace / 10), Convert.ToInt32(livingSpace/1.1)); 
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
        return $"Village have {Villagers.Count} villagers, where {Villagers.Count(v => v.Home == null)} are homeless.";
    }
}