using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Assignment a1 = new Assignment("Dallin Georgeson", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        MathAssignment a2 = new MathAssignment("Billy Smith", "Fractions", "9.2", "1-10");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment a3 = new WritingAssignment("George Jenkins", "American History", "The Tragedy of the Civil War");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
        Console.WriteLine();
    }
}