using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        if (grade >= 90 && grade < 101)
        {
            Console.WriteLine("Your grade is an A");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("Your grade is a B");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("Your grade is a C");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("Your grade is a D");
        }
        else if (grade < 60)
        {
            Console.WriteLine("Your grade is an F");
        }
        else 
        {
            Console.WriteLine("Please enter a number 0-100");
        }

        if (grade >= 70)
        {
            Console.Write("You passed! ");
        }
        else 
        {
            Console.Write("You failed");
        }
    }
}