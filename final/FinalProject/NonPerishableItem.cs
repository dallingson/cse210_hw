public class NonPerishableItem : Item
{
    public NonPerishableItem(string name, int quantity, decimal price, bool isInPantry = false, DateOnly? expirationDate = null)
        : base(name, quantity, price,  isInPantry, expirationDate)
    { }

    public override void WarnAboutExpiration()
    {
        if (_expirationDate.HasValue)
        {
            Console.WriteLine($"Warning: {GetName()} is a non-perishable item, but still has an expiration date of {_expirationDate.Value.ToString("yyyy-MM-dd")}. Please check!");
        }
        else
        {
            Console.WriteLine($"{GetName()} is non-perishable and does not have an expiration date.");
        }
    }

    private string GetName() => base.GetInfo(); // For simplicity, we use GetInfo() for name here
}
