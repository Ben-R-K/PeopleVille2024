using Interactions;
using PeopleVilleEngine;
using WorldTimer;

namespace HouseActivities {
    public class Vacuming: IInteraction
    {
        private RNG _rng;
        private Village _village;
        private TimerClass _worldTimer;
        public bool IsActivity { get { return true; } }
        public bool IsFemaleAllowed { get { return true; } }
        public bool IsMaleAllowed { get { return true; } }

        public Vacuming(RNG rng, Village village, TimerClass worldTimer)
        {
            _rng = rng;
            _village = village;
            _worldTimer = worldTimer;
        }

        public void Execute(BaseVillager villager)
        {
            int time = _rng.Next(5, 30);
            int timePast = 0;

            // TODO: Check if villager is Home
            bool isHome = villager.CurrentLocation == villager.Home;
            if (!isHome){
                return;
            }

            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} is vacuming their house");
            _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                if (time > timePast){
                    timePast++;
                    return;
                }

                Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} finished vacuming their house");
                villager.IsBusy = false;
                _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Minute);
            }, TimerClass.SubscribtionTypes.Minute);
        }
    }
}
