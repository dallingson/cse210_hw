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
            Console.WriteLine("3. View grocery list");
            Console.WriteLine("4. View pantry items");
            Console.WriteLine("5. View fridge items");
            Console.WriteLine("6. View freezer items");
            Console.WriteLine("7. Remove item from storage");
            Console.WriteLine("8. View items expiring soon");
            Console.WriteLine("9. Save and Exit");
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
                    ViewGroceryList(groceryList);
                    break;
                case "4":
                    ViewStorageItems(pantry);
                    break;
                case "5":
                    ViewStorageItems(fridge);
                    break;
                case "6":
                    ViewStorageItems(freezer);
                    break;
                case "7":
                    RemoveItemFromStorage(pantry, fridge, freezer);
                    break;
                case "8":
                    ViewExpiringItems(pantry, fridge, freezer);
                    break;
                case "9":
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
        foreach (var item in groceryList._items)
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
        Console.Clear();
        ViewGroceryList(groceryList);
        Console.WriteLine("Choose item to move to storage:");
        string itemName = Console.ReadLine();

        Console.WriteLine("Choose storage area: 1. Pantry 2. Fridge 3. Freezer");
        string storageChoice = Console.ReadLine();

        string storageType = storageChoice switch
        {
            "1" => "pantry",
            "2" => "fridge",
            "3" => "freezer",
            _ => null
        };

        if (storageType != null)
        {
            bool success = itemMover.MoveItem(groceryList, pantry, fridge, freezer, itemName, storageType);
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

    static void RemoveItemFromStorage(Pantry pantry, Fridge fridge, Freezer freezer)
    {
        Console.Clear();

        Console.WriteLine("Choose storage area to remove from:");
        Console.WriteLine("1. Pantry");
        Console.WriteLine("2. Fridge");
        Console.WriteLine("3. Freezer");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Storage selectedStorage = choice switch
        {
            "1" => pantry,
            "2" => fridge,
            "3" => freezer,
            _ => null
        };

        if (selectedStorage == null)
        {
            Console.WriteLine("Invalid storage choice.");
            return;
        }

        Console.WriteLine($"\n{selectedStorage.GetType().Name} Items:");
        selectedStorage.DisplayStorage();

        Console.Write("\nEnter item name to remove: ");
        string itemName = Console.ReadLine();

        bool removed = selectedStorage.RemoveItem(itemName);

        if (removed)
        {
            Console.WriteLine($"Item '{itemName}' removed from {selectedStorage.GetType().Name}.");
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' not found in {selectedStorage.GetType().Name}.");
        }
    }

    
    static void ViewExpiringItems(Pantry pantry, Fridge fridge, Freezer freezer)
    {
        Console.Clear();
        Console.WriteLine("Items Expiring Soon (within 7 days):\n");

        DisplayExpiringFromStorage(pantry);
        DisplayExpiringFromStorage(fridge);
        DisplayExpiringFromStorage(freezer);
    }

    static void DisplayExpiringFromStorage(Storage storage)
    {
        var expiringItems = storage.GetExpiringItems();
        if (expiringItems.Any())
        {
            Console.WriteLine($"{storage.GetType().Name}:");
            foreach (var item in expiringItems)
            {
                Console.WriteLine(item.GetInfo());
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"{storage.GetType().Name}: No items expiring soon.\n");
        }
    }


}
