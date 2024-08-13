using PeopleVilleEngine.Villagers;
using System;

namespace JobSystem
{
    public class JobDetails : IJob
    {
        public string Building { get; set; }
        public double Salary { get; set; }
        public int TimeSpent { get; set; }
        public bool IsMale { get; set; }

        private static Random random = new Random();

        public JobDetails(AdultVillager villager)
        {
            Building = "Job";
            IsMale = villager.IsMale;
            Salary = GenerateSalary(IsMale);
            TimeSpent = random.Next(1, 61);
        }

        private double GenerateSalary(bool isMale)
        {
            if (isMale)
            {
                return random.Next(500, 1001); // løn mænd
            }
            else
            {
                return random.Next(300, 801); // løn kvinder
            }
        }
    }
}
