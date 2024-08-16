namespace PeopleVilleEngine.Villagers;
public class AdultVillager : BaseVillager
{
    public bool IsWorking { get; set; }
    public AdultVillager(Village village, string accountNumber) : base(village, accountNumber)
    {
        Age = 30;

    }
    public AdultVillager(Village village, string accountNumber, int age) : base(village, accountNumber)
    {
        Age = age;
    }
}
