using System.Runtime.CompilerServices;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing","This activity will help you relax by guiding your breathing.")
    {
    }

    public void startBreathing()
    {
        displayStartingMessage();

        int timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            Console.Write("Breathe in... ");
            for (int i = 4; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();

            Console.Write("Breathe out... ");
            for (int i = 6; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();

            timeElapsed += 10;
        }

        displayEndingMessage();
    
    }

    public void alternateAnimation()
    {
    }

    public override void start()
{
    startBreathing();
}

}

