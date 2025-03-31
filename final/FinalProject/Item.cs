// Base class representing a generic item in the grocery list or pantry
public class Item
{
    private string _name;
    private int _quantity;
    private decimal _price;
    private string _category;
    private DateOnly? _expirationDate; // Nullable expiration date

    // Constructor to initialize an item with the required details
    public Item(string name, int quantity, decimal price, string category, DateOnly? expirationDate = null)
    {
        _name = name;
        _quantity = quantity;
        _price = price;
        _category = category;
        _expirationDate = expirationDate;
    }

    // Method to get information about the item
    public string GetInfo()
    {
        string info = $"{_name} ({_category}): {_quantity} units at ${_price} each";
        if (_expirationDate.HasValue)
        {
            info += $" | Expiration: {_expirationDate.Value}";
        }
        return info;
    }

    // Method to use a specified amount of the item (reduces the quantity)
    public void UseItem(int amount)
    {
        _quantity = Math.Max(0, _quantity - amount);
    }

    // Method to check if the item has expired
    public bool IsExpired()
    {
        return _expirationDate.HasValue && DateOnly.FromDateTime(DateTime.Now) > _expirationDate.Value;
    }

    // Method to check if the item is about to expire (within 3 days)
    public bool IsAboutToExpire()
    {
        return _expirationDate.HasValue && DateOnly.FromDateTime(DateTime.Now).AddDays(3) >= _expirationDate.Value;
    }
}