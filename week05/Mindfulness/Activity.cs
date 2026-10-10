using System;
using System.Threading;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected int Duration
    {
        get { return _duration; }
    }

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        StartActivity();
        PerformActivity();
        EndActivity();
    }

    protected virtual void PerformActivity()
    {
    }

    private void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration < 1)
        {
            Console.Write("Enter a number greater than zero: ");
        }

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    private void EndActivity()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(symbols[index % symbols.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index++;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            Console.Write(number);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
