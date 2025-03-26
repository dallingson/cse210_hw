using System.Linq.Expressions;

public class PantryItem : Item
{
    private DateOnly _expirationDate;

    public PantryItem(string name, int quantity, decimal price, DateOnly expirationDate) : base(name, quantity, price)
    {
        _expirationDate = expirationDate;
    }

    public bool isExpired()
    {
        return false;
    }

    public override getInfo()
    {
        
    }
}