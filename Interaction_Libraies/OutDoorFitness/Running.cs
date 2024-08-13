using Interactions;
using PeopleVilleEngine;

namespace OutDoorFitness {
    public class Running: IInteraction
    {
        private RNG _rng;
        public bool IsActivity { get { return true; } }

        public Running(RNG rng)
        {
            _rng = rng;
        }

        public void Execute(Village village, BaseVillager villager, TimerClass worldTimer)
        {
            Console.WriteLine($"{worldTimer.ToString()}  --  {villager.ToString()} is taking a run");
            worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                Console.WriteLine($"{worldTimer.ToString()}  --  {villager.ToString()} finished their run");
                villager.IsBusy = false;
                worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Hour);
            }, TimerClass.SubscribtionTypes.Hour);
        }
    }
}
