namespace HungerSystem.Interfaces
{
    public interface IHunger
    {
        int CurrentHunger { get; }
        int MaxHunger { get; }

        event EventHandler OnStarvation;


        int DecreaseHunger(int amount);
        void IncreaseHunger(int amount);
        void Eat(IFood food);
        string Subscribe(Action<dynamic> subscriber);
    }
}
