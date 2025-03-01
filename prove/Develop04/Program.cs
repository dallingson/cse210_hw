
// This program implements a mindfulness program with three types of activities: Breathing, Reflection, and Listing.
// Each activity inherits from the abstract base class "Activity" and implements specific functionality.
//
// 1. **Activity Class**: The base class that contains common methods for setting the duration of the activity,
//    displaying starting/ending messages, pausing for animations, and starting the activity.
// 2. **BreathingActivity**: Guides the user through a square breathing exercise, with animation for inhale, hold, exhale, and hold phases.
// 3. **ReflectionActivity**: Prompts the user to reflect on meaningful experiences by displaying random prompts and questions.
// 4. **ListingActivity**: Asks the user to list positive things, stores their responses, and counts the total number of items listed.
//
// The program's main loop presents a menu of activities, prompts the user to select one, and runs the chosen activity
// for a specified duration. It uses inheritance to reuse common functionality across different activity types.
// 
// For creativity, this program uses a square breathing technique for the breathing activity. It prompts the user to breath in and out based on
// where the square is moving.

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
