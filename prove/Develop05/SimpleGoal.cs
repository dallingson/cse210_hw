public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetStatus() => $"[{(_isComplete ? "X" : " ")}] {_name} - {_description}";

    public override string FormatForSave() => $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
}
