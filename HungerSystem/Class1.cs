public interface IHunger
{
    int CurrentHunger { get; }
    void DecreaseHunger(int amount);
    void IncreaseHunger(int amount);
    void Eat(IFood food);
    event EventHandler OnStarvation;
}

public class Hunger : IHunger
{
    private int maxHunger = 100;
    private int currentHunger = 100;

    public int CurrentHunger => currentHunger;

    public event EventHandler OnStarvation;

    public void DecreaseHunger(int amount)
    {
        currentHunger = Math.Max(0, currentHunger - amount);
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
        DecreaseHunger(food.NutritionValue);
    }


    // objektet/personen skal bare slettes når hungerbaren går helt ned.
    // Hvad er smartest i forhold til om man mister hunger efter hvor hurtigt det skal gå. fx hvis man er på arbejde eller
}
