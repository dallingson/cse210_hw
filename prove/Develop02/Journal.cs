using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(string prompt, string response, DateTime date)
    {
        entries.Add(new Entry(prompt, response, date));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
            Console.WriteLine("\nJournal loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
