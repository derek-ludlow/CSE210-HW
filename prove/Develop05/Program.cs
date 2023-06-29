using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Run();
    }
}

// Base class for all goals
class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    public virtual string GetData()
    {
        return $"Goal#{Name}#{Description}#{Points}";
    }
}

// Derived class for simple goals
class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }

    public override string GetData()
    {
        return $"SimpleGoal#{Name}#{Description}#{Points}#{IsCompleted}";
    }
}

// Derived class for eternal goals
class EternalGoal : Goal
{
    public override string GetData()
    {
        return $"EternalGoal#{Name}#{Description}#{Points}";
    }
}

// Derived class for checklist goals
class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    public int CompletedCount { get; set; }

    public override string GetData()
    {
        return $"ChecklistGoal#{Name}#{Description}#{Points}#{CompletedCount}#{RequiredCount}";
    }
}

// Class to manage the menu and user interface
class Menu
{
    private List<Goal> goals;
    private int score;

    public Menu()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("----- Eternal Quest Program -----");
        Console.WriteLine("1. Create a new goal");
        Console.WriteLine("2. Record an event");
        Console.WriteLine("3. Show goals");
        Console.WriteLine("4. Show score");
        Console.WriteLine("5. Save goals and score");
        Console.WriteLine("6. Load goals and score");
        Console.WriteLine("7. Exit");
        Console.WriteLine("---------------------------------");
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter the goal type (1 = Simple, 2 = Eternal, 3 = Checklist):");
        int goalType = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the goal description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the goal points:");
        int points = int.Parse(Console.ReadLine());

        Goal goal;
        switch (goalType)
        {
            case 1:
                goal = new SimpleGoal();
                break;
            case 2:
                goal = new EternalGoal();
                break;
            case 3:
                Console.WriteLine("Enter the required count for the checklist goal:");
                int requiredCount = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal { RequiredCount = requiredCount };
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goal.Name = name;
        goal.Description = description;
        goal.Points = points;

        goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        Console.WriteLine("Enter the index of the goal to record an event:");
        int index = int.Parse(Console.ReadLine());

        if (index < 0 || index >= goals.Count)
        {
            Console.WriteLine("Invalid goal index.");
            return;
        }

        Goal goal = goals[index];
        int points = goal.Points;

        if (goal is SimpleGoal simpleGoal)
        {
            if (!simpleGoal.IsCompleted)
            {
                simpleGoal.IsCompleted = true;
                Console.WriteLine($"Congratulations! You completed the simple goal: {goal.Name}");
                points += 500; // Apply bonus points for completing the simple goal
            }
            else
            {
                Console.WriteLine("This simple goal has already been completed.");
                return;
            }
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            if (checklistGoal.CompletedCount < checklistGoal.RequiredCount)
            {
                checklistGoal.CompletedCount++;
                Console.WriteLine($"Congratulations! You completed {goal.Name} ({checklistGoal.CompletedCount}/{checklistGoal.RequiredCount})");

                if (checklistGoal.CompletedCount == checklistGoal.RequiredCount)
                {
                    Console.WriteLine($"You achieved the checklist goal: {goal.Name}");
                    points += 500; // Apply bonus points for completing the checklist goal
                }
            }
            else
            {
                Console.WriteLine("This checklist goal has already been completed.");
                return;
            }
        }
        else
        {
            Console.WriteLine($"Great job! You made progress on the eternal goal: {goal.Name}");
        }

        score += points;
        Console.WriteLine($"Points: {points}, Total Score: {score}");
    }

    public void ShowGoals()
    {
        Console.WriteLine("----- Goals -----");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i}. {goal.Name} ({goal.Points} points)");
        }
        Console.WriteLine("-----------------");
    }

    public void ShowScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public void SaveData()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetData());
            }
            writer.WriteLine(score);
        }
        Console.WriteLine("Goals and score saved successfully.");
    }

    public void LoadData()
    {
        goals.Clear();
        score = 0;

        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('#');
                    string goalType = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    Goal goal;
                    switch (goalType)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal();
                            bool isCompleted = bool.Parse(parts[4]);
                            ((SimpleGoal)goal).IsCompleted = isCompleted;
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal();
                            break;
                        case "ChecklistGoal":
                            goal = new ChecklistGoal();
                            int completedCount = int.Parse(parts[4]);
                            int requiredCount = int.Parse(parts[5]);
                            ((ChecklistGoal)goal).CompletedCount = completedCount;
                            ((ChecklistGoal)goal).RequiredCount = requiredCount;
                            break;
                        default:
                            Console.WriteLine("Invalid goal type.");
                            return;
                    }

                    goal.Name = name;
                    goal.Description = description;
                    goal.Points = points;

                    goals.Add(goal);
                }

                if (int.TryParse(reader.ReadLine(), out int loadedScore))
                {
                    score = loadedScore;
                }
            }
            Console.WriteLine("Goals and score loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved data found.");
        }
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            DisplayMenu();
            Console.WriteLine("Enter your choice:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ShowGoals();
                    break;
                case 4:
                    ShowScore();
                    break;
                case 5:
                    Console.WriteLine("Saving goals and score...");
                    SaveData();
                    break;
                case 6:
                    Console.WriteLine("Loading goals and score...");
                    LoadData();
                    break;
                case 7:
                    Console.WriteLine("Exiting...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
