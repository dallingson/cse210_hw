public class FileManager
{
    private const string PantryFile = "pantry.csv";
    private const string GroceryFile = "grocery.csv";

    public void SaveData(Pantry pantry, GroceryList groceryList)
    {
        File.WriteAllLines(PantryFile, pantry.Items.ConvertAll(item => item.ToCsv()));
        File.WriteAllLines(GroceryFile, groceryList.Items.ConvertAll(item => item.ToCsv()));
    }

    public void LoadData(Pantry pantry, GroceryList groceryList)
    {
        if (File.Exists(PantryFile))
        {
            foreach (var line in File.ReadAllLines(PantryFile))
            {
                var data = line.Split(',');
                pantry.AddItem(new Item(data[0], int.Parse(data[1]), decimal.Parse(data[2]), true, DateOnly.Parse(data[4])));
            }
        }
        if (File.Exists(GroceryFile))
        {
            foreach (var line in File.ReadAllLines(GroceryFile))
            {
                var data = line.Split(',');
                groceryList.AddItem(new Item(data[0], int.Parse(data[1]), decimal.Parse(data[2]), false, DateOnly.Parse(data[4])));
            }
        }
    }
}

