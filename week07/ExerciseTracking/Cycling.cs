using System;

public class Cycling : Activity
{
    private double _speedInMilesPerHour;

    public Cycling(DateTime date, int lengthInMinutes, double speedInMilesPerHour)
        : base(date, lengthInMinutes)
    {
        _speedInMilesPerHour = speedInMilesPerHour;
    }

    public override double GetDistance()
    {
        return (_speedInMilesPerHour * GetLengthInMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speedInMilesPerHour;
    }

    public override double GetPace()
    {
        return 60 / _speedInMilesPerHour;
    }

    protected override string GetActivityName()
    {
        return "Cycling";
    }
}
