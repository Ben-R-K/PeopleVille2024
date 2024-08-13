using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleVilleEngine.Villagers;

namespace JobSystem
{
    public interface IJobFactory
    {
        IJob CreateJob(AdultVillager villager);
    }
}

