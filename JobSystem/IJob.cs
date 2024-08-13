using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSystem
{
    public interface IJob
    {
        string Building { get; set; }
        double Salary { get; set; }
        int TimeSpent { get; set; }
        bool IsMale { get; set; }
    }
}


