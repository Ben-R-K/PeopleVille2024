using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ilocation
{
    public class ResidentialBuilding : ILocation
    {
        public string Name { get; set; }

        public List<BaseVillager> CurrentPopulation { get; set; }

        public List<BaseVillager> LivingHere { get; set; }

        public int MaxPopulation { get; set; }

        public ResidentialBuilding(string name, int maxPopulation)
        {
            Name = name;
            CurrentPopulation = new List<BaseVillager>();
            LivingHere = new List<BaseVillager>();
            MaxPopulation = maxPopulation;
        }
    }
}
