using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // Initialize a new journal instance
        Journal journal = new Journal();

        // Initialize a prompt generator to provide writing prompts
        PromptGenerator promptGenerator = new PromptGenerator();

        // Define the default file name for saving and loading journal entries
        string fileName = "journal.json";

        // Create a dictionary to map menu options to their respective actions
        var menuActions = new Dictionary<string, Action>
        {
            { "1", () => WriteEntry(journal, promptGenerator) }, // Write a new entry
            { "2", () => DisplayEntries(journal) }, // Display all journal entries
            { "3", () => SaveJournal(journal, fileName) }, // Save journal to a file
            { "4", () => LoadJournal(journal, fileName) }, // Load journal from a file
            { "5", () => ExitProgram() } // Exit the program
        };

        // Run the main menu loop
        while (true)
        {
            // Display menu options
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            // Get user input
            string choice = Console.ReadLine();

            // Execute the corresponding action if the choice is valid, otherwise show an error message
            if (menuActions.ContainsKey(choice))
                menuActions[choice]();
            else
                Console.WriteLine("Invalid option. Try again.");
        }
    }

    // Handles writing a new journal entry
    static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        // Get a random prompt from the prompt generator
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");

        // Get user input for the journal entry
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // Add the new entry to the journal with the current timestamp
        journal.AddEntry(prompt, response, DateTime.Now);
        Console.WriteLine("Entry added.");
    }

    // Handles displaying all journal entries
    static void DisplayEntries(Journal journal)
    {
        Console.WriteLine("\nJournal Entries:");
        journal.DisplayEntries();
    }

    // Handles saving the journal to a file
    static void SaveJournal(Journal journal, string fileName)
    {
        Console.WriteLine($"File saved to {fileName}");
        journal.SaveToFile(fileName);
    }

    // Handles loading the journal from a file
    static void LoadJournal(Journal journal, string fileName)
    {
        Console.WriteLine($"Loading from {fileName}");
        journal.LoadFromFile(fileName);
    }

    // Handles exiting the program
    static void ExitProgram()
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
}
