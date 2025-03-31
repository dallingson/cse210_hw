// Derived class for perishable items (items that have expiration dates and have a short shelf life)
public class PerishableItem : Item
{
    // Constructor to initialize a perishable item
    public PerishableItem(string name, int quantity, decimal price, string category, DateOnly expirationDate)
        : base(name, quantity, price, category, expirationDate)
    {
    }

    // Method to get information about the perishable item, including the expiration date
    public new string GetInfo()
    {
        return base.GetInfo();
    }
}