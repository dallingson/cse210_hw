public class Fridge : Storage
{
    public Fridge() : base("Fridge", new List<FoodItem>())
    {
    }

    public override void DisplayStorage()
    {
        Console.WriteLine($"Items in {_name}:");
        foreach (var item in _items)
        {
            Console.WriteLine($"{item._name} - ${item._price} (Expires: {item._expirationDate})");
        }
    }
}
