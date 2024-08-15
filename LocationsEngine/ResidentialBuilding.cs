using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationsEngine
{
    public class ResidentialBuilding : ILocation
    {
        public string Name { get; set; }

        public int LivingHere {  get; set; }

        public int MaxPopulation { get; set; }

        public ResidentialBuilding(string name, int maxPopulation)
        {
            Name = name;
            LivingHere = 0;
            MaxPopulation = maxPopulation;
        }
    }
}
