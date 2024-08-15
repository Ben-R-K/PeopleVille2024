using PeopleVilleEngine;
using PeopleVilleEngine.Villagers;
using PeopleVilleEngine.Villagers.Creators;
using PeopleVilleBankSystem;

namespace PeopleVilleVillagerHomeless.Creator;
public class HomelessVillageCreator : IVillagerCreator
{
    public (BaseVillager, bool) CreateVillager(Village village, BankSystem bankService)
    {
        if (village.Villagers.Count(v => v.Home == null) * 20 > village.Villagers.Count)
            return (null, true); //No more the 5% can be homeless

        var random = RNG.GetInstance();
        if (random.Next(1, 8) != 3)
            return (null, true); //1 of 8 chance to create a homeless

        bool isMale = Convert.ToBoolean(random.Next(0, 1));
        string firstName = village.VillagerNameLibrary.GetRandomFirstName(isMale);
        string lastName = village.VillagerNameLibrary.GetRandomFirstName(isMale);

        string accountNumber = bankService.AddAccount(firstName + " " + lastName);

        var adult = new AdultVillager(village, accountNumber, random.Next(20, 65));

        adult.IsMale = isMale;
        adult.FirstName = firstName;
        adult.LastName = lastName;

        //Add to village
        village.Villagers.Add(adult);
        return (adult, false);
    }
}
