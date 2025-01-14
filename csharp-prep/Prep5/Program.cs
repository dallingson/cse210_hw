using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        // Display a welcome message
        DisplayMessage();

        // Prompt user for their name
        string name = PromptUserName();

        // Prompt user for their favorite number
        int number = PromptUserNumber();

        // Calculate the square of the number
        int squared = SquareNumber(number);

        // Display the results
        DisplayResults(name, squared);

        static void DisplayMessage() // Display the welcome message
        {
            Console.WriteLine("Welcome to the Program!");
        }
        
        static string PromptUserName() // Ask for the users name
        {
            Console.WriteLine("Type in your name:");
            string name = Console.ReadLine();
            return name;

        }

        static int PromptUserNumber() // Ask for the users favorite number
        {
            Console.WriteLine("Type in your favorite number:");
            string num = Console.ReadLine();
            int number = int.Parse(num);

            return number;
        }

        static int SquareNumber(int number) // square the users favorite number
        {
            int square = number * number;
            return square;
        }

        static void DisplayResults(string name, int squared) // display results
        {
            Console.WriteLine($"{name}, the square of your number is {squared}");           
        }
    

    }
}