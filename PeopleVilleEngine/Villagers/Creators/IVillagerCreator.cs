namespace PeopleVilleEngine.Villagers.Creators;
public interface IVillagerCreator
{
    public (BaseVillager, bool) CreateVillager(Village village);
}
