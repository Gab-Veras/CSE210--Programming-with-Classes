using System;
using System.Globalization;
public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    public virtual string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        string distance = GetDistance().ToString("F1", CultureInfo.InvariantCulture);
        string speed = GetSpeed().ToString("F1", CultureInfo.InvariantCulture);
        string pace = GetPace().ToString("F1", CultureInfo.InvariantCulture);

        return $"{date} {GetActivityName()} ({_lengthInMinutes} min) - " +
               $"Distance {distance} miles, Speed {speed} mph, Pace {pace} min per mile";
    }

    protected abstract string GetActivityName();
}
