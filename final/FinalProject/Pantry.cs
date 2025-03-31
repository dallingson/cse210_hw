// Class to represent the pantry, which holds a collection of items (both perishable and non-perishable)
public class Pantry
{
    // List to store the items in the pantry
    public List<Item> Items { get; private set; } = new List<Item>();

    // Method to add an item to the pantry
    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    // Method to get all perishable items that have expired
    public List<Item> GetExpiringItems()
    {
        return Items.FindAll(item => item is PerishableItem perishableItem && perishableItem.IsExpired());
    }

    // Method to get all perishable items that are about to expire (within 3 days)
    public List<Item> GetAboutToExpireItems()
    {
        return Items.FindAll(item => item is PerishableItem perishableItem && perishableItem.IsAboutToExpire());
    }

    // Method to get all non-perishable items that have expired
    public List<Item> GetNonPerishableExpiringItems()
    {
        return Items.FindAll(item => item is NonPerishableItem nonPerishableItem && nonPerishableItem.IsExpired());
    }

    // Method to get all non-perishable items that are about to expire (within 3 days)
    public List<Item> GetNonPerishableAboutToExpireItems()
    {
        return Items.FindAll(item => item is NonPerishableItem nonPerishableItem && nonPerishableItem.IsAboutToExpire());
    }
}