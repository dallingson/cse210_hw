using System;
using System.Linq;

public class ItemMover
{
    public bool MoveItem(GroceryList groceryList, Pantry pantry, Fridge fridge, Freezer freezer, string itemName, string storageType)
    {
        FoodItem item = groceryList._items.FirstOrDefault(i => i._name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            groceryList.RemoveItem(item);
            AddToStorage(item, pantry, fridge, freezer, storageType);
            Console.WriteLine($"Moved {item._name} to {storageType}.");
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
        FoodItem item = pantry._items.FirstOrDefault(i => i._name.Equals(itemName, StringComparison.OrdinalIgnoreCase)) ??
                        fridge._items.FirstOrDefault(i => i._name.Equals(itemName, StringComparison.OrdinalIgnoreCase)) ??
                        freezer._items.FirstOrDefault(i => i._name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (item != null)
        {
            RemoveFromStorage(item, pantry, fridge, freezer);
            groceryList.AddItem(item);
            Console.WriteLine($"Moved {item._name} back to grocery list.");
            return true;
        }

        return false;
    }

    private void RemoveFromStorage(FoodItem item, Pantry pantry, Fridge fridge, Freezer freezer)
    {
        pantry.RemoveItem(item._name);
        fridge.RemoveItem(item._name);
        freezer.RemoveItem(item._name);
    }
}
