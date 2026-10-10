using System;

class GroundingActivity : Activity
{
    private readonly string[] _steps =
    {
        "Notice five things you can see.",
        "Notice four things you can feel.",
        "Notice three things you can hear.",
        "Notice two things you can smell.",
        "Notice one thing you can taste."
    };

    public GroundingActivity()
        : base("Grounding Activity", "This activity will help you focus on the present by noticing what is around you.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int step = 0;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_steps[step % _steps.Length]);
            int remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            ShowCountDown(Math.Min(5, remainingSeconds));
            Console.WriteLine();
            step++;
        }
    }
}
