using System.Runtime.CompilerServices;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding your breathing.")
    {
    }

    public new void doActivity()
    {
        int timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            Console.Clear();
            Console.WriteLine("Square Breathing:");
            squareBreathingAnimation(4);
            timeElapsed += 16;
            Console.Clear();
        }
    }

    // Square breathing animation method
    private void squareBreathingAnimation(int sideDuration)
    {
        int startX = 5;
        int startY = 4;
        int squareSize = 10;

        Console.Clear(); //clear the console beforehand

        // Inhale (Top Side)
        Console.SetCursorPosition(0, 0);
        Console.Write("Inhale...");
        for (int i = 0; i < squareSize; i++)
        {
            Console.SetCursorPosition(startX + i, startY);
            Console.Write("▬");
            Thread.Sleep(sideDuration * 100);
        }

        // Hold (Right Side)
        Console.SetCursorPosition(0, 0);
        Console.Write("Hold...   ");
        for (int i = 1; i < squareSize / 2; i++)
        {
            Console.SetCursorPosition(startX + squareSize - 1, startY + i);
            Console.Write("|");
            Thread.Sleep(sideDuration * 250);
        }

        // Exhale (Bottom Side)
        Console.SetCursorPosition(0, 0);
        Console.Write("Exhale...");
        for (int i = squareSize - 1; i >= 0; i--)
        {
            Console.SetCursorPosition(startX + i, startY + squareSize / 2);
            Console.Write("▬");
            Thread.Sleep(sideDuration * 100);
        }

        // Hold (Left Side)
        Console.SetCursorPosition(0, 0);
        Console.Write("Hold...   ");
        for (int i = squareSize / 2 - 1; i > 0; i--)
        {
            Console.SetCursorPosition(startX, startY + i);
            Console.Write("|");
            Thread.Sleep(sideDuration * 250);
        }

        // Clear prompt text after the cycle
        Console.SetCursorPosition(0, 0);
        Console.Write("             ");
    }

}

