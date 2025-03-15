using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalTracker
{
    private List<Goal> _goals;
    private int _totalScore;
    private readonly string _filename;

    public GoalTracker(string filename = "goals.txt")
    {
        _goals = new List<Goal>();
        _totalScore = 0;
        _filename = filename;
        EnsureGoalsFileExists();
        LoadGoals();
    }

    public void CreateGoal()
{
    Console.Clear();
    Console.WriteLine("Choose Goal Type:");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");
    Console.WriteLine("4. Daily Goal");
    Console.WriteLine("5. Weekly Goal");
    Console.WriteLine("6. Monthly Goal");
    Console.Write("Enter choice: ");
    string choice = Console.ReadLine();

    Console.Write("Enter goal name: ");
    string name = Console.ReadLine();
    Console.Write("Enter goal description: ");
    string description = Console.ReadLine();
    Console.Write("Enter points awarded: ");
    int points = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case "1":
            _goals.Add(new SimpleGoal(name, description, points));
            break;
        case "2":
            _goals.Add(new EternalGoal(name, description, points));
            break;
        case "3":
            Console.Write("Enter target count: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points on completion: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
            break;
        case "4":
            _goals.Add(new DailyGoal(name, description, points));
            break;
        case "5":
            _goals.Add(new WeeklyGoal(name, description, points));
            break;
        case "6":
            _goals.Add(new MonthlyGoal(name, description, points));
            break;
        default:
            Console.WriteLine("Invalid choice.");
            return;
    }

    Console.WriteLine("Goal created successfully! Press Enter to continue...");
    Console.ReadLine();
}


    public void RecordGoalEvent()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the goal you completed:");
        string goalName = Console.ReadLine();

        foreach (var goal in _goals)
        {
            if (goal.GetName().Equals(goalName, StringComparison.OrdinalIgnoreCase))
            {
                int pointsEarned = goal.RecordEvent();
                _totalScore += pointsEarned;
                Console.WriteLine("");
                Console.WriteLine($"You earned {pointsEarned} points! Total Score: {_totalScore}");
                Console.WriteLine("");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }
        }

        Console.WriteLine("Goal not found. Press Enter to continue...");
        Console.ReadLine();
    }

    public void DisplayGoals()
    {
        Console.Clear();
        Console.WriteLine("Your Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void ShowScore()
    {
        Console.WriteLine("");
        Console.WriteLine($"Total Score: {_totalScore}");
        Console.WriteLine("");
        Console.WriteLine("Press Enter to continue...");
        Console.WriteLine("");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(_filename))
        {
            writer.WriteLine($"Total Score: {_totalScore}");
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.FormatForSave());
            }
        }
    }

    private void LoadGoals()
    {
        if (!File.Exists(_filename)) return;

        string[] lines = File.ReadAllLines(_filename);
        if (lines.Length == 0) return;

        _totalScore = int.Parse(lines[0].Split(": ")[1]);
        _goals.Clear();

        foreach (var line in lines.Skip(1))
        {
            string[] parts = line.Split('|');
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "Simple")
                _goals.Add(new SimpleGoal(name, description, points, bool.Parse(parts[4])));
            else if (type == "Eternal")
                _goals.Add(new EternalGoal(name, description, points));
            else if (type == "Checklist")
                _goals.Add(new ChecklistGoal(name, description, points, int.Parse(parts[4]), int.Parse(parts[6]), int.Parse(parts[5])));
            else if (type == "Daily")
                _goals.Add(new DailyGoal(name, description, points, DateTime.Parse(parts[4])));
            else if (type == "Weekly")
                _goals.Add(new WeeklyGoal(name, description, points, DateTime.Parse(parts[4])));
            else if (type == "Monthly")
                _goals.Add(new MonthlyGoal(name, description, points, DateTime.Parse(parts[4])));
        }
    }   


    private void EnsureGoalsFileExists()
    {
        if (!File.Exists(_filename))
        {
            File.WriteAllText(_filename, "Total Score: 0\n");
        }
    }
}
