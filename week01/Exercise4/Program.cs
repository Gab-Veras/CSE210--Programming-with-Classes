using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
    List<int> numbers = new List<int>();
    int userNumber = 1;
    decimal sum = 0;
    int numbersQuantity = 0;
    decimal average = 0;
    int biggestNumber = 0;
    int smallestNumber = 0;

    
    Console.Write("Enter a list of numbers, type 0 when finished.\n");
    
    while (userNumber != 0)
        {
        Console.Write("Enter a number: ");
        userNumber = int.Parse(Console.ReadLine());
        if (userNumber != 0)
            {
            numbers.Add (userNumber);
            }
        else
            {
            Console.Write("\nThe numbers of the list are: ");
            Console.WriteLine(string.Join(", ", numbers));
            }
        }
    foreach (int number in numbers)
        {
        sum = number + sum;
        numbersQuantity += 1;
        if (number > biggestNumber)
            {
            biggestNumber = number;
            }
        if (number >= 0)
            {   
            smallestNumber = number;
            if (smallestNumber <= number)
                {
                smallestNumber = number;
                }
            }
        }
    numbers.Sort();
    average = sum / numbersQuantity;
    Console.WriteLine($"The sum is: {sum}");  
    Console.WriteLine($"The average is: {average:F2}"); 
    Console.WriteLine($"The largest number is: {biggestNumber}"); 
    Console.WriteLine($"The smallest positive number is: {smallestNumber}");
    Console.WriteLine($"The sorted list is: {string.Join(", ", numbers)}");
    }
}

