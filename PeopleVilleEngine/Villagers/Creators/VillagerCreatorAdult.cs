namespace PeopleVilleEngine.Villagers.Creators;
using LocationsEngine;
using PeopleVilleBankSystem;

public class VillagerCreatorAdult : IVillagerCreator
{
    public (BaseVillager, bool) CreateVillager(Village village, BankSystem bankService)
    {
        var random = RNG.GetInstance();

        bool isMale = Convert.ToBoolean(random.Next(0, 1));
        string firstName = village.VillagerNameLibrary.GetRandomFirstName(isMale);
        string lastName = village.VillagerNameLibrary.GetRandomFirstName(isMale);

        string accountNumber = bankService.AddAccount(firstName + " " + lastName);

        var adult = new AdultVillager(village, accountNumber, random.Next(18, 40));
        //Find house
        adult.Home = FindHome(village);
        if (adult.Home == null) return (null, true);
        adult.Home.LivingHere++;

        adult.IsMale = isMale;
        adult.LastName = lastName;
        adult.FirstName = firstName;

        //Add to village
        village.Villagers.Add(adult);

        adult.hunger = new Hunger(adult);

        return (adult, false);
    }

    private ResidentialBuilding? FindHome(Village village)
    {
        var random = RNG.GetInstance();

        List<ResidentialBuilding> potentialHomes = village.Homes.Where(p => p.LivingHere < p.MaxPopulation).ToList();
        if (potentialHomes.Count == 0) return null;
        return potentialHomes[random.Next(0, potentialHomes.Count - 1)];
    }
}