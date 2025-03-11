public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        return _currentCount == _targetCount ? _points + _bonusPoints : _points;
    }

    public override string GetStatus() => $"[{_currentCount}/{_targetCount}] {_name} - {_description}";

    public override string FormatForSave() => $"Checklist|{_name}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonusPoints}";
}
