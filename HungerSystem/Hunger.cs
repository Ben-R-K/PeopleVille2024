using HungerSystem.Interfaces;
using System;
using System.Timers;
using System.Collections.Generic;

public class Hunger : IHunger
{
    private int maxHunger = 100;
    private int currentHunger;
    private System.Timers.Timer hungerTimer;

    public int CurrentHunger => currentHunger;
    public int MaxHunger => maxHunger;

    public event EventHandler OnStarvation;

    private static Random random = new Random();
    private Dictionary<string, Action<int>> OnHungerThresholdReached = new Dictionary<string, Action<int>>();

    public Hunger()
    {
        // Start hunger et sted mellem 50 og 100
        currentHunger = random.Next(50, maxHunger + 1);

        // Timer til at reducere hunger over tid
        hungerTimer = new System.Timers.Timer(5000); // Reducerer hunger hver 5. sekund
        hungerTimer.Elapsed += OnTimedEvent;
        hungerTimer.AutoReset = true;
        hungerTimer.Enabled = true;
    }

    public string Subscribe(Action<int> subscriber, int threshold)
    {
        string guid = Guid.NewGuid().ToString();
        OnHungerThresholdReached.Add(guid, (currentHunger) =>
        {
            if (currentHunger <= threshold)
            {
                subscriber(currentHunger);
            }
        });
        return guid;
    }

    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        // Reducer hunger med 1% af maxHunger
        int baseDecreaseAmount = (int)(0.01 * maxHunger);

        if (IsWorking)
        {
            // Hvis villager arbejder, falder hunger med en ekstra faktor, f.eks. 1.5 gange så hurtigt
            DecreaseHunger((int)(baseDecreaseAmount * 1.5));
        }
        else
        {
            DecreaseHunger(baseDecreaseAmount);
        }
    }

    public bool IsWorking { get; set; }

    public void DecreaseHunger(int amount)
    {
        currentHunger = Math.Max(0, currentHunger - amount);

        // Udløs abonnenter, hvis deres betingelser er opfyldt
        foreach (var subscriber in OnHungerThresholdReached.Values)
        {
            subscriber(currentHunger);
        }

        if (currentHunger == 0)
        {
            OnStarvation?.Invoke(this, EventArgs.Empty);
        }
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
