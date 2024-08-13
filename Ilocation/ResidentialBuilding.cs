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

        public int CurrentPopulation { get; set; }

        public int MaxPopulation { get; set; }

        protected ResidentialBuilding(string name, int maxPopulation)
        {
            Name = name;
            CurrentPopulation = 0;
            MaxPopulation = maxPopulation;
        }
    }
}
