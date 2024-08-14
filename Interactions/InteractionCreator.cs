using System.Reflection;
using PeopleVilleEngine;

namespace Interactions;

public interface IInteraction
{
    public bool IsActivity { get; }
    public void Execute(BaseVillager villager);
}

public class InteractionCreator
{
    private List<IInteraction> interactions = new List<IInteraction>();   
    public List<IInteraction> Interactions { get { return interactions; } }

    private RNG _rng;
    private TimerClass _worldTimer;
    private Village _village;


    public InteractionCreator(Village village, TimerClass worldTimer, RNG rng)
    {
        _rng = rng;
        _worldTimer = worldTimer;
        _village = village;
        RunInteractions();
    }

    private void RunInteractions(BaseVillager villager, IInteraction interaction){
        interaction.Execute(villager);
    }

    private void RunInteractions(){
        _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
            if (minute != 30 && minute != 0){
                return;
            }
            
            if (interactions.Count > 0){
                BaseVillager randomVillager = _village.Villagers[_rng.Next(0, _village.Villagers.Count + 1)];
                IInteraction interaction = interactions[_rng.Next(0, interactions.Count + 1)];

                // Don't run interactions if the villager is busy. Find a new villager
                while (randomVillager.IsBusy){
                    randomVillager = _village.Villagers[_rng.Next(0, _village.Villagers.Count + 1)];
                    Thread.Sleep(100);
                }

                // Don't randomly run not activities
                while (!interaction.IsActivity){
                    interaction = interactions[_rng.Next(0, interactions.Count + 1)];
                    Thread.Sleep(100);
                }
                randomVillager.IsBusy = true;
                RunInteractions(randomVillager, interaction);
            }
        }, TimerClass.SubscribtionTypes.Minute);
    }

    public void LoadInteractions()
    {
        AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes());


        //Load from this Assembly
        IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes());
        LoadInteractionFromType(
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()),
            interactions);

        //Load from library Files
        var libraryFiles = Directory.EnumerateFiles("interaction_dlls").Where(f => Path.GetExtension(f) == ".dll");
        foreach (var libraryFile in libraryFiles)
        {
            LoadInteractionFromType(
                Assembly.LoadFrom(libraryFile).ExportedTypes,
                interactions);
        }
    }

    private void LoadInteractionFromType(IEnumerable<Type> inputTypes, List<IInteraction> outputInteractions)
    {
        var createInteractionInterface = typeof(IInteraction);
        var createrTypes = inputTypes.Where(p => createInteractionInterface.IsAssignableFrom(p) && !p.IsInterface).ToList();

        foreach (var type in createrTypes)
        {
            Console.WriteLine($"Interaction Creeater loaded: {type}");
            outputInteractions.Add((IInteraction)Activator.CreateInstance(type, new object[] { _rng, _village, _worldTimer }));
        }
    }
}


