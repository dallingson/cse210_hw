// Class to manage reading from and writing to files (saving and loading pantry/grocery list data)
public class FileManager
{
    private const string PantryFile = "pantry.csv";
    private const string GroceryFile = "grocery.csv";

    // Method to save data to files
    public void SaveData(Pantry pantry, GroceryList groceryList)
    {
        File.WriteAllLines(PantryFile, pantry.Items.ConvertAll(item => item.ToCsv()));
        File.WriteAllLines(GroceryFile, groceryList.Items.ConvertAll(item => item.ToCsv()));
    }

    // Method to load data from files
    public void LoadData(Pantry pantry, GroceryList groceryList)
    {
        if (File.Exists(PantryFile))
        {
            foreach (var line in File.ReadAllLines(PantryFile))
            {
                var data = line.Split(',');
                DateOnly? expirationDate = string.IsNullOrEmpty(data[5]) ? null : DateOnly.Parse(data[5]);
                if (data[3] == "Perishable")
                {
                    pantry.AddItem(new PerishableItem(data[0], int.Parse(data[1]), decimal.Parse(data[2]), data[3], expirationDate.Value));
                }
                else
                {
                    pantry.AddItem(new NonPerishableItem(data[0], int.Parse(data[1]), decimal.Parse(data[2]), data[3], expirationDate.Value));
                }
            }
        }
        if (File.Exists(GroceryFile))
        {
            foreach (var line in File.ReadAllLines(GroceryFile))
            {
                var data = line.Split(',');
                DateOnly? expirationDate = string.IsNullOrEmpty(data[5]) ? null : DateOnly.Parse(data[5]);
                if (data[3] == "Perishable")
                {
                    groceryList.AddItem(new PerishableItem(data[0], int.Parse(data[1]), decimal.Parse(data[2]), data[3], expirationDate.Value));
                }
                else
                {
                    groceryList.AddItem(new NonPerishableItem(data[0], int.Parse(data[1]), decimal.Parse(data[2]), data[3], expirationDate.Value));
                }
            }
        }
    }
}