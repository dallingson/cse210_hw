using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _responses = new List<string>();
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you list positive things.")
    {
    }

    public void startListing()
    {
        displayStartingMessage();
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        pauseAnimation(2);

        Console.WriteLine("Start listing items now:");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            _responses.Add(response);
        }

        displayResponses();
        displayEndingMessage();
    }

    public void displayResponses()
    {
        Console.WriteLine("Here are the items you listed:");
        foreach (string response in _responses)
        {
            Console.WriteLine("- " + response);
            Console.WriteLine("");
        }
    }

    public int countItems()
    {
        return _responses.Count;
    }

    public override void start()
    {
        startListing();
    }

}
