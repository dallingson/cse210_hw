public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int recordEvent() 
    
            => _points;

    public override string getStatus() 
    
        => $"[∞] {_name} - {_description}";

    public override string formatForSave() 
        
        => $"Eternal|{_name}|{_description}|{_points}";
}
