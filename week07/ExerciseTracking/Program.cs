using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Store each kind of activity in the same list.
        List<Activity> activities = new List<Activity>();
        activities.Add(new Running(new DateTime(2026, 10, 10), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2026, 10, 11), 45, 12.0));
        activities.Add(new Swimming(new DateTime(2026, 10, 12), 40, 40));

        // Each activity uses its own overridden calculation methods.
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
