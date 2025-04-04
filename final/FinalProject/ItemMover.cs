using System;
using System.Linq;

public class ItemMover
{
    public bool MoveItem(GroceryList groceryList, Pantry pantry, Fridge fridge, Freezer freezer, string itemName, string storageType)
    {
        // Using getters to access the _items list
        FoodItem item = groceryList.GetItems().FirstOrDefault(i => i.GetName().Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            groceryList.RemoveItem(item);
            AddToStorage(item, pantry, fridge, freezer, storageType);
            Console.WriteLine($"Moved {item.GetName()} to {storageType}.");
            return true;
        }

        return false;
    }

    private void AddToStorage(FoodItem item, Pantry pantry, Fridge fridge, Freezer freezer, string storageType)
    {
        switch (storageType.ToLower())
        {
            case "pantry":
                pantry.AddItem(item);
                break;
            case "fridge":
                fridge.AddItem(item);
                break;
            case "freezer":
                freezer.AddItem(item);
                break;
            default:
                Console.WriteLine("Invalid storage type.");
                break;
        }
    }

    public bool MoveItemBackToGroceryList(GroceryList groceryList, Pantry pantry, Fridge fridge, Freezer freezer, string itemName)
    {
        // Using getters to access the _items list in pantry, fridge, and freezer
        FoodItem item = pantry.GetItems().FirstOrDefault(i => i.GetName().Equals(itemName, StringComparison.OrdinalIgnoreCase)) ??
                        fridge.GetItems().FirstOrDefault(i => i.GetName().Equals(itemName, StringComparison.OrdinalIgnoreCase)) ??
                        freezer.GetItems().FirstOrDefault(i => i.GetName().Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            RemoveFromStorage(item, pantry, fridge, freezer);
            groceryList.AddItem(item);
            Console.WriteLine($"Moved {item.GetName()} back to grocery list.");
            return true;
        }

        return false;
    }

    private void RemoveFromStorage(FoodItem item, Pantry pantry, Fridge fridge, Freezer freezer)
    {
        pantry.RemoveItem(item.GetName());
        fridge.RemoveItem(item.GetName());
        freezer.RemoveItem(item.GetName());
    }
}
