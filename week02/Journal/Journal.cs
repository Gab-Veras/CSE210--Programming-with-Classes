//Exceed requirements: Now the code has a "data base" when the user saves a entry it is saved always in a specif folder and when the user wants to load, all files will be listed to select where to load from.

using System.IO; 

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private string _filename;
    //Folder that works as the journal database
    private string _folder = "journals";

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
    private void EnsureFolder()
    {
        if (!Directory.Exists(_folder))
        {
            Directory.CreateDirectory(_folder);
        }
    }
    //Returns the list of journal files stored in the database folder.
    private List<string> GetJournalFiles()
    {
        EnsureFolder();
        List<string> files = new List<string>();
        foreach (string path in Directory.GetFiles(_folder))
        {
            files.Add(Path.GetFileName(path));
        }
        files.Sort();
        return files;
    }
    //Displays all the journal files
    private void ListJournalFiles(List<string> files)
    {
        if (files.Count == 0)
        {
            Console.WriteLine("There are no journal files saved yet.");
            return;
        }
        Console.WriteLine("Journal files:");
        for (int i = 0; i < files.Count; i++)
        {
            Console.WriteLine($"{i + 1}- {files[i]}");
        }
    }
    //Lets the user pick a file by its number or by typing a name. Returns null if the choice is empty.
    private string ChooseFile(List<string> files, string question)
    {
        ListJournalFiles(files);
        Console.Write(question);
        string answer = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(answer))
        {
            return null;
        }
        if (int.TryParse(answer, out int number) && number >= 1 && number <= files.Count)
        {
            return files[number - 1];
        }
        return answer;
    }
    public void SaveToFile()
    {
        List<string> files = GetJournalFiles();
        string name = ChooseFile(files, "Type the number of an existing file or the name of a new one: ");

        if (name == null)
        {
            Console.WriteLine("No file name was given, nothing was saved.");
            return;
        }
        _filename = Path.Combine(_folder, name);

        //Lines already in the file, so the same entry is not appended twice
        List<string> existing = new List<string>();
        if (File.Exists(_filename))
        {
            existing.AddRange(File.ReadAllLines(_filename));
        }

        int saved = 0;
        using (StreamWriter outputFile = new StreamWriter(_filename, true))
        {
            foreach (Entry entry in _entries)
            {
                string line = FormatLine(entry);
                if (!existing.Contains(line))
                {
                    outputFile.WriteLine(line);
                    existing.Add(line);
                    saved++;
                }
            }
        }
        if (saved == 0)
        {
            Console.WriteLine($"Nothing new to save, the {_filename} file already has all the entries.");
        }
        else
        {
            Console.WriteLine($"{saved} new entries saved, access the {_filename} file to see the result");
        }
    }
    //Builds the line that represents an entry in the file
    private string FormatLine(Entry entry)
    {
        return $"{entry._date} - {entry._promptText} - {entry._entryText}";
    }
    public void LoadFromFile()
    {
        List<string> files = GetJournalFiles();
        if (files.Count == 0)
        {
            ListJournalFiles(files);
            return;
        }
        string name = ChooseFile(files, "Type the number or the name of the file to load: ");

        if (name == null)
        {
            Console.WriteLine("No file was chosen.");
            return;
        }
        _filename = Path.Combine(_folder, name);

        if (File.Exists(_filename))
        {
            string[] lines = File.ReadAllLines(_filename);

            //Replaces the current entries with the ones from the file
            _entries.Clear();
            foreach (string line in lines)
            {
                string[] parts = line.Split(" - ", 3);
                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._promptText = parts[1];
                    entry._entryText = parts[2];
                    AddEntry(entry);
                }
            }
            DisplayAll();
        }
        else
        {
            Console.WriteLine($"The file {name} does not exist in the {_folder} folder.");
        }
    }
}
