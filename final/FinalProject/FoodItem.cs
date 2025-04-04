public class FoodItem
{
    public string _name { get; set; }
    public decimal _price { get; set; }
    public DateTime? _expirationDate { get; set; } // Make expirationDate nullable

    public FoodItem(string name, decimal price, DateTime? expirationDate = null)
    {
        _name = name;
        _price = price;
        _expirationDate = expirationDate;
    }

    public string GetInfo()
    {
        return $"{_name} - ${_price} (Expires: {_expirationDate?.ToString("yyyy-MM-dd") ?? "N/A"})";
    }
}
