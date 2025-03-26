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
        return DateOnly.FromDateTime(DateTime.Now) > _expirationDate;
    }

    public void useItem(int amount)
    {
        _quantity = Math.Max(0, _quantity - amount);
    }
        public override string getInfo()
    {
        return base.getInfo() + $"| Expiraton: {_expirationDate}";
    }
}