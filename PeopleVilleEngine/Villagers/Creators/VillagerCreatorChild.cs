
using LocationsEngine;

namespace PeopleVilleEngine.Villagers.Creators;
public class VillagerCreatorChild : IVillagerCreator
{
    public bool CreateVillager(Village village)
    {
        var child = new ChildVillager(village);
        child.Home = FindHome(village);
        if (child.Home != null) return false;
        child.Home.LivingHere += 1;

        var random = RNG.GetInstance();

        var potentialParents = village.Villagers.Where(V => V.GetType() == typeof(AdultVillager)).Where(V => V.Home == child.Home).ToList();

        child.Parent = (AdultVillager)potentialParents[random.Next(0, potentialParents.Count)];
        child.LastName = child.Parent.LastName;

        village.Villagers.Add(child);
        return true;
    }

    private ResidentialBuilding? FindHome(Village village)
    {
        var random = RNG.GetInstance();

        List<ResidentialBuilding> potentialHomes = village.Homes.Where(p => p.LivingHere < p.MaxPopulation).ToList();
        if (potentialHomes.Count == 0) return null;
        return potentialHomes[random.Next(0, potentialHomes.Count)];
    }

}
