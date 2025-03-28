using System;
using System.Collections.Generic;

// A FEW TEST CASES FOR THE PANTRY AND GROCERYLIST

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Shelf Stocker!");
        
        // Create some pantry items
        PantryItem milk = new PantryItem("Milk", 2, 2.99m, DateOnly.FromDateTime(DateTime.Now.AddDays(5)));
        PantryItem bread = new PantryItem("Bread", 1, 1.99m, DateOnly.FromDateTime(DateTime.Now.AddDays(2)));
        
        // Create some grocery items
        GroceryItem eggs = new GroceryItem("Eggs", 12, 3.99m);
        GroceryItem cheese = new GroceryItem("Cheese", 1, 4.49m);
        
        // Display item info
        Console.WriteLine(milk.GetInfo());
        Console.WriteLine(bread.GetInfo());
        Console.WriteLine(eggs.GetInfo());
        Console.WriteLine(cheese.GetInfo());
        
        // Simulate using an item
        bread.UseItem(1);
        Console.WriteLine("After using Bread:");
        Console.WriteLine(bread.GetInfo());
        
        // Mark an item as purchased
        eggs.MarkAsPurchased();
        Console.WriteLine("After purchasing Eggs:");
        Console.WriteLine(eggs.GetInfo());
    }
}