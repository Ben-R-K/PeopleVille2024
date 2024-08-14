using PeopleVilleEngine.Villagers;
using System;


namespace JobSystem
{
    public class JobFactory : IJobFactory
    {
        public IJob CreateJob(AdultVillager villager)
        {
            if (villager.HasHome())
            {
                return new JobDetails(villager);
            }
            else
            {
                throw new InvalidOperationException("Villager must not be homeless to have a job");
            }
        }
    }
}

