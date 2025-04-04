public class FoodItem
{
    private string _name;
    private decimal _price;
    private DateTime? _expirationDate; // Nullable expiration date

    public FoodItem(string name, decimal price, DateTime? expirationDate = null)
    {
        SetName(name);
        SetPrice(price);
        SetExpirationDate(expirationDate);
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public decimal GetPrice()
    {
        return _price;
    }

    public DateTime? GetExpirationDate()
    {
        return _expirationDate;
    }

    // Setters with validation
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty or whitespace.");
        }
        _name = name;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative.");
        }
        _price = price;
    }

    public void SetExpirationDate(DateTime? expirationDate)
    {
        _expirationDate = expirationDate;
    }

    public string GetInfo()
    {
        return $"{_name} - ${_price} (Expires: {_expirationDate?.ToString("yyyy-MM-dd") ?? "N/A"})";
    }
}
