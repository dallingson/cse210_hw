public class PerishableItem : Item
{
    public PerishableItem(string name, int quantity, decimal price,  bool isInPantry = false, DateOnly? expirationDate = null)
        : base(name, quantity, price, isInPantry, expirationDate)
    { }

    public override void WarnAboutExpiration()
    {
        if (_expirationDate.HasValue && DateOnly.FromDateTime(DateTime.Now).AddDays(3) >= _expirationDate.Value)
        {
            Console.WriteLine($"Warning: {GetName()} is about to expire on {_expirationDate.Value.ToString("yyyy-MM-dd")}!");
        }
        else if (_expirationDate.HasValue && DateOnly.FromDateTime(DateTime.Now) > _expirationDate.Value)
        {
            Console.WriteLine($"Warning: {GetName()} has expired on {_expirationDate.Value.ToString("yyyy-MM-dd")}!");
        }
        else
        {
            Console.WriteLine($"{GetName()} is safe for now.");
        }
    }

    private string GetName() => base.GetInfo(); // For simplicity, we use GetInfo() for name here
}
