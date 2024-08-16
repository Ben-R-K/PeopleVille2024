using LocationsEngine;
using LocationsEngine.Creators;
using PeopleVilleEngine;
using Interactions;
using WorldTimer;
using PeopleVilleBankSystem;
using JobSystem;


Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString());
Console.WriteLine("PeopleVille");

// A timer to keep track of the time in the village
TimerClass worldTimer = TimerClass.GetInstance();

// Setup bank system
BankSystem bankService = BankSystem.GetInstance();

//Create village
var village = new Village();

// Possible to subscribe the villager spawn
InteractionCreator interactionCreator = new InteractionCreator(village, worldTimer, RNG.GetInstance());
interactionCreator.LoadInteractions();

village.CreateVillage(bankService);
Console.WriteLine(village.ToString());

//Print locations with villagers to screen
foreach (var location in village.Locations)
{
    var locationStatus = location.Name;
    foreach (var villager in village.Villagers.Where(V => V.CurrentLocation == location).OrderByDescending(v => v.Age))
    {
        locationStatus += $" {villager}";
    }
    Console.WriteLine(locationStatus);
}

FunktionalBuilding jobBuilding = village.Locations.OfType<FunktionalBuilding>().FirstOrDefault(l => l.LocationType == LocationTypes.TheCompany);
if (jobBuilding == null)
{
    throw new Exception("No job building found");
}
JobScheduler jobScheduler = new JobScheduler(village, worldTimer, bankService, jobBuilding);


while (true)
{
    Thread.Sleep(1000);
    Console.WriteLine(worldTimer.ToString());
}