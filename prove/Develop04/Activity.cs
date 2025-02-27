using System.Runtime.CompilerServices;

public abstract class Activity
{
    protected int _duration;
    protected string _description;
    protected string _name;

    public Activity(string name, string description) 
    {
        _name = name;
        _description = description;
    }

    public void setDuration(int duration)
    {
         _duration = duration;
    }

    public void displayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity...");
        Console.WriteLine(_description);
        pauseAnimation(3);
    }

    public void displayEndingMessage()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"You spent {_duration} seconds on this activity.");
        Console.WriteLine(" ");
        pauseAnimation(3);

    }

    protected void pauseAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b");

            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b");

            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b");

            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public void displayPrompt()
    {
        Console.WriteLine("DisplayPrompt");
    }

    protected abstract void doActivity();

    public void start()
    {
        displayStartingMessage();
        doActivity();
        displayEndingMessage();
    }

}