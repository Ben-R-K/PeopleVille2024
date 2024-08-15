using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationsEngine.Creators
{
    public class FunktionalBuildingsCreator
    {
        public List<FunktionalBuilding> FBs = new List<FunktionalBuilding>();

        public FunktionalBuildingsCreator()
        {
            
        }

        /// <summary>
        /// creates and populates the FunktionalBuildings.json file
        /// </summary>
        public void SaveBuildings()
        {
            FBs.Clear();
            FunktionalBuilding Consume = new FunktionalBuilding("Supermarket Consume", LocationTypes.Supermarket, 200);
            FunktionalBuilding Hospital = new FunktionalBuilding("Hospital", LocationTypes.Hospital, 250);
            FunktionalBuilding Gym = new FunktionalBuilding("Gym SweatAndPain", LocationTypes.Gym, 100);
            FunktionalBuilding Bank = new FunktionalBuilding("Bank", LocationTypes.Bank, 100);
            FunktionalBuilding TheCompany = new FunktionalBuilding("The Company", LocationTypes.TheCompany, 300);

            FBs.Add(Consume);
            FBs.Add(Hospital);
            FBs.Add(Gym);
            FBs.Add(Bank);
            FBs.Add(TheCompany);

            File.WriteAllText("FunktionalBuildings.json", JsonSerializer.Serialize(FBs));
        }

        public void CreateBuildings()
        {
            try
            {
                FBs = JsonSerializer.Deserialize<List<FunktionalBuilding>>(File.ReadAllText("FunktionalBuildings.json"));
            }
            catch (FileNotFoundException ex)
            {
                
            }
        }
    }
}
