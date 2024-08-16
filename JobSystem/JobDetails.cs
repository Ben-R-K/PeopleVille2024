using PeopleVilleEngine.Villagers;
using PeopleVilleBankSystem;
using LocationsEngine;

namespace JobSystem
{
    public class JobDetails : IJob
    {
        public string Building { get; set; }
        public double Salary { get; set; }
        public bool IsMale { get; set; }
        public int TimeSpent { get; set; }
        public string AccountNumber { get; set; }
        public ILocation WorkLocation { get; set; }

        private static Random random = new Random();
        private readonly BankSystem _bankSystem;

        public JobDetails(AdultVillager villager, BankSystem bankSystem, ILocation workLocation)
        {
            Building = "Job";
            IsMale = villager.IsMale;
            Salary = GenerateSalary(IsMale);
            TimeSpent = 0; // Initialize with 0 hours
            _bankSystem = bankSystem;
            WorkLocation = workLocation; // Assign the work location
            AccountNumber = villager.GetAccountNumber();
            // Create a bank account for the villager if they don't already have one
        }

        private double GenerateSalary(bool isMale)
        {
            if (isMale)
            {
                return random.Next(500, 1001); // Salary for males
            }
            else
            {
                return random.Next(300, 801); // Salary for females
            }
        }

        public void PaySalary()
        {
            _bankSystem.Deposit(AccountNumber, Salary);
        }
    }
}
