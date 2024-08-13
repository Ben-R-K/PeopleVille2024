namespace Interactions;

public class TimerClass
{
    private int speedUp = 400;
    private int _seconds;
    private int _minutes;
    private int _hours;

    private List<Action<int, int, int>> OnTimeChange; // Sends the time to the subscribers as hours, minutes, seconds


    public override string ToString()
    {
        string hours = _hours < 10 ? $"0{_hours}" : _hours.ToString();
        string minutes = _minutes < 10 ? $"0{_minutes}" : _minutes.ToString();
        string seconds = _seconds < 10 ? $"0{_seconds}" : _seconds.ToString();
        return $"{hours}:{minutes}:{seconds}";
    }

    public TimerClass()
    {
        _seconds = 0;
        _minutes = 0;
        _hours = 0;
        OnTimeChange = new List<Action<int, int, int>>();
        Task.Run(() => UpdateTime()); 
    }

    public void UpdateTime()
    {
        while (true) {
            Thread.Sleep(1000);
            if (_seconds + speedUp >= 60){
                if (_minutes + (speedUp/60) >= 60){
                    if (_hours + 1 >= 24){
                        _hours = 0;
                    }
                    else{
                        _hours += speedUp/3600;
                    }
                } else {
                    _minutes += speedUp/60;
                }
            } else {
                _seconds += speedUp;
            }

            OnTimeChange.ForEach(subscriber => subscriber(_hours, _minutes, _seconds));
        }
    }


    public void Subscribe(Action<int, int, int> subscriber)
    {
        OnTimeChange.Add(subscriber);
    }
}
