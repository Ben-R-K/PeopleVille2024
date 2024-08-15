using PeopleVilleEngine.Villagers;
using PeopleVilleBankSystem;
using LocationsEngine;

namespace JobSystem
{
    public class JobFactory
    {
        private readonly BankSystem _bankSystem;
        private readonly ILocation _theCompanyLocation;

        public JobFactory(BankSystem bankSystem, ILocation theCompanyLocation)
        {
            _bankSystem = bankSystem;
            _theCompanyLocation = theCompanyLocation;
        }

        public IJob CreateJob(AdultVillager villager)
        {
            return new JobDetails(villager, _bankSystem, _theCompanyLocation);
        }
    }
}
