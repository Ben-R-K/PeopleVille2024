﻿using Ilocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationsEngine.Creators
{
    public class ResidentialBuildingCreator
    {
        public List<ResidentialBuilding> RBs = new List<ResidentialBuilding>();

        public ResidentialBuildingCreator()
        {
            string s = File.ReadAllText("ResidentialBuildings.json");
            RBs = JsonSerializer.Deserialize<List<ResidentialBuilding>>(s);
            RBs.Add(new ResidentialBuilding("A House", 10));
        }
    }
}
