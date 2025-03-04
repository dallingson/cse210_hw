using System;
using System.Collections.Generic;

public class Program
{
    private List<Activity> activities = new List<Activity>()
    {
        new BreathingActivity(),
        new ReflectionActivity(),
        new ListingActivity()
    };

    public void displayMenu()
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
        Console.WriteLine(" ");
    }

    public void startActivity(int choice)
    {
        if (choice >= 1 && choice <= 3)
        {
            Activity activity = activities[choice - 1];
            Console.Write("Enter the duration of the activity in seconds: ");
            int duration = int.Parse(Console.ReadLine());
            activity.setDuration(duration);
            activity.start();
        }
        else if (choice == 4)
        {
            Console.WriteLine("Goodbye!");
            Console.WriteLine(" ");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Console.WriteLine(" ");
        }
    }

    public static void Main()
    {
        Program program = new Program();
        while (true)
        {
            program.displayMenu();
            Console.Write("Choose an activity: ");
            int choice = int.Parse(Console.ReadLine());
            program.startActivity(choice);
        }
    }
}
