public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you learned a valuable lesson.",
        "Think of a time when you felt truly proud of yourself.",
        "Think of a time when you overcame fear.",
        "Think of a time when you made a difference in someone's life.",
        "Think of a time when you showed kindness to a stranger.",
        "Think of a time when you faced a tough decision.",
        "Think of a time when you achieved something unexpected.",
        "Think of a time when you embraced change.",
        "Think of a time when you supported someone during a difficult time.",
        "Think of a time when you felt connected to something bigger than yourself.",
        "Think of a time when you helped a team succeed."

    };
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?",
        "How did this experience change your perspective?",
        "What strengths did you discover in yourself during this experience?",
        "What challenges did you face and how did you overcome them?",
        "What would you have done differently, if anything?",
        "How did this experience affect your relationships with others?",
        "What emotions did you experience during this time?",
        "What did this experience teach you about resilience?",
        "How did you grow as a person from this experience?",
        "What would you tell someone going through something similar?",
        "What impact do you think this experience had on others?",
        "How do you feel about your role in this situation now?",
        "What part of this experience are you most grateful for?"
    };
    
    public  ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on meaningful experiences.")
    {
    }

    protected override void doActivity()
    {
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
    }

    public void displayQuestion()
    {
        Random random = new Random();
        string question = _questions[random.Next(_questions.Count)];
        Console.WriteLine(question);
        pauseAnimation(3);
    }


}