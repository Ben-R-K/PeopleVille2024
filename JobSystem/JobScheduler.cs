using PeopleVilleEngine;
using PeopleVilleEngine.Villagers;
using JobSystem;
using System.Linq;
using System.Collections.Generic;
using PeopleVilleBankSystem;
using WorldTimer;
using LocationsEngine;

public class JobScheduler
{
    private readonly Village _village;
    private readonly TimerClass _timer;
    private readonly JobFactory _jobFactory;
    private readonly Dictionary<AdultVillager, IJob> _villagerJobs;
    private readonly BankSystem _bankSystem;

    public JobScheduler(Village village, TimerClass timer, BankSystem bankSystem, ILocation theCompanyLocation)
    {
        _village = village;
        _timer = timer;
        _bankSystem = bankSystem;
        _jobFactory = new JobFactory(_bankSystem, theCompanyLocation); 
        _villagerJobs = new Dictionary<AdultVillager, IJob>();
        SubscribeToTimer();
    }

    private void SubscribeToTimer()
    {
        _timer.Subscribe(OnHourChange, TimerClass.SubscribtionTypes.Hour);
    }

    private void OnHourChange(int hours, int minutes, int seconds, string guid)
    {
        if (hours >= 8 && hours < 16) // Work hours from 8 to 16
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
            if (!_villagerJobs.ContainsKey(villager))
            {
                var job = _jobFactory.CreateJob(villager);
                _villagerJobs[villager] = job;
                villager.IsWorking = true;
                villager.CurrentLocation = (job as JobDetails)?.WorkLocation;
                Console.WriteLine($"Assigned job to villager: {villager.FirstName} {villager.LastName}, Location: {villager.CurrentLocation?.Name}");
            }
            else
            {
                var job = _villagerJobs[villager] as JobDetails;
                if (job != null && !villager.IsWorking)
                {
                    villager.IsWorking = true;
                    villager.CurrentLocation = job.WorkLocation; 
                    job.TimeSpent++;
                }
            }
        }
    }

    private void StopWork()
    {
        foreach (var villager in _village.Villagers.OfType<AdultVillager>())
        {
            if (_villagerJobs.ContainsKey(villager))
            {
                var job = _villagerJobs[villager] as JobDetails;
                if (job != null && villager.IsWorking)
                {
                    villager.IsWorking = false;
                    job.PaySalary();
                    villager.CurrentLocation = villager.Home;
                    Console.WriteLine($"Stopped work for villager: {villager.FirstName} {villager.LastName}, Salary: {job.Salary}");
                }
            }
        }
    }
}
