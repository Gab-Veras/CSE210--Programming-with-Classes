using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
    int guess = 0;
    int guessCounter = 0;
    int totalGuesses = 0;
    string answer = "";

    Console.WriteLine("This is a guess the number game.\nYour number will be something between 1 and 100.\nGood luck!\n");
        
        while (answer != "no")
        {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
            
            while (guess != number)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine()!);

                guessCounter += 1;
                totalGuesses = guessCounter;

                if (guess == number)
                {
                    Console.WriteLine("\nYou guessed it!");
                    Console.WriteLine($"The total of guesses was {totalGuesses}.\n");
                    Console.WriteLine("Do you want to play again?");
                    answer = Console.ReadLine();
                }
                else if (guess < number)
                {
                    Console.WriteLine("higher");
                }
                else
                {
                    Console.WriteLine("lower");
                }
            }
        }
    Console.WriteLine("Thank you for playing!");
    }

}
