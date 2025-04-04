using System;
using System.Collections.Generic;

public abstract class Storage
{
    public string _name;  
    public List<FoodItem> _items;  

    public Storage(string name, List<FoodItem> items)
    {
        _name = name;
        _items = items;
    }
    public void AddItem(FoodItem item)
    {
        _items.Add(item);  
    }

    public void RemoveItem(string itemName)
    {
        _items.RemoveAll(item => item._name == itemName);  
    }

    public abstract void DisplayStorage();
}
