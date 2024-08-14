using System.Timers;
using HungerSystem.Interfaces;
using Interactions;

public class Hunger : IHunger
{
    private int maxHunger = 100;
    private int currentHunger;
    private int threshold = 50;
    private System.Timers.Timer hungerTimer;
    public int CurrentHunger => currentHunger;
    public int MaxHunger => maxHunger;
    public event EventHandler OnStarvation;
    private static Random random = new Random();
    private (string, Action<dynamic>) OnHungerThresholdReached;
    private dynamic _villager;

    public Hunger(dynamic villager)
    {
        _villager = villager;
        // Start hunger et sted mellem 50 og 100
        currentHunger = random.Next(50, maxHunger + 1);

        // Timer til at reducere hunger over tid
        TimerClass WorldTimer = TimerClass.GetInstance();
        WorldTimer.Subscribe((int hours, int minutes, int seconds, string guid) =>
        {
            OnTimedEvent();
        }, TimerClass.SubscribtionTypes.Minute);
        //hungerTimer = new System.Timers.Timer(5000); // Reducerer hunger hver 5. sekund
        //hungerTimer.Elapsed += OnTimedEvent;
        hungerTimer.AutoReset = true;
        hungerTimer.Enabled = true;
    }

    public string Subscribe(Action<dynamic> subscriber)
    {
        string guid = Guid.NewGuid().ToString();
        OnHungerThresholdReached = (guid, subscriber);
        return guid;
    }

    private void OnTimedEvent()
    {
        // Reducer hunger med 1% af maxHunger
        int baseDecreaseAmount = (int)(0.01 * maxHunger);

        int newHunger;

        if (IsWorking)
        {
            // Hvis villager arbejder, falder hunger med en ekstra faktor, f.eks. 1.5 gange så hurtigt
            newHunger = DecreaseHunger((int)(baseDecreaseAmount * 1.5));
        }
        else
        {
            newHunger = DecreaseHunger(baseDecreaseAmount);
        }

        if (newHunger <= threshold && OnHungerThresholdReached != default)
        {
            OnHungerThresholdReached.Item2(_villager);
        }
    }

    public bool IsWorking { get; set; }

    public int DecreaseHunger(int amount)
    {
        currentHunger = Math.Max(0, currentHunger - amount);

        if (currentHunger == 0)
        {
            OnStarvation?.Invoke(this, EventArgs.Empty);
        }

        return currentHunger;
    }

    public void IncreaseHunger(int amount)
    {
        currentHunger = Math.Min(maxHunger, currentHunger + amount);
    }

    public void Eat(IFood food)
    {
        IncreaseHunger(food.NutritionValue);
    }
}
