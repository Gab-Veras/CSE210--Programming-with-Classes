using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        Console.Write("Enter your grade: ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";
        string sinal = "";


        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
           letter = "B";
        }
        else if (grade >= 70)
        {
           letter = "C";
        }
        else if (grade >= 60)
        {
           letter = "D";
        }
        else
        {
           letter = "F";
        }
        
        //Sinal detector ("+" or "-")
        if (grade >= 90)
        {
            sinal = "";
        }
        else if (grade % 10 >= 7)
        {
            sinal = "+";
        }
        else if (grade % 10 <= 3)
        {
            sinal = "-";
        }
        else
        {
            sinal = "";
        }

        Console.WriteLine($"{userName}, your grade is {letter}{sinal}.\n");

        if (grade >= 70)
        {
            Console.WriteLine($"Congratulations {userName}! You passed.");
        }
        else
        {
            Console.WriteLine($"Result:\nDear {userName}, your grade isn't high enough to pass, but don't get frustrated; you can try again next time.");
        }
        
    }

}

