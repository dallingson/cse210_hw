public class Pantry
{
    public List<Item> Items { get; private set; } = new List<Item>();

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public List<Item> GetExpiringItems()
    {
        return Items.FindAll(item => item.IsExpired());
    }

    public List<Item> GetAboutToExpireItems()
    {
        return Items.FindAll(item => item.IsAboutToExpire());
    }
}
