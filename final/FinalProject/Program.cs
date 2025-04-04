public class Program
{
    static void Main()
    {
        // Initialize storage areas and grocery list
        GroceryList groceryList = new GroceryList();
        Pantry pantry = new Pantry();
        Fridge fridge = new Fridge();
        Freezer freezer = new Freezer();
        FileManager fileManager = new FileManager();
        ItemMover itemMover = new ItemMover();

        // Load data from CSV files
        fileManager.LoadData(groceryList, pantry, fridge, freezer);

        // Main menu loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nShelf Stocker Menu:");
            Console.WriteLine("1. Add item to grocery list");
            Console.WriteLine("2. Move item to storage");
            Console.WriteLine("3. Move item back to grocery list");
            Console.WriteLine("4. View grocery list");
            Console.WriteLine("5. View pantry items");
            Console.WriteLine("6. View fridge items");
            Console.WriteLine("7. View freezer items");
            Console.WriteLine("8. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddItemToGroceryList(groceryList);
                    break;
                case "2":
                    MoveItemToStorage(groceryList, pantry, fridge, freezer, itemMover);
                    break;
                case "3":
                    MoveItemBackToGroceryList(groceryList, pantry, fridge, freezer, itemMover);
                    break;
                case "4":
                    ViewGroceryList(groceryList);
                    break;
                case "5":
                    ViewStorageItems(pantry);
                    break;
                case "6":
                    ViewStorageItems(fridge);
                    break;
                case "7":
                    ViewStorageItems(freezer);
                    break;
                case "8":
                    fileManager.SaveData(groceryList, pantry, fridge, freezer);
                    Console.WriteLine("Data saved. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void AddItemToGroceryList(GroceryList groceryList)
    {
        Console.Clear();
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();
        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());
        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.Write("Enter expiration date (YYYY-MM-DD) or leave blank: ");
        string expirationInput = Console.ReadLine();
        DateTime? expirationDate = string.IsNullOrEmpty(expirationInput) ? (DateTime?)null : DateTime.Parse(expirationInput);

        groceryList.AddItem(new FoodItem(name, price, expirationDate));
        Console.WriteLine("Item added to grocery list!");
    }

    static void ViewGroceryList(GroceryList groceryList)
    {
        Console.Clear();
        Console.WriteLine("Grocery List:");
        foreach (var item in groceryList.Items)
        {
            Console.WriteLine(item.GetInfo());
        }
    }

    static void ViewStorageItems(Storage storage)
    {
        Console.Clear();
        Console.WriteLine($"{storage.GetType().Name} Items:");
        storage.DisplayStorage();
    }

    static void MoveItemToStorage(GroceryList groceryList, Pantry pantry, Fridge fridge, Freezer freezer, ItemMover itemMover)
    {
        // View items in the grocery list
        Console.Clear();
        ViewGroceryList(groceryList); // Shows the grocery list
        Console.WriteLine("Choose item to move to storage.");
        string itemName = Console.ReadLine();

        // Ask the user which storage they want to move to
        Console.WriteLine("Choose storage area: 1. Pantry 2. Fridge 3. Freezer");
        string storageChoice = Console.ReadLine();

        // Choose the storage based on user input
        Storage selectedStorage = storageChoice switch
        {
            "1" => pantry, 
            "2" => fridge,  
            "3" => freezer, 
            _ => null 
        };

        if (selectedStorage != null)
        {
            // Attempt to move the item
            bool success = itemMover.MoveItem(groceryList, pantry, fridge, freezer, itemName, storageChoice.ToLower());
            if (!success)
            {
                Console.WriteLine($"Item '{itemName}' not found in grocery list.");
            }
        }
        else
        {
            Console.WriteLine("Invalid storage choice. Please try again.");
        }
    }



    static void MoveItemBackToGroceryList(GroceryList groceryList, Pantry pantry, Fridge fridge, Freezer freezer, ItemMover itemMover)
    {
        Console.Clear();
        Console.Write("Enter item name to move back to grocery list: ");
        string itemName = Console.ReadLine();

        bool success = itemMover.MoveItemBackToGroceryList(groceryList, pantry, fridge, freezer, itemName);
        if (!success)
        {
            Console.WriteLine($"Item '{itemName}' not found in storage.");
        }
    }
}
