using System.IO; 

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private string _filename;

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {

            entry.Display();
        }  
    }
    public void SaveToFile()
    {
        Console.Write("Type the name of the journal file: ");
        _filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(_filename, true))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date} - {entry._promptText} - {entry._entryText}");
            }
        }
        Console.WriteLine($"Your text was saved, access the {_filename} file to see the result");
    }
    public void LoadFromFile()
    {
        Console.Write("Type the name of the journal file: ");
        _filename = Console.ReadLine();

        if (File.Exists(_filename))
        {
            string[] lines = File.ReadAllLines(_filename);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine($"The file {_filename} does not exist.");
        }
    }
}