using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option (1-4): ");
            int choice = int.Parse(Console.ReadLine() ?? "4");

            if (choice == 4)
                break;

            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 30); 
                    break;
                case 2:
                    activity = new ReflectingActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 30); 
                    break;
                case 3:
                    activity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 30); 
                    break;
                default:
                    Console.WriteLine("Invalid choice, please select again.");
                    continue;
            }

            if (activity is BreathingActivity breathingActivity)
                breathingActivity.Run();
            else if (activity is ReflectingActivity reflectingActivity)
                reflectingActivity.Run();
            else if (activity is ListingActivity listingActivity)
                listingActivity.Run();
        }
    }
}
