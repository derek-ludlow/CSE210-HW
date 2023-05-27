using System;
using System.Collections.Generic;

public class Word
{
    private string _letters;
    private bool _isHidden;

    public Word(string letters)
    {
        _letters = letters;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void UnHide()
    {
        _isHidden = false;
    }

    public string GetText()
    {
        if (_isHidden)
        {
            string underscores = "";
            int numLetters = _letters.Length;
            for (int i = 0; i < numLetters; i++)
            {
                underscores += "_ ";
            }

            return underscores;
        }
        else
        {
            return _letters;
        }
    }
}

public class Reference
{
    private string _referenceText;

    public Reference(string referenceText)
    {
        _referenceText = referenceText;
    }

    public string GetReferenceText()
    {
        return _referenceText;
    }
}

public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(" ");
        foreach (var w in words)
        {
            var wordObj = new Word(w);
            _words.Add(wordObj);
        }
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = _words.FindAll(word => !word.GetText().Contains("_"));
        if (visibleWords.Count == 0)
        {
            Console.WriteLine("All words are hidden. Press Enter to quit.");
            return;
        }

        Random random = new Random();
        int randomIndex = random.Next(0, visibleWords.Count);
        visibleWords[randomIndex].Hide();
    }

    public void ClearConsole()
    {
        Console.Clear();
    }

    public void DisplayScripture()
    {
        Console.WriteLine("Reference: " + _reference.GetReferenceText());
        foreach (var word in _words)
        {
            Console.Write(word.GetText() + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        // Create a reference object
        Reference reference = new Reference("John 3:16");

        // Create a scripture object
        string text = "For God so loved the world that He gave His only Begotten Son";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            scripture.ClearConsole();
            scripture.DisplayScripture();

            Console.WriteLine("Press Enter to hide a random word or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
        }
    }
}
