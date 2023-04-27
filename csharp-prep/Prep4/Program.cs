using System;
using System.Collections.Generic;

// LISTS 
// List<int> numbers = new List<int>();
// List<string> words = new List<string>();
// using System.Collections.Generic; - Any file that uses lists(or any other standard collection), must refer to that library at the top of the file

// ADDING ITEMS TO THE LIST 
// List<string> words = new List<string>();
// words.Add("phone");
// words.Add("keyboard");
// words.Add("mouse");

// GETTING THE LIST SIZE 
// Console.WriteLine(words.Count);

// ITERATING THROUGH A LIST 
// foreach (string word in words)
// {
//     Console.WriteLine(word);
// }
// ACCESSING ITEMS BY THEIR INDEX 
// for (int i = 0; i < words.Count; i++)
// {
//     Console.WriteLine(words[i]);
// }
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit)");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);


            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }
        // PART 1 - compute the sum 
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // PART 2 - compute average 
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");


        // PART 3 - find max 
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The mas is: {max}");
    }
}