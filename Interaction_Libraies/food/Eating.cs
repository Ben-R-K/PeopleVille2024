﻿using Interactions;
using PeopleVilleEngine;
using HungerSystem;
using HungerSystem.Interfaces;
using Items;
using Items.Interfaces;
using WorldTimer;

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
        IItem foodItem = villager.GetItemByType("Food");
        bool hasFood = foodItem != null;
        if (!hasFood){
            Console.WriteLine($"{villager.ToString()} has no food to eat");
            return;
        }

        string foodName = foodItem.Name;

        int time = _rng.Next(2, 25);
        int timePast = 0;

        Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} is eating a(n) {foodName}");
        _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
            if (time > timePast){
                timePast++;
                return;
            }

            // villager.hunger.IncreaseHunger(foodItem.NutritionValue);
            villager.RemoveItem(foodItem);

            string currentHunger = villager.hunger.CurrentHunger.ToString();
            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} finished their {foodName}. And their new hunger is {currentHunger}");

            villager.IsBusy = false;
            _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Minute);
        }, TimerClass.SubscribtionTypes.Minute);
    }
}
