public class MonthlyGoal : Goal
{
    private DateTime _lastCompleted;

    public MonthlyGoal(string name, string description, int points, DateTime? lastCompleted = null)
        : base(name, description, points)
    {
        _lastCompleted = lastCompleted ?? DateTime.MinValue;
    }

    public override int RecordEvent()
    {
        DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        if (_lastCompleted < startOfMonth)
        {
            _lastCompleted = DateTime.Today;
            return _points;
        }
        Console.WriteLine("You've already completed this goal this month!");
        return 0;
    }

    public override string GetStatus() => $"[Monthly] {_name} - {_description} (Last completed: {_lastCompleted.ToShortDateString()})";

    public override string FormatForSave() => $"Monthly|{_name}|{_description}|{_points}|{_lastCompleted}";
}
