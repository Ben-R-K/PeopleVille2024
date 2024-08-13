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
            Console.WriteLine($"{villager.ToString()} started running at {worldTimer.ToString()}");
            worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                Console.WriteLine($"{villager.ToString()} finished their run at {worldTimer.ToString()}");
                villager.IsBusy = false;
                worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Hour);
            }, TimerClass.SubscribtionTypes.Hour);
        }
    }
}
