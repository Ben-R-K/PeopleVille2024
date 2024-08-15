using Interactions;
using PeopleVilleEngine;
using WorldTimer;

namespace HouseActivities {
    public class CleaningToilet: IInteraction
    {
        private RNG _rng;
        private Village _village;
        private TimerClass _worldTimer;
        public bool IsActivity { get { return true; } }

        public CleaningToilet(RNG rng, Village village, TimerClass worldTimer)
        {
            _rng = rng;
            _village = village;
            _worldTimer = worldTimer;
        }

        public void Execute(BaseVillager villager)
        {
            int time = _rng.Next(2, 10);
            int timePast = 0;

            // TODO: Check if villager is Home
            bool isHome = true;
            if (!isHome){
                return;
            }

            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} started cleaning the toilet");
            _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                if (time > timePast){
                    timePast++;
                    return;
                }

                Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()}'s toilet is clean - And shiny");
                villager.IsBusy = false;
                _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Minute);
            }, TimerClass.SubscribtionTypes.Minute);
        }
    }
}
