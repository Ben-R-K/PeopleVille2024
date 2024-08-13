using Interactions;
using PeopleVilleEngine;

namespace OutDoorFitness {
    public class Running: IInteraction
    {
        public void Execute(BaseVillager villager, Village village)
        {
            Console.WriteLine("Playing together");
        }
    }
}
