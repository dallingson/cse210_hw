using System;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>(); //initialize the numbers list
        int input;
        int sum = 0;
        
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
            }
        } while (input != 0);

        // calculate the sum
        
        foreach(int number in numbers)
        {
            sum += number;
        } 

        // find the average
        float average = ((float)sum) / numbers.Count;


        // find the max
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Display the results
        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }   
}