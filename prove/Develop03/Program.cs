using System;
using System.Collections.Generic;

class Program
{
    private Scripture _scripture;

    public Program()
    {
        // Initialize the scripture
        InitializeScripture();
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        DisplayOptions();

        while (!_scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(_scripture.GetRenderedText());
            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            _scripture.HideWords();
        }

        Console.WriteLine("\nMemorization complete! Well done!");
    }

    private void InitializeScripture()
    {
        // Create a reference for the scripture
        Reference reference = new Reference("John", 3, 16, 16);

        // Scripture text
        string text = "For God so loved the world that he gave his only begotten Son, " +
                      "that whosoever believeth in him should not perish, but have everlasting life.";

        // Create the Scripture object
        _scripture = new Scripture(reference, text);
    }

    private void DisplayOptions()
    {
        Console.WriteLine("Instructions:");
        Console.WriteLine("- Press Enter to hide more words.");
        Console.WriteLine("- Type 'quit' to exit the program.");
        Console.WriteLine("\nPress Enter to begin...");
        Console.ReadLine();
    }
}