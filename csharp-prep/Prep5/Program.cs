using System;

// FUNCTIONS 
// returnType FunctionName(dataType parameter1, dataType parameter2)
// {
//     // function_body
// }
// C#
// void DisplayMessage()
// {
//     Console.WriteLine("Hello world!");
// }
// Python 
// def display_message():
//     print("Hello World")

// SINGLE STRING PARAMETER 
// void DisplayPersonalMessage(string userName)
// {
//     Console.WriteLine($"Hello {userName}");
// }
// ACCEPTS TWO INTEGERS AS A PARAMETER
// int AddNumbers(int first, int second)
// {
//     int sum = first + second;
//     return sum;
// }
// FUNCTIONS VS METHODS 
// static void DisplayMessage()
// {
//     Console.WriteLine("Hello world!");
// }

// static void DisplayPersonalMessage(string userName)
// {
//     Console.WriteLine($"Hello {userName}");
// }

// static int AddNumbers(int first, int second)
// {
//     int sum = first + second;
//     return sum;
// }
// ***** USE STATIC FOR ALL YOUR FUNCTIONS UNTIL WE START WRITING CLASSES 
class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }

}