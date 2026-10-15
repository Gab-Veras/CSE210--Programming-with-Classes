using System;
public class Running : Activity
{
    private double _distanceInMiles;

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles)
        : base(date, lengthInMinutes)
    {
        _distanceInMiles = distanceInMiles;
    }

    public override double GetDistance()
    {
        return _distanceInMiles;
    }

    public override double GetSpeed()
    {
        return (_distanceInMiles / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / _distanceInMiles;
    }

    protected override string GetActivityName()
    {
        return "Running";
    }
}
