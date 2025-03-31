class Program
{
    static void Main()
    {
        Pantry pantry = new Pantry();
        GroceryList groceryList = new GroceryList();
        FileManager fileManager = new FileManager();
        UserInterface ui = new UserInterface();
        ui.ShowMenu(pantry, groceryList, fileManager);
    }
}