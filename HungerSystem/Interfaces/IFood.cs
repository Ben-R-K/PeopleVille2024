using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungerSystem.Interfaces
{
    public interface IFood
    {
        int NutritionValue { get; } // hvor meget hunger maden reducerer
        string Name { get; } // navn på maden

        int FoodValue { get; } // hvor meget maden koster

    }
}


