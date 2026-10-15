class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points, currentCount >= targetCount)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _currentCount++;
        int earnedPoints = Points;
        if (_currentCount == _targetCount)
        {
            MarkComplete();
            earnedPoints += _bonus;
        }
        return earnedPoints;
    }

    public override string GetDetails()
    {
        return $"{GetStatus()} {Name} ({Description}) -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string ToFileString()
    {
        return $"Checklist|{BasicFileValues()}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}
