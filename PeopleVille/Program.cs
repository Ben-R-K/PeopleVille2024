using PeopleVilleEngine;
using Interactions;


Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString());
Console.WriteLine("PeopleVille");

// A timer to keep track of the time in the village
TimerClass worldTimer = new TimerClass();

//Create village
var village = new Village();
Console.WriteLine(village.ToString());

InteractionCreator interactionCreator = new InteractionCreator(village, worldTimer, RNG.GetInstance());
interactionCreator.LoadInteractions();


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

while (true){
    Thread.Sleep(1000);
    Console.WriteLine(worldTimer.ToString());
}