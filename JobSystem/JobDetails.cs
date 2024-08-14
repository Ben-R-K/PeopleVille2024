using PeopleVilleEngine.Villagers;
using System;

namespace JobSystem
{
    public class JobDetails : IJob
    {
        public string Building { get; set; }
        public double Salary { get; set; }
        public bool IsMale { get; set; }
        public int TimeSpent { get; set; }
        public bool IsWorking { get; set; }

        private static Random random = new Random();

        public JobDetails(AdultVillager villager)
        {
            Building = "Job";
            IsMale = villager.IsMale;
            Salary = GenerateSalary(IsMale);
            TimeSpent = 0; 
            IsWorking = true; 
        }

        private double GenerateSalary(bool isMale)
        {
            if (isMale)
            {
                return random.Next(250, 501); // Salary for males
            }
            else
            {
                return random.Next(150, 400); // Salary for females
            }
        }
    }
}
