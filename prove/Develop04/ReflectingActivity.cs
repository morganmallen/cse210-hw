using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "-- Think of a time when you stood up for someone else. --",
        "-- Think of a time when you did something really difficult. --",
        "-- Think of a time when you helped someone in need. --",
        "-- Think of a time when you did something truly selfless. --"
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(string name, string description, int duration) 
        : base(name, description, duration) 
    { }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Clear();
    }

    public void DisplayQuestions()
    {
        int totalDuration = GetDuration();
        int questionInterval = 10;
        int numQuestions = totalDuration / questionInterval;

        for (int i = 0; i < numQuestions; i++)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(questionInterval); 
        }

        int remainingTime = totalDuration % questionInterval;
        if (remainingTime > 0)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(remainingTime);
            Console.Clear();
        }
    }
}
