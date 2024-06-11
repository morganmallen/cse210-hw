using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(squaredNumber, userName);
    }
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program! ");
        }

        static string PromptUserName()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number? ");
            int number = int.Parse(Console.ReadLine());
            
            return number;
        }

        static int SquareNumber(int userNumber)
        {
            int square = userNumber * userNumber;

            return square;
        }
        
        static void DisplayResult(int square, string userName)
        {
            Console.Write($"{userName}, the square of your number is {square} ");
        }
    }
