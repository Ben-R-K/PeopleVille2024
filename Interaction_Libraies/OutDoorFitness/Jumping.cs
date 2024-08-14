using Interactions;
using PeopleVilleEngine;
using WorldTimer;

namespace OutDoorFitness {
    public class Jumping: IInteraction
    {
        private RNG _rng;
        private Village _village;
        private TimerClass _worldTimer;
        public bool IsActivity { get { return true; } }

        public Jumping(RNG rng, Village village, TimerClass worldTimer)
        {
            _rng = rng;
            _village = village;
            _worldTimer = worldTimer;
        }

        public void Execute(BaseVillager villager)
        {
            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} started jumping around");
            _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} finished jumping arround");
                _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Hour);
            }, TimerClass.SubscribtionTypes.Hour);
        }
    }
}
