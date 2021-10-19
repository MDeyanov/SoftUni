using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Reveal")
                {
                    break;
                }
                string[] parts = line.Split(":|:");
                string command = parts[0];
                if (command == "InsertSpace")
                {
                    int index = int.Parse(parts[1]);
                    word = word.Insert(index, " ");
                }
                else if (command == "Reverse")
                {
                    string substring = parts[1];
                    if (word.Contains(substring))
                    {
                        string reverse = string.Concat(substring.Reverse());
                        int index = word.IndexOf(substring);
                        word = word.Remove(index, substring.Count());
                        word = word.Insert(word.Length, reverse);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = parts[1];
                    string newSubstring = parts[2];
                    word = word.Replace(substring, newSubstring);
                }
                Console.WriteLine(word);
            }
            Console.WriteLine($"You have a new text message: {word}");
        }
    }
}
