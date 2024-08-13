using Interactions;
using PeopleVilleEngine;

namespace OutDoorFitness {
    public class PushUps: IInteraction
    {
        private RNG _rng;
        public bool IsActivity { get { return true; } }

        public PushUps(RNG rng)
        {
            _rng = rng;
        }

        public void Execute(Village village, BaseVillager villager, TimerClass worldTimer)
        {
            int time = _rng.Next(2, 25);
            int timePast = 0;

            Console.WriteLine($"{worldTimer.ToString()}  --  {villager.ToString()} is making pushups");
            worldTimer.Subscribe((int hour, int minute, int seconds, string id) => {
                if (time > timePast){
                    timePast++;
                    return;
                }

                Console.WriteLine($"{worldTimer.ToString()}  --  {villager.ToString()} stopped making pushups");
                villager.IsBusy = false;
                worldTimer.Unsubscribe(id, TimerClass.SubscribtionTypes.Hour);
            }, TimerClass.SubscribtionTypes.Minute);
        }
    }
}
