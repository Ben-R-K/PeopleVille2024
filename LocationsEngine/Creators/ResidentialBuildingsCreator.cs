using LocationsEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationsEngine.Creators
{
    public class ResidentialBuildingsCreator
    {
        public List<ResidentialBuilding> RBs = new List<ResidentialBuilding>();

        public ResidentialBuildingsCreator()
        {
            try
            {
                RBs = JsonSerializer.Deserialize<List<ResidentialBuilding>>(File.ReadAllText("ResidentialBuildings.json"));
            }
            catch (FileNotFoundException ex)
            {
                RBs.Add(new ResidentialBuilding("A House", 10));
            }
        }
        /// <summary>
        /// creates and populates the ResitentialBuildings.json file
        /// </summary>
        public void Savebuldings()
        {
            RBs.Clear();
            ResidentialBuilding P_3 = new ResidentialBuilding("P-3", 505);
            ResidentialBuilding P_43 = new ResidentialBuilding("P-43", 206);
            ResidentialBuilding I_521A = new ResidentialBuilding("I-521", 340);
            ResidentialBuilding I_700A = new ResidentialBuilding("I-700A", 368 );
            ResidentialBuilding B_110 = new ResidentialBuilding("B-110", 30);

            RBs.Add(P_3);
            RBs.Add(P_43);
            RBs.Add(I_521A);
            RBs.Add(I_700A);
            RBs.Add(B_110);
            
            File.WriteAllText("ResidentialBuildings.json", JsonSerializer.Serialize(RBs));
        }
    }
}
