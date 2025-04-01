public class Item
{
    private string _name;
    private int _quantity;
    private decimal _price;
    private bool _isInPantry;
    protected DateOnly? _expirationDate;

    public Item(string name, int quantity, decimal price, bool isInPantry = false, DateOnly? expirationDate = null)
    {
        _name = name;
        _quantity = quantity;
        _price = price;
        _isInPantry = isInPantry;
        _expirationDate = expirationDate;
    }

    public virtual void WarnAboutExpiration()
    {
        // Default behavior for items that don't have specific expiration warnings
        Console.WriteLine($"{_name} has no expiration warning.");
    }

    public string GetInfo()
    {
        string info = $"{_name} : {_quantity} units at ${_price} each | In Pantry: {_isInPantry}";
        if (_expirationDate.HasValue)
        {
            info += $" | Expiration: {_expirationDate.Value}";
        }
        return info;
    }

    public virtual string ToCsv()
    {
        // If expirationDate is not null, include it in the CSV
        return $"{_name},{_quantity},{_price},{_expirationDate?.ToString("yyyy-MM-dd") ?? ""}";
    }

    public void MoveToPantry()
    {
        _isInPantry = true;
    }

    public bool IsExpired()
    {
        return _expirationDate.HasValue && DateOnly.FromDateTime(DateTime.Now) > _expirationDate.Value;
    }

    public bool IsAboutToExpire()
    {
        return _expirationDate.HasValue && DateOnly.FromDateTime(DateTime.Now).AddDays(3) >= _expirationDate.Value;
    }

}
