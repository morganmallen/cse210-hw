using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        ShowCountDown(5);

        GetListFromUser();

        Console.WriteLine($"You listed {_count} items.");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void GetListFromUser()
    {
        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write(">  ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrEmpty(entry))
            {
                _count++;
            }
        }
    }
}
