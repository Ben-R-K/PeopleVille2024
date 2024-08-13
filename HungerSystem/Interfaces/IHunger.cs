namespace HungerSystem.Interfaces
{
    public interface IHunger
    {
        int CurrentHunger { get; }
        int MaxHunger { get; }

        event EventHandler OnStarvation;

        bool IsWorking { get; set; }

        void DecreaseHunger(int amount);
        void IncreaseHunger(int amount);
        void Eat(IFood food);
        string Subscribe(Action<int> subscriber, int threshold);
    }
}
