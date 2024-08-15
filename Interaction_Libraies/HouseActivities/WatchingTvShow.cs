using Interactions;
using PeopleVilleEngine;
using WorldTimer;

namespace HouseActivities {
    public class WatchingTvShow: IInteraction
    {
        private RNG _rng;
        private Village _village;
        private TimerClass _worldTimer;
        public bool IsActivity { get { return true; } }
        private string[] adultTvShows = new string[] {
            "The Office",
            "Friends",
            "Breaking Bad",
            "Game of Thrones",
            "The Big Bang Theory"
        };
        private string[] kidsTvShows = new string[] {
            "Paw Patrol",
            "Peppa Pig",
            "SpongeBob SquarePants",
            "Dora the Explorer",
            "Mickey Mouse Clubhouse"
        };

        public WatchingTvShow(RNG rng, Village village, TimerClass worldTimer)
        {
            _rng = rng;
            _village = village;
            _worldTimer = worldTimer;
        }

        public void Execute(BaseVillager villager)
        {
            int time = _rng.Next(40, 120);
            int timePast = 0;

            // TODO: Check if villager is Home
            bool isHome = true;
            if (!isHome){
                return;
            }

            string tvShow;
            if (villager.Age < 18){
                tvShow = kidsTvShows[_rng.Next(0, kidsTvShows.Length)];
            } else {
                tvShow = adultTvShows[_rng.Next(0, adultTvShows.Length)];
            }

            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} turned on the tv to watch {tvShow}");
            _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                if (time > timePast){
                    timePast++;
                    return;
                }

                Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} finished {tvShow}");
                villager.IsBusy = false;
                _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Minute);
            }, TimerClass.SubscribtionTypes.Minute);
        }
    }
}
