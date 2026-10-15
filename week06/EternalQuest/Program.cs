using System;
using System.Collections.Generic;
using System.IO;

// Exceeding requirements: the player's level increases for every 1,000 points.
class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYou have {_score} points. You are level {GetLevel()}.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Please choose a number from 1 to 6."); break;
            }
        }
    }

    private static int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private static void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        if (choice != "1" && choice != "2" && choice != "3")
        {
            Console.WriteLine("That is not a goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = ReadText();
        Console.Write("What is a short description of it? ");
        string description = ReadText();
        int points = ReadNumber("How many points is this goal worth? ", 1);

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            int target = ReadNumber("How many times does it need to be completed? ", 1);
            int bonus = ReadNumber("What is the bonus for completing it? ", 0);
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created.");
    }

    private static void ListGoals()
    {
        Console.WriteLine("\nYour goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    private static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        ListGoals();
        int choice = ReadNumber("Which goal did you accomplish? ", 1, _goals.Count);
        int earnedPoints = _goals[choice - 1].RecordEvent();
        _score += earnedPoints;
        Console.WriteLine($"You earned {earnedPoints} points. Your total is {_score}.");
        Console.WriteLine($"You are now level {GetLevel()}.");
    }

    private static void SaveGoals()
    {
        Console.Write("Enter a file name: ");
        string fileName = ReadText();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"SCORE|{_score}");
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.ToFileString());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private static void LoadGoals()
    {
        Console.Write("Enter a file name: ");
        string fileName = ReadText();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("That file could not be found.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();
        int loadedScore = 0;

        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts[0] == "SCORE")
                {
                    loadedScore = int.Parse(parts[1]);
                }
                else
                {
                    Goal goal = Goal.CreateFromFile(line);
                    if (goal != null)
                    {
                        loadedGoals.Add(goal);
                    }
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;
            Console.WriteLine("Goals loaded.");
            Console.WriteLine($"Your score is {_score}, and you are level {GetLevel()}.");
        }
        catch (Exception)
        {
            Console.WriteLine("The file could not be read. Check that it is a saved goals file.");
        }
    }

    private static int ReadNumber(string prompt, int minimum, int maximum = int.MaxValue)
    {
        Console.Write(prompt);
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number < minimum || number > maximum)
        {
            Console.Write($"Enter a number from {minimum} to {maximum}: ");
        }
        return number;
    }

    private static string ReadText()
    {
        string text = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(text))
        {
            Console.Write("Please enter some text: ");
            text = Console.ReadLine();
        }
        return text.Trim().Replace('|', '/');
    }
}
