using System;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>(); //initialize the numbers list
        int input;
        int sum = 0;
        int largest = int.MinValue;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        do
        {
            Console.WriteLine("Enter number:");
            // Read input and convert to integer
            input = int.Parse(Console.ReadLine());
            
            //Append to list
            if (input != 0)
            {
                numbers.Add(input);
                sum += input;
                if (input > largest)
                {
                    largest = input; 
                }
            }
        } while (input != 0);

        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        // Display the results
        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }   
}