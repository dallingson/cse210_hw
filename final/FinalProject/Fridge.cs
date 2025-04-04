public class Fridge : Storage
{
    public Fridge() : base("Fridge", new List<FoodItem>()) { }

    public override void DisplayStorage()
    {
        Console.WriteLine($"Items in {GetName()}:");
        foreach (var item in GetItems())
        {
            Console.WriteLine($"{item.GetName()} - ${item.GetPrice()} (Expires: {item.GetExpirationDate()})");
        }
    }
}