// Exceeding requirements: the program includes a Grounding Activity in addition to the three required activities.

using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            // The grounding activity is the additional activity for this project.
            Console.WriteLine("4. Start grounding activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GroundingActivity();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 5.");
                    Thread.Sleep(1500);
                    break;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }
}
