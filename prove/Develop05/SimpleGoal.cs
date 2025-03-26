public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int recordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string getStatus() => $"[{(_isComplete ? "X" : " ")}] {_name} - {_description}";

    public override string formatForSave() => $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
}
