using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number?");
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1,20);

        int guess = -1;
        int attempts = 0;
    
    while (guess != magic_number) //loop until guess matches the magic number
    {
        Console.WriteLine("What is your guess?");
        string input_1 = Console.ReadLine();
        guess = int.Parse(input_1);
        attempts++; //add guess attempts

        if (guess < magic_number)
        {
            Console.WriteLine("Higher");
        }
            else if (guess > magic_number)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine($"You Guessed it in {attempts} attempts!");
        }
        }
    }
}