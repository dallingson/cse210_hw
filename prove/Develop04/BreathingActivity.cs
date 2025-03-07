using System.Runtime.CompilerServices;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax using square breathing technique.")
    {
    }

    public void Run()
    {
        Console.Clear();
        Console.Write("Enter the duration of the activity in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        setDuration(duration);
        displayStartMessage();

        int timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            squareBreathingAnimation(1);
            timeElapsed += 16;
        }
        Console.Clear();
        displayEndMessage();
    }

    private void squareBreathingAnimation(int sideDuration)
    {
        int startX = 5;
        int startY = 4;
        int squareSize = 10;

        Console.Clear();

        Console.SetCursorPosition(0, 0);
        Console.Write("Inhale...");
        for (int i = 0; i < squareSize; i++)
        {
            Console.SetCursorPosition(startX + i, startY);
            Console.Write("▬");
            Thread.Sleep(sideDuration * 300);
        }

        Console.SetCursorPosition(0, 0);
        Console.Write("Hold...   ");
        for (int i = 1; i < squareSize / 2; i++)
        {
            Console.SetCursorPosition(startX + squareSize - 1, startY + i);
            Console.Write("|");
            Thread.Sleep(sideDuration * 300);
        }

        Console.SetCursorPosition(0, 0);
        Console.Write("Exhale...");
        for (int i = squareSize - 1; i >= 0; i--)
        {
            Console.SetCursorPosition(startX + i, startY + squareSize / 2);
            Console.Write("▬");
            Thread.Sleep(sideDuration * 300);
        }

        Console.SetCursorPosition(0, 0);
        Console.Write("Hold...   ");
        for (int i = squareSize / 2 - 1; i > 0; i--)
        {
            Console.SetCursorPosition(startX, startY + i);
            Console.Write("|");
            Thread.Sleep(sideDuration * 300);
        }

        Console.SetCursorPosition(0, 0);
        Console.Write("             ");
    }
}

