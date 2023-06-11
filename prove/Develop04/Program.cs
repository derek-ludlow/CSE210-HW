using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                Console.Write("Enter the duration in seconds for the Breathing Activity: ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                BreathingActivity breathingActivity = new BreathingActivity(duration);
                breathingActivity.Start();
            }
            else if (choice == 2)
            {
                Console.Write("Enter the duration in seconds for the Reflection Activity: ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                reflectionActivity.Start();
            }
            else if (choice == 3)
            {
                Console.Write("Enter the duration in seconds for the Listing Activity: ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine();

                ListingActivity listingActivity = new ListingActivity(duration);
                listingActivity.Start();
            }
            else if (choice == 4)
            {
                break;
            }

            Console.WriteLine();
        }
    }
}

// Base class for all activities
abstract class Activity
{
    protected int duration;

    public Activity(int duration)
    {
        this.duration = duration;
    }

    public abstract void Start();

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rPausing... {i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> animations = new List<string>
        {
            "-",
            "\\",
            "|",
            "/"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int animationIndex = 0;

        while (DateTime.Now < endTime)
        {
            string frame = animations[animationIndex];
            Console.Write($"\rLoading... {frame}");

            Thread.Sleep(250);

            Console.Write("\b \b");

            animationIndex++;
            if (animationIndex >= animations.Count)
            {
                animationIndex = 0;
            }
        }

        Console.Write("\r");
    }
}

// Breathing Activity
class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        Pause(3);

        Console.Write("Enter the duration in seconds for each breath: ");
        int breathDuration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        Pause(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe In");
            ShowSpinner(breathDuration);

            Console.WriteLine("Breathe Out");
            ShowSpinner(breathDuration);
        }

        Console.WriteLine();
        Console.WriteLine("Good job! You have completed the Breathing Activity.");
        Pause(3);
    }
}

// Reflection Activity
class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
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

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Pause(3);

        Console.WriteLine("Enter the duration in seconds for reflection: ");
        int reflectionDuration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        Pause(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string prompt = prompts[new Random().Next(prompts.Count)];
            Console.WriteLine(prompt);

            Pause(3);

            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine(question);
                ShowSpinner(2);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Good job! You have completed the Reflection Activity.");
        Pause(3);
    }
}

// Listing Activity
class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Pause(3);

        Console.WriteLine("Enter the duration in seconds for listing: ");
        int listingDuration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        Pause(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string prompt = prompts[new Random().Next(prompts.Count)];
            Console.WriteLine(prompt);

            Pause(3);
            Console.Write("Start listing: ");

            DateTime listingEndTime = DateTime.Now.AddSeconds(listingDuration);
            int itemCounter = 0;

            while (DateTime.Now < listingEndTime)
            {
                string item = Console.ReadLine();
                itemCounter++;
            }

            Console.WriteLine($"Number of items listed: {itemCounter}");
            Pause(2);
        }

        Console.WriteLine();
        Console.WriteLine("Good job! You have completed the Listing Activity.");
        Pause(3);
    }
}
