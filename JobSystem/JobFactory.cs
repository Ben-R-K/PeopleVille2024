using PeopleVilleEngine.Villagers;
using PeopleVilleBankSystem;

namespace JobSystem
{
    public class JobFactory
    {
        private readonly BankSystem _bankSystem;

        public JobFactory(BankSystem bankSystem)
        {
            _bankSystem = bankSystem;
        }

        public IJob CreateJob(AdultVillager villager)
        {
            return new JobDetails(villager, _bankSystem);
        }
    }
}
