using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _responses = new List<string>();
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?",
        "What are things that make you happy?",
        "What are accomplishments you are proud of?",
        "What are challenges you've overcome?",
        "Who are people that inspire you?",
        "What are places where you feel at peace?",
        "What are experiences that have made you stronger?",
        "What are things you enjoy doing in your free time?",
        "Who are people who have positively influenced your life?",
        "What are goals you are currently working towards?",
        "What are lessons you've learned recently?",
        "Who are people you can always rely on?",
        "What are things you are grateful for today?",
        "What are ways you like to help others?",
        "What are values that are important to you?",
        "Who are people who have supported you during tough times?",
        "What are things that make you feel energized and motivated?"
    };

    public ListingActivity() : base("Listing", "This activity helps you list positive things.")
    {
    }

    public void Run()
    {
        Console.Clear();
        Console.Write("Enter the duration of the activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        setDuration(duration);
        displayStartMessage();

        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        pauseAnimation(2);

        Console.WriteLine("Start listing items now:");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            _responses.Add(response);
        }
        
        Console.Clear();
        Console.WriteLine($"You listed {_responses.Count} items.");
        displayEndMessage();
    }

}
