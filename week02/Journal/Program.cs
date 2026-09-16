

//Exced requirements: 1- When the program is quited a reminder to come back is displayed, 2- The action to save in the file is a parse and not a replace.

using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "10";
        Console.WriteLine("Welcome to the Journal program.");
        Journal myJournal = new Journal();
        PromptGenerator prompt = new PromptGenerator();

        //Menu Loop
        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following options:");
            Console.WriteLine("1- Write\n2- Display\n3- Load\n4- Save\n5- Quit");
            Console.Write("What would you like to do?");
            choice = Console.ReadLine();
            
            if (choice != "5")
            {
                if (choice == "1")
                {
                    //Calls the "Entry" object.
                    Entry userEntry = new Entry();
                    //Defines the date
                    userEntry._date = DateTime.Now.ToString("dd/MM/yyyy");
                    //Defines the prompt displays it and open the write space  
                    userEntry._promptText = prompt.RandomPrompt();
                    Console.WriteLine($"{userEntry._promptText}");
                    userEntry._entryText = Console.ReadLine();
                    //Create a new entry in the journal
                    myJournal.AddEntry(userEntry);
                }
                else if (choice == "2")
                {
                    myJournal.DisplayAll();
                }
                else if (choice == "3")
                {
                    myJournal.LoadFromFile();
                }
                else if (choice == "4")
                {
                    myJournal.SaveToFile();
                }
                else
                {
                    Console.WriteLine("\nYour answer is not one of the options, please insert a valid number\n");
                }
            }
        }
    Console.WriteLine("\nDo not forget to write in your Journal later.\nbye bye.");
    }


}