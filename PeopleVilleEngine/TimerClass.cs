namespace Interactions;

public class TimerClass
{
    private static TimerClass? _timerClass;
    private int millisecondsPerSecond = 2;
    private int _seconds;
    private int _minutes;
    private int _hours;
    private int _days;
    private Dictionary<string, Action<int, int, int, string>> OnMinuteChange;
    private Dictionary<string, Action<int, int, int, string>> OnHourChange;
    private Dictionary<string, Action<int, int, int, string>> OnDayChange;

    public enum SubscribtionTypes
    {
        Day,
        Hour,
        Minute
    }

    public override string ToString()
    {
        string hours = _hours.ToString().PadLeft(2, '0');
        string minutes = _minutes.ToString().PadLeft(2, '0');
        string seconds = (_seconds%60).ToString().PadLeft(2, '0');
        return $"{hours}:{minutes}:{seconds}";
    }

    public static TimerClass GetInstance(){
        if (_timerClass == null){
            _timerClass = new TimerClass();
        }
        return _timerClass;
    }

    public TimerClass()
    {
        _seconds = 0;
        _minutes = 0;
        _hours = 0;
        OnHourChange = new Dictionary<string, Action<int, int, int, string>> ();
        OnMinuteChange = new Dictionary<string, Action<int, int, int, string>> ();
        OnDayChange = new Dictionary<string, Action<int, int, int, string>> ();
        Task.Run(() => UpdateTime());
    }

    public void UpdateTime()
    {
        while (true) {
            Thread.Sleep(millisecondsPerSecond);
            _seconds += 1;

            int hours = _seconds/3600%24;
            int minutes = _seconds/60%60;
            int seconds = _seconds%60;
            int days = _seconds/86400;

            if (minutes != _minutes){
                _minutes = minutes;
                foreach (var subscriber in OnMinuteChange){
                    Task.Run(() => {subscriber.Value(hours, minutes, seconds, subscriber.Key);});
                }
            }

            if (hours != _hours){
                _hours = hours;
                foreach (var subscriber in OnHourChange){
                    Task.Run(() => {subscriber.Value(hours, minutes, seconds, subscriber.Key);});
                }
            }

            if (days != _days){
                _days = days;
                foreach (var subscriber in OnDayChange){
                    Task.Run(() => {subscriber.Value(hours, minutes, seconds, subscriber.Key);});
                }
            }
        }
    }

    public string Subscribe(Action<int, int, int, string> subscriber, SubscribtionTypes subscribtionType)
    {
        string guid = Guid.NewGuid().ToString();
        if (subscribtionType == SubscribtionTypes.Day){
            OnDayChange.Add(guid.ToString(), subscriber);
            return guid;
        }

        if (subscribtionType == SubscribtionTypes.Hour){
            OnHourChange.Add(guid.ToString(), subscriber);
            return guid;
        }

        if (subscribtionType == SubscribtionTypes.Minute){
            OnMinuteChange.Add(guid.ToString(), subscriber);
            return guid;
        }
        return guid;
    }

    public void Unsubscribe(string guid, SubscribtionTypes subscribtionType)
    {
        if (subscribtionType == SubscribtionTypes.Day){
            OnDayChange.Remove(guid);
        }

        if (subscribtionType == SubscribtionTypes.Hour){
            OnHourChange.Remove(guid);
        }

        if (subscribtionType == SubscribtionTypes.Minute){
            OnMinuteChange.Remove(guid);
        }
    }
}
