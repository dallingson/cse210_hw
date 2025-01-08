using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input your percentage grade:");
        string input = Console.ReadLine();
        int pgrade = int.Parse(input);

        string letter = "";
        string minus = "-";
        string plus = "+";
            
        if (pgrade >= 90)
        {
            letter = "A";
        } 
        else if (pgrade >= 80)
        {
            letter = "B";
        }
        else if (pgrade >= 70)
        {
            letter = "C";
        }
        else if (pgrade >= 60)
        {
            letter = "D";
        }
        else if (pgrade < 60)
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (pgrade > 70)
        {
            Console.WriteLine("Congratulations you passed!");
        }
        else 
        {
            Console.WriteLine("Sorry, you didn't pass, better luck next time.");
        }
    }
}