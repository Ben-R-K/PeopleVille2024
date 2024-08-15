namespace PeopleVilleEngine.Villagers.Creators;
using PeopleVilleBankSystem;
public interface IVillagerCreator
{
    public (BaseVillager, bool) CreateVillager(Village village, BankSystem bankService);
}
