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
        Console.WriteLine(milk.getInfo());
        Console.WriteLine(bread.getInfo());
        Console.WriteLine(eggs.getInfo());
        Console.WriteLine(cheese.getInfo());
        
        // Simulate using an item
        bread.useItem(1);
        Console.WriteLine("After using Bread:");
        Console.WriteLine(bread.getInfo());
        
        // Mark an item as purchased
        eggs.markAsPurchased();
        Console.WriteLine("After purchasing Eggs:");
        Console.WriteLine(eggs.getInfo());
    }
}