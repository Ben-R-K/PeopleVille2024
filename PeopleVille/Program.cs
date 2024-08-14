using LocationsEngine;
using LocationsEngine.Creators;
Console.WriteLine("PeopleVille");

//Create village
var village = new Village();
Console.WriteLine(village.ToString());

FunktionalBuildingsCreator creator = new FunktionalBuildingsCreator();

creator.SaveBuildings();

//Print locations with villagers to screen
foreach (var location in village.Locations)
{
    var locationStatus = location.Name;
    foreach(var villager in location.Villagers().OrderByDescending(v => v.Age))
    {
        locationStatus += $" {villager}";
    }
    Console.WriteLine(locationStatus);
}