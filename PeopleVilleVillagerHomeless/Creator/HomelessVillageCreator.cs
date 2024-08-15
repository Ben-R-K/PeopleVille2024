using PeopleVilleEngine;
using PeopleVilleEngine.Villagers;
using PeopleVilleEngine.Villagers.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVilleVillagerHomeless.Creator;
public class HomelessVillageCreator : IVillagerCreator
{
    public (BaseVillager, bool) CreateVillager(Village village)
    {
        if(village.Villagers.Count(v => v.Home == null) * 20 > village.Villagers.Count )
            return (null, false); //No more the 5% can be homeless
        
        var random = RNG.GetInstance();
        if (random.Next(1, 8) != 3)
            return (null, true); //1 of 8 chance to create a homeless
        
        var adult = new AdultVillager(village, random.Next(20, 65));

        //Add to village
        village.Villagers.Add(adult);
        return (adult, false);
    }
}
