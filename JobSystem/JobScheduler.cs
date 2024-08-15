using PeopleVilleEngine;
using PeopleVilleEngine.Villagers;
using JobSystem;
using System.Linq;
using System.Collections.Generic;
using PeopleVilleBankSystem;
using WorldTimer;

public class JobScheduler
{
    private readonly Village _village;
    private readonly TimerClass _timer;
    private readonly JobFactory _jobFactory;
    private readonly Dictionary<AdultVillager, IJob> _villagerJobs;
    private readonly BankSystem _bankSystem;

    public JobScheduler(Village village, TimerClass timer, BankSystem bankSystem)
    {
        _village = village;
        _timer = timer;
        _jobFactory = new JobFactory(_bankSystem);
        _villagerJobs = new Dictionary<AdultVillager, IJob>();
        _bankSystem = bankSystem;
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
                Console.WriteLine($"Assigned job to villager: {villager.FirstName} {villager.LastName}");
            }
            else
            {
                var job = _villagerJobs[villager] as JobDetails;
                if (job != null && !job.IsWorking)
                {
                    job.IsWorking = true;
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
                if (job != null && job.IsWorking)
                {
                    job.IsWorking = false;
                    job.PaySalary();
                    Console.WriteLine($"Stopped work for villager: {villager.FirstName} {villager.LastName}, Salary: {job.Salary}");
                }
            }
        }
    }
}
