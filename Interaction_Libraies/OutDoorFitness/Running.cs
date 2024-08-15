using Interactions;
using PeopleVilleEngine;
using WorldTimer;

namespace OutDoorFitness {
    public class Running: IInteraction
    {
        private RNG _rng;
        private Village _village;
        private TimerClass _worldTimer;
        public bool IsActivity { get { return true; } }
        public bool IsFemaleAllowed { get { return true; } }
        public bool IsMaleAllowed { get { return true; } }

        public Running(RNG rng, Village village, TimerClass worldTimer)
        {
            _rng = rng;
            _village = village;
            _worldTimer = worldTimer;
        }

        public void Execute(BaseVillager villager)
        {
            if (villager.IsBusy || villager.Age < 12){
                return;
            }

            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} is taking a run");
            _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} finished their run");
                villager.IsBusy = false;
                _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Hour);
            }, TimerClass.SubscribtionTypes.Hour);
        }
    }
}
