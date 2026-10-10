using System;
using System.Threading;

class ListingActivity : Activity
{
    private readonly string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by listing as many things as you can in an area.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int itemCount = 0;

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[random.Next(_prompts.Length)]} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Response: ");
            string response = ReadTimedLine(endTime);
            if (response.Trim().Length > 0)
            {
                itemCount++;
            }
        }

        Console.WriteLine($"You listed {itemCount} items.");
    }

    private string ReadTimedLine(DateTime endTime)
    {
        string response = "";

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return response;
                }

                if (key.Key == ConsoleKey.Backspace && response.Length > 0)
                {
                    response = response.Substring(0, response.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    response += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        Console.WriteLine();
        return response;
    }
}
