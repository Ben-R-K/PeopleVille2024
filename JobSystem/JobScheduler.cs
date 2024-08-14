using PeopleVilleEngine;
using PeopleVilleEngine.Villagers;
using Interactions;
using JobSystem;


public class JobScheduler
{
    private readonly Village _village;
    private readonly TimerClass _timer;
    private readonly JobFactory _jobFactory;
    private readonly Dictionary<AdultVillager, IJob> _villagerJobs;

    public JobScheduler(Village village, TimerClass timer)
    {
        _village = village;
        _timer = timer;
        _jobFactory = new JobFactory();
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
                    Console.WriteLine($"Stopped work for villager: {villager.FirstName} {villager.LastName} Salary: {job.Salary}");
                }
            }
        }
    }
}
 