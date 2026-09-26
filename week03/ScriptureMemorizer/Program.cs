// Exceeding requirements:
// 1. ScriptureLibrary class stores a library of scriptures, and one is chosen at random and presented to the user each time the program runs.
// 2. Punctuation is kept visible when a word is hidden, so only letters become underscores.
using System;

class Program
{
    static void Main(string[] args)
    {
        // Get a random scripture to present to the user
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string response = Console.ReadLine();

            if (response == null || response.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}
