
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
using System.Threading;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            // Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == 2)
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
            }
            else if (choice == 3)
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}