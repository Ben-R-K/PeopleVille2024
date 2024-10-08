﻿using System.Runtime.CompilerServices;
using LocationsEngine;
using PeopleVilleEngine;
namespace PeopleVilleEngine.Villagers.Creators;
using HungerSystem;
public class VillagerCreatorAdult : IVillagerCreator
{
    public (BaseVillager, bool) CreateVillager(Village village)
    {
        var random = RNG.GetInstance();
        var adult = new AdultVillager(village, random.Next(18, 40));
        //Find house
        adult.Home = FindHome(village);
        if(adult.Home == null) return (null, true);
        adult.Home.LivingHere++;

        adult.IsMale = Convert.ToBoolean(random.Next(0, 1));
            adult.LastName = village.VillagerNameLibrary.GetRandomFirstName(adult.IsMale);
            adult.FirstName = village.VillagerNameLibrary.GetRandomFirstName(adult.IsMale);

        //Add to village
        village.Villagers.Add(adult);

        adult.hunger = new Hunger(adult);

        return (adult, false);
    }

    private ResidentialBuilding? FindHome(Village village)
    {
        var random = RNG.GetInstance();

        List<ResidentialBuilding> potentialHomes = village.Homes.Where(p => p.LivingHere < p.MaxPopulation).ToList();
        if(potentialHomes.Count == 0) return null;
        return potentialHomes[random.Next(0, potentialHomes.Count - 1)];
    }
}