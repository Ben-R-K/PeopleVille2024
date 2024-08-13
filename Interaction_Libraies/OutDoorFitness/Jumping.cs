using Interactions;
using PeopleVilleEngine;

namespace OutDoorFitness {
    public class Jumping: IInteraction
    {
        private RNG _rng;
        public bool IsActivity { get { return true; } }

        public Jumping(RNG rng)
        {
            _rng = rng;
        }

        public void Execute(Village village, BaseVillager villager, TimerClass worldTimer)
        {
            Console.WriteLine($"{villager.ToString()} started jumping around at {worldTimer.ToString()}");
            worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                Console.WriteLine($"{villager.ToString()} finished jumping arround at {worldTimer.ToString()}");
                worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Hour);
            }, TimerClass.SubscribtionTypes.Hour);
        }
    }
}
