// Class to represent the grocery list, which holds a collection of items to be purchased
public class GroceryList
{
    // List to store the items in the grocery list
    public List<Item> Items { get; private set; } = new List<Item>();

    // Method to add an item to the grocery list
    public void AddItem(Item item)
    {
        Items.Add(item);
    }
}