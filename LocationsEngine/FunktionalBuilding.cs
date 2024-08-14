using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationsEngine
{
    public class FunktionalBuilding : ILocation
    {
        public string Name { get; set; }

        public LocationTypes LocationType { get; set; }

        public int CurrentPopulation { get; set; }

        public int MaxPopulation { get; set; }

        public FunktionalBuilding(string name, LocationTypes locationType, int maxPopulation)
        {
            Name = name;
            LocationType = locationType;
            MaxPopulation = maxPopulation;
        }
    }
}
