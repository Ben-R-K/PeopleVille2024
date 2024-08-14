using Interactions;
using PeopleVilleEngine;
using WorldTimer;

namespace OutDoorFitness {
    public class PushUps: IInteraction
    {
        private RNG _rng;
        private Village _village;
        private TimerClass _worldTimer;
        public bool IsActivity { get { return true; } }

        public PushUps(RNG rng, Village village, TimerClass worldTimer)
        {
            _rng = rng;
            _village = village;
            _worldTimer = worldTimer;
        }

        public void Execute(BaseVillager villager)
        {
            int time = _rng.Next(2, 25);
            int timePast = 0;

            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} is making pushups");
            _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                if (time > timePast){
                    timePast++;
                    return;
                }

                Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} stopped making pushups");
                villager.IsBusy = false;
                _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Minute);
            }, TimerClass.SubscribtionTypes.Minute);
        }
    }
}
