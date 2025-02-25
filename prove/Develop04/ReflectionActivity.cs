public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."

    };
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };
    
    public  ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on meaningful experiences.")
    {
    }

     public void startReflection()
    {
        displayStartingMessage();

        // Display a random prompt
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[promptIndex]);
        pauseAnimation(5);

        int timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            // Display a random question
            int questionIndex = random.Next(_questions.Count);
            Console.WriteLine(_questions[questionIndex]);
            pauseAnimation(5);

            timeElapsed += 5;
        }

        displayEndingMessage();
    }

    public void displayQuestion()
    {
        Random random = new Random();
        string question = _questions[random.Next(_questions.Count)];
        Console.WriteLine(question);
        pauseAnimation(3);
    }

    public override void start()
    {
        startReflection();
    }

}