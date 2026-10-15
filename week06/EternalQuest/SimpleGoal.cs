class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points, isComplete)
    {
    }

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        MarkComplete();
        return Points;
    }

    public override string GetDetails()
    {
        return $"{GetStatus()} {Name} ({Description})";
    }

    public override string ToFileString()
    {
        return $"Simple|{BasicFileValues()}|{IsComplete}";
    }
}
