using PeopleVilleEngine;
using PeopleVilleEngine.Villagers;
using JobSystem;
using System.Linq;

public class JobScheduler
{
    private readonly Village _village;
    private readonly TimerClass _timer;
    private readonly JobCreator _jobCreator;

    public JobScheduler(Village village, TimerClass timer)
    {
        _village = village;
        _timer = timer;
        _jobCreator = new JobCreator(new JobFactory());
        SubscribeToTimer();
    }

    private void SubscribeToTimer()
    {
        _timer.Subscribe(OnHourChange, TimerClass.SubscribtionTypes.Hour);
    }

    private void OnHourChange(int hours, int minutes, int seconds, string guid)
    {
        if (hours >= 9 && hours < 17) // Work hours from 9 to 17
        {
            AssignWork();
        }
        else
        {
            StopWork();
        }
    }

    private void AssignWork()
    {
        foreach (var villager in _village.Villagers.OfType<AdultVillager>())
        {
            // Assign work to the villager
            var job = _jobCreator.AssignJob(villager);
            Console.WriteLine($"Assigned job to villager: {villager.FirstName} {villager.LastName}");
        }
    }

    private void StopWork()
    {
        foreach (var villager in _village.Villagers.OfType<AdultVillager>())
        {
            // Logic to stop work 
            Console.WriteLine($"Stopped work for villager: {villager.FirstName} {villager.LastName}");
        }
    }
}
