using PeopleVilleEngine.Villagers;
using System;

namespace JobSystem
{
    public class JobCreator
    {
        private readonly IJobFactory _jobFactory;

        public JobCreator(IJobFactory jobFactory)
        {
            _jobFactory = jobFactory;
        }

        public IJob AssignJob(AdultVillager villager)
        {
            return _jobFactory.CreateJob(villager);
        }
    }
}
