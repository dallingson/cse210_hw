using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string fileName = "journal.txt";

        var menuActions = new Dictionary<string, Action>
        {
            { "1", () => WriteEntry(journal, promptGenerator) },
            { "2", () => DisplayEntries(journal) },
            { "3", () => SaveJournal(journal, fileName) },
            { "4", () => LoadJournal(journal, fileName) },
            { "5", () => { Console.WriteLine("Goodbye!"); Environment.Exit(0); } }
        };

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (menuActions.ContainsKey(choice))
                menuActions[choice]();
            else
                Console.WriteLine("Invalid option. Try again.");
        }
    }

    static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        journal.AddEntry(prompt, response, DateTime.Now);
        Console.WriteLine("Entry added.");
    }

    static void DisplayEntries(Journal journal)
    {
        Console.WriteLine("\nJournal Entries:");
        journal.DisplayEntries();
    }

    static void SaveJournal(Journal journal, string fileName)
    {
        Console.WriteLine($"File Saved to {fileName}");
        journal.SaveToFile(fileName);
    }

    static void LoadJournal(Journal journal, string fileName)
    {
        Console.WriteLine($"Loading from {fileName}");
        journal.LoadFromFile(fileName);
    }
}