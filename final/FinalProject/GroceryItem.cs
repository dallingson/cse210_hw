public class GroceryItem : Item
{
    private bool _isPurchased;

    public GroceryItem(string name, int quantity, decimal price) : base(name, quantity, price)
    {
        _isPurchased = false;
    }

    public void markAsPurchased()
    {
        _isPurchased = true;
    }

    public override string getInfo()
    {
        return base.getInfo() + $"| Purchased: {_isPurchased}";
    }
}
