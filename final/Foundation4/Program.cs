using System;
class Program
{
    static void Main()
    {
        var running = new Running(new DateTime(2024, 7, 10), 30, 5.0); 
        var cycling = new Cycling(new DateTime(2024, 7, 11), 45, 20.0); 
        var swimming = new Swimming(new DateTime(2024, 7, 12), 60, 30); 

        var activities = new List<Activity> { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
