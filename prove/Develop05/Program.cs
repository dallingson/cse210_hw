using System;

class Program
{
    static void Main()
    {
        GoalTracker tracker = new GoalTracker();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest - Goal Tracker");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Goal Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save & Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    tracker.CreateGoal();
                    break;
                case "2":
                    tracker.RecordGoalEvent();
                    break;
                case "3":
                    tracker.DisplayGoals();
                    break;
                case "4":
                    tracker.ShowScore();
                    break;
                case "5":
                    tracker.SaveGoals();
                    Console.WriteLine("Goals saved. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
