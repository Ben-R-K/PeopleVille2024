using System;


namespace JobSystem
{
    public interface IJob
    {
        string Building { get; set; }
        double Salary { get; set; }
        bool IsMale { get; set; }
        int TimeSpent { get; set; }
    }
}






