using Interactions;
using PeopleVilleEngine;

namespace food;

public class Eating: IInteraction
{
    private RNG _rng;
    public bool IsActivity { get { return false; } }
    public Eating(RNG rng)
    {
        _rng = rng;
    }

    public void Execute(Village village, BaseVillager villager, TimerClass worldTimer)
    {
        // TODO: Check if we have food in the inventory
        // IF we have food in the inventory, eat it and continue
        string foodItem;

        Console.WriteLine($"{villager.ToString()} is eating a {foodItem} at {worldTimer.ToString()}");
        worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
            // TODO Stop Eating and add hunger "bars" to the villager

            string hunger;
            Console.WriteLine($"{villager.ToString()} finished their {foodItem} at {worldTimer.ToString()}. And new hunger is {hunger}");
            villager.IsBusy = false;
            worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Hour);
        }, TimerClass.SubscribtionTypes.Minute);
    }
}
