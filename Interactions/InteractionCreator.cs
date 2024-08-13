using System.Reflection;
using PeopleVilleEngine;

namespace Interactions;

public interface IInteraction
{
    public void Execute(BaseVillager villager, Village village);
}

public class InteractionCreator
{
    private List<IInteraction> interactions = new List<IInteraction>();   
    public List<IInteraction> Interactions { get { return interactions; } }

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
            outputInteractions.Add((IInteraction)Activator.CreateInstance(type));
        }
    }
}


