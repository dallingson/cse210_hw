public class GroceryItem : Item
{
    private bool _isPurchased;

    public GroceryItem(string name, int quantity, decimal price, bool isPurchased) : base(name, quantity, price)
    {
        _isPurchased = isPurchased;
    }

    public void markAsPurchased()
    {
        
    }

    public override GetInfo()
    {

    }
}
