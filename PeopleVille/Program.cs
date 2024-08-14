using LocationsEngine;
using LocationsEngine.Creators;
using PeopleVilleEngine;
Console.WriteLine("PeopleVille");

//Create village
var village = new Village();
Console.WriteLine(village.ToString());

int BuildingCount = 5;
RNG _random = RNG.GetInstance();


ResidentialBuildingsCreator residentialBuildingscreator = new ResidentialBuildingsCreator();
FunktionalBuildingsCreator funktionalBuildingscreator = new FunktionalBuildingsCreator();

funktionalBuildingscreator.SaveBuildings();
residentialBuildingscreator.CreateBuildings();
funktionalBuildingscreator.CreateBuildings();


for (int i = 0; i< BuildingCount; i++)
{
    ResidentialBuilding RB = residentialBuildingscreator.RBs[_random.Next(0, residentialBuildingscreator.RBs.Count)];
    var locationStatus = RB.Name;
    village.Homes.Add(RB);
    Console.WriteLine(locationStatus + " build.");
}

foreach (FunktionalBuilding FB in funktionalBuildingscreator.FBs)
{
    var locationStatus = FB.Name;
    village.Locations.Add(FB);
    Console.WriteLine(locationStatus + " build.");
}