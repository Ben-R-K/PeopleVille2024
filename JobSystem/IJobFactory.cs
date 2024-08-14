using System;
using PeopleVilleEngine.Villagers;


namespace JobSystem
{
    public interface IJobFactory
    {
        IJob CreateJob(AdultVillager villager);
    }
}


