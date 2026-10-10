using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding you to breathe in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountDown(4);
            Console.WriteLine();

            if (DateTime.Now < endTime)
            {
                Console.Write("Breathe out...");
                ShowCountDown(4);
                Console.WriteLine();
            }
        }
    }
}
