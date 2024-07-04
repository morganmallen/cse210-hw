using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {

    }
    public void Run()
    {
        DisplayStartingMessage();
        
        int elapsed = 0;
        int breatheInTime = 5; 
        int breatheOutTime = 5; 

        while (elapsed < GetDuration())
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(breatheInTime);
            
            Console.WriteLine("Breathe out...");
            ShowCountDown(breatheOutTime);
            
            elapsed += breatheInTime + breatheOutTime;
        }
        
        DisplayEndingMessage();
    }
}
