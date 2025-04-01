public class UserInterface
{
    public void ShowMenu(Pantry pantry, GroceryList groceryList, FileManager fileManager)
    {
        fileManager.LoadData(pantry, groceryList);
        while (true)
        {
            Console.Clear();  // Clear the console screen each time
            Console.WriteLine("\nShelf Stocker Menu:");
            Console.WriteLine("1. Add item to grocery list");
            Console.WriteLine("2. Move item to pantry");
            Console.WriteLine("3. View pantry items");
            Console.WriteLine("4. View items about to expire");
            Console.WriteLine("5. View grocery list");
            Console.WriteLine("6. Remove item from pantry");
            Console.WriteLine("7. Save and Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();  // Clear again after the user selects an option
                    Console.Write("Enter item name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter expiration date (YYYY-MM-DD) or leave blank: ");
                    string expirationInput = Console.ReadLine();
                    DateOnly? expirationDate = string.IsNullOrEmpty(expirationInput) ? null : DateOnly.Parse(expirationInput);
                    Item newItem = new Item(name, quantity, price, false, expirationDate);
                    groceryList.AddItem(newItem);
                    Console.WriteLine("Item added to grocery list!");
                    break;

                    case "2":
                    Console.Clear();
                    if (groceryList.Items.Count == 0)
                    {
                        Console.WriteLine("The grocery list is empty. Add items before moving them to the pantry.");
                        break;
                    }

                    Console.WriteLine("\nGrocery List:");
                    foreach (var item in groceryList.Items)
                    {
                        Console.WriteLine(item.GetInfo());
                    }

                    // Move item to pantry
                    while (true)
                    {
                        Console.Write("Enter item name to move to pantry: ");
                        string itemName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(itemName))
                        {
                            Console.WriteLine("Item name cannot be empty. Please try again.");
                            continue;
                        }

                        Item itemToMove = groceryList.Items.Find(i => i.GetInfo().Contains(itemName));

                        if (itemToMove != null)
                        {
                            itemToMove.MoveToPantry();
                            pantry.AddItem(itemToMove);
                            groceryList.Items.Remove(itemToMove); // Remove the item from the grocery list
                            Console.WriteLine($"{itemName} has been moved to the pantry.");
                            break; // Exit the loop after a successful move
                        }
                        else
                        {
                            Console.WriteLine("Item not found in the grocery list. Please enter a valid item.");
                        }
                    }
                    break;


                case "3":
                    Console.Clear();  // Clear again after the user selects an option
                    Console.WriteLine("Pantry Items:");
                    foreach (var item in pantry.Items)
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;

                
                case "4":
                    Console.Clear();  // Clear again after the user selects an option
                    Console.WriteLine("Grocery List:");
                    foreach (var item in groceryList.Items)
                    {
                        Console.WriteLine(item.GetInfo());
                    }
                    break;

                case "5":
                    // Show pantry items before prompting the user
                    if (pantry.Items.Count == 0)
                    {
                        Console.WriteLine("The pantry is empty. No items to remove.");
                        break;
                    }

                    Console.WriteLine("\nPantry Items:");
                    foreach (var item in pantry.Items)
                    {
                        Console.WriteLine(item.GetInfo());
                    }

                    // Remove item from pantry
                    while (true)
                    {
                        Console.Write("\nEnter the item name to remove from the pantry: ");
                        string itemName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(itemName))
                        {
                            Console.WriteLine("Item name cannot be empty. Please try again.");
                            continue;
                        }

                        Item itemToRemove = pantry.Items.Find(i => i.GetInfo().Contains(itemName));

                        if (itemToRemove != null)
                        {
                            pantry.Items.Remove(itemToRemove); // Remove item from pantry
                            Console.WriteLine($"\n{itemName} has been removed from the pantry.");
                            break; // Exit loop after successful removal
                        }
                        else
                        {
                            Console.WriteLine("Item not found in the pantry. Please enter a valid item.");
                        }
                    }
                    break;

                case "6":
                    Console.Clear();  // Clear again after the user selects an option
                    Console.WriteLine("Items About to Expire:");
                    foreach (var item in pantry.GetAboutToExpireItems())
                    {
                    Console.WriteLine(item.GetInfo());
                    }
                    break;


                case "7":
                    fileManager.SaveData(pantry, groceryList);
                    Console.WriteLine("Data saved. Exiting...");
                    return;

                default:
                    Console.Clear();  // Clear again if invalid option is selected
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();  // Wait for the user to press a key to continue
        }
    }
}
