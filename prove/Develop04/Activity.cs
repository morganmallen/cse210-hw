using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity.");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How many seconds do you want to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        // Console.Clear();
        Console.WriteLine("Good job!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        int endTime = Environment.TickCount + seconds * 1000;
        string[] spinner = new string[] { "-", "\\", "|", "/" };
        int spinnerIndex = 0;

        while (Environment.TickCount < endTime)
        {
            Console.Write(spinner[spinnerIndex]);
            Thread.Sleep(200); 
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
        }
    }

    public void ShowCountDown(int seconds)
    {
        while (seconds > 0)
        {
            Console.WriteLine($"Time remaining: {seconds} seconds");
            Thread.Sleep(1000);
            seconds--;
            Console.Clear();
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}
