public class GroceryList
{
    private List<FoodItem> _items;

    public GroceryList()
    {
        _items = new List<FoodItem>();
    }

    // Getters
    public List<FoodItem> GetItems()
    {
        return _items;
    }

    // Setters with validation
    public void SetItems(List<FoodItem> items)
    {
        _items = items ?? throw new ArgumentNullException(nameof(items), "Items cannot be null.");
    }

    public void AddItem(FoodItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(FoodItem item)
    {
        _items.Remove(item);
    }
}
