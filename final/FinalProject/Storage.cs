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

    public bool RemoveItem(string name) // Remove Items
    {
        FoodItem item = _items.FirstOrDefault(i => i._name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (item != null)
        {
            _items.Remove(item);
            return true;
        }
        return false;
    }
    public List<FoodItem> GetExpiringItems(int days = 7) // See whats about to expire
    {
        DateTime now = DateTime.Now;
        return _items
            .Where(i => i._expirationDate.HasValue && (i._expirationDate.Value - now).TotalDays <= days && (i._expirationDate.Value - now).TotalDays >= 0)
            .ToList();
    }


    public abstract void DisplayStorage(); //Display items in storage
}
