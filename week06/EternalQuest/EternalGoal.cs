class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetDetails()
    {
        return $"{GetStatus()} {Name} ({Description})";
    }

    public override string ToFileString()
    {
        return $"Eternal|{BasicFileValues()}";
    }
}
