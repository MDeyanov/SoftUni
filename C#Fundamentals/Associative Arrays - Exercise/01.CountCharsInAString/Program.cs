using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();

            string word = Console.ReadLine();

            foreach (var letter in word)
            {
                if (letter == ' ')
                {
                    continue;
                }

                if (counts.ContainsKey(letter))
                {
                    counts[letter] += 1;
                }
                else
                {
                    counts.Add(letter, 1);
                }
            }

            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
