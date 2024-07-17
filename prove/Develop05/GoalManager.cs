using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private int _score;
    private List<Goal> _goals;

    public GoalManager()
    {
        _score = 0;
        _goals = new List<Goal>();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n1. Create Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];
            string status = goal.IsComplete() ? "[✔]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {goal.GetName()}");
        }
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter goal type (1: Simple, 2: Eternal, 3: Checklist): ");
        int goalType = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (goalType)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.WriteLine("Enter target number of completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
{
    ListGoalNames();
    Console.WriteLine("Select the number of the goal you accomplished: ");
    int goalIndex = int.Parse(Console.ReadLine()) - 1;

    if (goalIndex >= 0 && goalIndex < _goals.Count)
    {
        Goal goal = _goals[goalIndex];
        goal.RecordEvent();

        if (goal is ChecklistGoal checklistGoal)
        {
            if (checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetPoints(); 
                Console.WriteLine($"Bonus points awarded! Your score is now {_score}.");
            }
            else
            {
                _score += goal.GetPoints();
            }
        }
        else
        {
            _score += goal.GetPoints();
        }
        Console.WriteLine("Event recorded successfully.");
    }
    else
    {
        Console.WriteLine("Invalid goal number.");
    }
}

    public void SaveGoals()
    {
        using (StreamWriter file = new StreamWriter("goals.txt"))
        {
            file.WriteLine(_score);
            foreach (var goal in _goals)
            {
                file.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader file = new StreamReader("goals.txt"))
            {
                _score = int.Parse(file.ReadLine());
                _goals.Clear();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    string type = parts[0];
                    string[] goalParts = parts[1].Split(',');

                    switch (type)
                    {
                        case "SimpleGoal":
                            _goals.Add(new SimpleGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2])));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2])));
                            break;
                        case "ChecklistGoal":
                            _goals.Add(new ChecklistGoal(goalParts[0], goalParts[1], int.Parse(goalParts[2]), int.Parse(goalParts[3]), int.Parse(goalParts[4])));
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
