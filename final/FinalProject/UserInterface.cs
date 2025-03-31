// Class to handle the user interface and interactions
public class UserInterface
{
    public void ShowMenu(Pantry pantry, GroceryList groceryList, FileManager fileManager)
    {
        fileManager.LoadData(pantry, groceryList);
        while (true)
        {
            Console.WriteLine("\nShelf Stocker Menu:");
            Console.WriteLine("1. Add item to grocery list");
            Console.WriteLine("2. Move item to pantry");
            Console.WriteLine("3. View pantry items");
            Console.WriteLine("4. View items about to expire");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter item name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter category: ");
                    string category = Console.ReadLine();
                    Console.Write("Enter expiration date (YYYY-MM-DD) or leave blank: ");
                    string expirationInput = Console.ReadLine();
                    DateOnly? expirationDate = string.IsNullOrEmpty(expirationInput) ? null : DateOnly.Parse(expirationInput);
                    Item newItem;

                    // Create a perishable or non-perishable item based on the category
                    if (category.ToLower() == "perishable")
                    {
                        newItem = new PerishableItem(name, quantity, price, category, expirationDate.Value);
                    }
                    else
                    {
                        newItem = new NonPerishableItem(name, quantity, price, category, expirationDate.Value);
                    }

                    groceryList.AddItem(newItem);
                    Console.WriteLine("Item added to grocery list!");
                    break;
                case "2":
                    Console.Write("Enter item name to move to pantry: ");
                    string itemName = Console.ReadLine();
                    Item itemToMove = groceryList.Items.Find(i => i.GetInfo().Contains(itemName));
                    if (itemToMove != null)
                    {
                        pantry.AddItem(itemToMove);
                        groceryList.Items.Remove(itemToMove);
                        Console.WriteLine("Item moved to pantry.");
                    }
                    else
                    {
                        Console.WriteLine("Item not found in grocery list.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Pantry Items:");
                    foreach (var item in pantry.Items)
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;
                case "4":
                    Console.WriteLine("Items About to Expire:");
                    foreach (var item in pantry.GetAboutToExpireItems())
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;
                case "5":
                    fileManager.SaveData(pantry, groceryList);
                    Console.WriteLine("Data saved. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}