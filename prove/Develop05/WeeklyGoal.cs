public class WeeklyGoal : Goal
{
    private DateTime _lastCompleted;

    public WeeklyGoal(string name, string description, int points, DateTime? lastCompleted = null)
        : base(name, description, points)
    {
        _lastCompleted = lastCompleted ?? DateTime.MinValue;
    }

    public override int RecordEvent()
    {
        DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        if (_lastCompleted < startOfWeek)
        {
            _lastCompleted = DateTime.Today;
            return _points;
        }
        Console.WriteLine("You've already completed this goal this week!");
        return 0;
    }

    public override string GetStatus() => $"[Weekly] {_name} - {_description} (Last completed: {_lastCompleted.ToShortDateString()})";

    public override string FormatForSave() => $"Weekly|{_name}|{_description}|{_points}|{_lastCompleted}";
}
