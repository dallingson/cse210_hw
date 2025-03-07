using System;
using System.Collections.Generic;
using System.IO;

class Program
{

    public static void Main()
    {
        Program program = new Program();
        program.Run();
    }

    private Scripture _scripture;

    public Program()
    {
        // Initialize the scripture
        InitializeScriptures();
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

            // Check again after hiding words to ensure the final state is displayed
            if (_scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(_scripture.GetRenderedText());
                break;
            }
        }

        Console.WriteLine("\nMemorization complete! Well done!");
    }


    private void InitializeScriptures()
    {
        _scriptureLibrary = new List<Scripture>();

        // Replace with the path to your text file
        string filePath = "scriptures.txt";

        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                // Split the line into reference and text based on " - "
                var parts = line.Split(" - ");
                if (parts.Length == 2)
                {
                    var referenceText = parts[0]; // e.g., "Hebrews 11:1"
                    var scriptureText = parts[1].Trim('"'); // Remove the quotes around the text

                    // Parse the reference
                    var referenceParts = referenceText.Split(':');
                    if (referenceParts.Length == 2)
                    {
                        var bookAndChapter = referenceParts[0].Trim();
                        var verseRange = referenceParts[1].Trim();

                        var bookAndChapterParts = bookAndChapter.Split(' ');
                        if (bookAndChapterParts.Length == 2)
                        {
                            string book = bookAndChapterParts[0];
                            int chapter = int.Parse(bookAndChapterParts[1]);
   
                            // Handle possible range in verse (e.g., "1-4" or "1")
                            var verses = verseRange.Split('-');
                            int startVerse = int.Parse(verses[0]);
                            int endVerse = verses.Length == 2 ? int.Parse(verses[1]) : startVerse;

                            // Create the Reference object
                            var reference = new Reference(book, chapter, startVerse, endVerse);

                            // Create the Scripture object and add it to the list
                            var scripture = new Scripture(reference, scriptureText);
                            _scriptureLibrary.Add(scripture);
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Scripture file not found.");
        }

        // Select a random scripture from the list
        if (_scriptureLibrary.Count > 0)
        {
            Random rand = new Random();
            _scripture = _scriptureLibrary[rand.Next(_scriptureLibrary.Count)];
        }
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
