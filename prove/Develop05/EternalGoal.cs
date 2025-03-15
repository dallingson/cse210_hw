public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() 
    
            => _points;

    public override string GetStatus() 
    
        => $"[∞] {_name} - {_description}";

    public override string FormatForSave() 
        
        => $"Eternal|{_name}|{_description}|{_points}";
}
