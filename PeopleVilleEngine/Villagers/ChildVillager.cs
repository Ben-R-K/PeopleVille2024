namespace PeopleVilleEngine.Villagers;
public class ChildVillager : BaseVillager
{
    public AdultVillager Parent { get; set; }
    public ChildVillager(Village village, string accountNumber) : base(village, accountNumber)
    {
        Age = RNG.GetInstance().Next(0, 18);
    }

    public ChildVillager(Village village, string accountNumber, int age) : this(village, accountNumber)
    {
        Age = age;
    }
    public ChildVillager(Village village, string accountNumber, int age, bool isMale) : this(village, accountNumber, age)
    {
        IsMale = isMale;
    }
}
