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
    private List<Scripture> _scriptureLibrary;

    public Program()
    {
        // Initialize the scripture library
        _scriptureLibrary = LoadScripturesFromFile("scriptures.txt");
        if (_scriptureLibrary.Count > 0)
        {
            Random rand = new Random();
            _scripture = _scriptureLibrary[rand.Next(_scriptureLibrary.Count)];
        }
        else
        {
            Console.WriteLine("No scriptures loaded.");
        }
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer Tool!");
        DisplayOptions();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(_scripture.GetRenderedText());
            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            _scripture.HideWords();

            if (_scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(_scripture.GetRenderedText());
                break;
            }
        }

        Console.WriteLine("\nMemorization complete! Well done!");
    }

    private List<Scripture> LoadScripturesFromFile(string filePath)
    {
        var scriptures = new List<Scripture>();

        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var scripture = Scripture.ParseFromLine(line);
                if (scripture != null)
                {
                    scriptures.Add(scripture);
                }
            }
        }
        else
        {
            Console.WriteLine("Scripture file not found.");
        }

        return scriptures;
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
