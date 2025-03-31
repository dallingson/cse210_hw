// Derived class for non-perishable items (items that have expiration dates but typically last longer)
public class NonPerishableItem : Item
{
    // Constructor to initialize a non-perishable item
    public NonPerishableItem(string name, int quantity, decimal price, string category, DateOnly expirationDate)
        : base(name, quantity, price, category, expirationDate)
    {
    }

    // Method to get information about the non-perishable item
    public new string GetInfo()
    {
        return base.GetInfo();
    }
}