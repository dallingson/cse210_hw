using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Represents a journal that stores multiple journal entries
public class Journal
{
    // Private field to store journal entries
    private List<Entry> _entries = new List<Entry>();

    // Adds a new entry to the journal
    public void AddEntry(string prompt, string response, DateTime date)
    {
        _entries.Add(new Entry(prompt, response, date));
    }

    // Displays all journal entries
    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
        }
        else
        {
            // Loop through and display each journal entry
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    // Saves journal entries to a file in JSON format
    public void SaveToFile(string fileName)
    {
        // Serialize the entries list into a formatted JSON string
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });

        // Write the JSON string to a file
        File.WriteAllText(fileName, json);

        Console.WriteLine("Journal saved to file.");
    }

    // Loads journal entries from a file
    public void LoadFromFile(string fileName)
    {
        // Check if the file exists before attempting to load
        if (File.Exists(fileName))
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(fileName);

            // Deserialize the JSON back into a list of entries
            _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();

            Console.WriteLine("\nJournal loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
