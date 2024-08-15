using LocationsEngine;
using LocationsEngine.Creators;
using PeopleVilleEngine;
using Interactions;
using WorldTimer;
using PeopleVilleBankSystem;


Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString());
Console.WriteLine("PeopleVille");

// A timer to keep track of the time in the village
TimerClass worldTimer = TimerClass.GetInstance();

// Setup bank system
BankSystem bankService = new BankSystem(worldTimer);

//Create village
var village = new Village();

// Possible to subscribe the villager spawner

Console.WriteLine("dsa");
village.CreateVillage();
Console.WriteLine(village.ToString());
Console.WriteLine("dsdas");

InteractionCreator interactionCreator = new InteractionCreator(village, worldTimer, RNG.GetInstance());
interactionCreator.LoadInteractions();

//Print locations with villagers to screen
foreach (var location in village.Locations)
{
    var locationStatus = location.Name;
    foreach(var villager in village.Villagers.Where(V => V.CurrentLocation == location).OrderByDescending(v => v.Age))
    {
        locationStatus += $" {villager}";
    }
    Console.WriteLine(locationStatus);
}


while (true){
    Thread.Sleep(1000);
    Console.WriteLine(worldTimer.ToString());
}