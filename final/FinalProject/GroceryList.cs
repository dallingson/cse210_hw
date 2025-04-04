public class GroceryList
{
    public List<FoodItem> _items;

    public GroceryList()
    {
        _items = new List<FoodItem>();
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
