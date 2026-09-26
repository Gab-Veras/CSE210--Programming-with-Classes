using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1  = new Fraction();
        
        Console.Write("Enter your numerator: ");
        int top = int.Parse(Console.ReadLine());
        fraction1.SetTop(top);

        Console.Write("Enter your denominator: ");
        int bottom = int.Parse(Console.ReadLine());
        fraction1.SetBottom(bottom);

        Console.WriteLine($"The numerator is {fraction1.GetTop()}");
     
        Console.WriteLine($"The denominator is {fraction1.GetBottom()}");

        Console.WriteLine($"The decimal number is {fraction1.GetDecimalValue():F2}");
    }
}