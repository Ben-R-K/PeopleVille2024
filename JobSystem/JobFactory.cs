using PeopleVilleEngine.Villagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
