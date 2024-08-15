using Interactions;
using PeopleVilleEngine;
using WorldTimer;

namespace HouseActivities {
    public class PlayingVideoGames: IInteraction
    {
        private RNG _rng;
        private Village _village;
        private TimerClass _worldTimer;
        public bool IsActivity { get { return true; } }
        public bool IsFemaleAllowed { get { return false; } }
        public bool IsMaleAllowed { get { return true; } }

        private List<string> VideoGames = new List<string> {
            "FIFA 2023",
            "FIFA 2024",
            "Call of Duty",
            "Fortnite",
            "Minecraft",
            "GTA V",
            "Red Dead Redemption 2",
            "The Witcher 3",
            "Cyberpunk 2077",
            "Assassin's Creed Valhalla",
            "The Last of Us Part II",
            "Ghost of Tsushima",
        };

        public PlayingVideoGames(RNG rng, Village village, TimerClass worldTimer)
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
            bool isHome = villager.CurrentLocation == villager.Home;
            if (!isHome){
                return;
            }
            
            string videoGame = VideoGames[_rng.Next(0, VideoGames.Count + 1)];
            Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} started playing {videoGame}");
            _worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                if (time > timePast){
                    timePast++;
                    return;
                }

                Console.WriteLine($"{_worldTimer.ToString()}  --  {villager.ToString()} didn't want to play {videoGame} anymore");
                villager.IsBusy = false;
                _worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Minute);
            }, TimerClass.SubscribtionTypes.Minute);
        }
    }
}
