using Interactions;
using PeopleVilleEngine;

namespace OutDoorFitness {
    public class Running: IInteraction
    {
        public void Execute(Village village, BaseVillager villager)
        {
            Console.WriteLine(villager.Name + " is running");
        }
    }
}
