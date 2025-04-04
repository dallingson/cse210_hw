using System;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    private const string GroceryListFile = "groceryList.csv";
    private const string PantryFile = "pantry.csv";
    private const string FridgeFile = "fridge.csv";
    private const string FreezerFile = "freezer.csv";

    public void SaveData(GroceryList groceryList, Pantry pantry, Fridge fridge, Freezer freezer)
    {
        SaveToCsv(groceryList.GetItems(), GroceryListFile);
        SaveToCsv(pantry.GetItems(), PantryFile);
        SaveToCsv(fridge.GetItems(), FridgeFile);
        SaveToCsv(freezer.GetItems(), FreezerFile);

        Console.WriteLine("Data has been saved.");
    }

    public void LoadData(GroceryList groceryList, Pantry pantry, Fridge fridge, Freezer freezer)
    {
        groceryList.SetItems(LoadFromCsv(GroceryListFile));
        pantry.SetItems(LoadFromCsv(PantryFile));
        fridge.SetItems(LoadFromCsv(FridgeFile));
        freezer.SetItems(LoadFromCsv(FreezerFile));

        Console.WriteLine("Data has been loaded.");
    }

    private void SaveToCsv(List<FoodItem> items, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var item in items)
            {
                string expirationDate = item.GetExpirationDate()?.ToString("yyyy-MM-dd") ?? "";
                writer.WriteLine($"{item.GetName()},{item.GetPrice()},{expirationDate}");
            }
        }
    }

    private List<FoodItem> LoadFromCsv(string fileName)
    {
        var items = new List<FoodItem>();

        if (File.Exists(fileName))
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var parts = line.Split(',');

                string name = parts[0];
                decimal price = decimal.Parse(parts[1]);

                // Check if expiration date is not empty or null, and assign accordingly
                DateTime? expirationDate = string.IsNullOrEmpty(parts[2]) ? (DateTime?)null : DateTime.Parse(parts[2]);

                // Create FoodItem with nullable DateTime
                items.Add(new FoodItem(name, price, expirationDate));
            }
        }

        return items;
    }
}
