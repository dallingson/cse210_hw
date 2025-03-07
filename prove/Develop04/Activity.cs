public class Activity
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

    public void displayStartMessage()
      {
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        pauseAnimation(3);
      }
    public void displayEndMessage()
      {
        Console.WriteLine("Good Job! You have completed the activity!");
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
}
