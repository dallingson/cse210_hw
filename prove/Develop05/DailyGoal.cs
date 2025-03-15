public class DailyGoal : Goal
{
    private DateTime _lastCompleted;

    public DailyGoal(string name, string description, int points, DateTime? lastCompleted = null)
        : base(name, description, points)
    {
        _lastCompleted = lastCompleted ?? DateTime.MinValue;
    }

    public override int RecordEvent()
    {
        if (_lastCompleted.Date < DateTime.Today)
        {
            _lastCompleted = DateTime.Today;
            return _points;
        }
        Console.WriteLine("You've already completed this goal today!");
        return 0;
    }

    public override string GetStatus() => $"[Daily] {_name} - {_description} (Last completed: {_lastCompleted.ToShortDateString()})";

    public override string FormatForSave() => $"Daily|{_name}|{_description}|{_points}|{_lastCompleted}";
}
