using Interactions;
using PeopleVilleEngine;
using HungerSystem;
using HungerSystem.Interfaces;

namespace food;

public class Eating: IInteraction
{
    private RNG _rng;
    private Village _village;
    private TimerClass _worldTimer;
    public bool IsActivity { get { return false; } }
    public Eating(RNG rng, Village village, TimerClass worldTimer)
    {
        _rng = rng;
        _village = village;
        _worldTimer = worldTimer;

        // TODO: Subscribe to the villager spawning event. And then subscribe to the villager's hunger event
        foreach (BaseVillager villager in _village.Villagers){
            villager.hunger.Subscribe((dynamic villager) => {
                Execute(villager);
            });
        }
    }

    public void Execute(BaseVillager villager)
    {
        // TODO: Check if we have food in the inventory
        // IF we have food in the inventory, eat it and continue
        bool hasFood = villager.;


        if (!hasFood){
            Console.WriteLine($"{villager.ToString()} has no food to eat");
            return;
        }
        // IFood food;
        string foodName = "Apple"; // TODO: Change to food.Name when we have food

        int time = _rng.Next(2, 25);
        int timePast = 0;

        Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} is eating a(n) {foodName}");
        _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
            if (time > timePast){
                timePast++;
                return;
            }

            villager.hunger.IncreaseHunger(10); // TODO: Change this to the food's hunger value


            string currentHunger = villager.hunger.CurrentHunger.ToString();
            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} finished their {foodName}. And their new hunger is {currentHunger}");

            villager.IsBusy = false;
            _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Minute);
        }, TimerClass.SubscribtionTypes.Minute);
    }
}
