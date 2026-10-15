using System;

abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    protected Goal(string name, string description, int points, bool isComplete = false)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    protected string Name { get { return _name; } }
    protected string Description { get { return _description; } }
    protected int Points { get { return _points; } }
    protected bool IsComplete { get { return _isComplete; } }
    protected void MarkComplete() { _isComplete = true; }

    public abstract int RecordEvent();
    public abstract string GetDetails();
    public abstract string ToFileString();

    protected string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    protected string BasicFileValues()
    {
        return $"{_name}|{_description}|{_points}";
    }

    public static Goal CreateFromFile(string line)
    {
        string[] parts = line.Split('|');
        switch (parts[0])
        {
            case "Simple":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "Eternal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "Checklist":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            default:
                return null;
        }
    }
}
