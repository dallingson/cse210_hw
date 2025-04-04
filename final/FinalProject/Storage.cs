public abstract class Storage
{
    private string _name;
    private List<FoodItem> _items;

    public Storage(string name, List<FoodItem> items)
    {
        SetName(name);
        SetItems(items);
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public List<FoodItem> GetItems()
    {
        return _items;
    }

    // Setters with validation
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Storage name cannot be empty or whitespace.");
        }
        _name = name;
    }

    public void SetItems(List<FoodItem> items)
    {
        _items = items ?? throw new ArgumentNullException(nameof(items), "Items cannot be null.");
    }

    public void AddItem(FoodItem item)
    {
        _items.Add(item);
    }

    public bool RemoveItem(string name)
    {
        FoodItem item = _items.FirstOrDefault(i => i.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        if (item != null)
        {
            _items.Remove(item);
            return true;
        }
        return false;
    }

    public List<FoodItem> GetExpiringItems(int days = 7)
    {
        DateTime now = DateTime.Now;
        return _items
            .Where(i => i.GetExpirationDate().HasValue && (i.GetExpirationDate().Value - now).TotalDays <= days && (i.GetExpirationDate().Value - now).TotalDays >= 0)
            .ToList();
    }

    public abstract void DisplayStorage();
}
