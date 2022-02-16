using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            FillDictionary(symbols, input);
            PrintResult(symbols);
        }

        private static void PrintResult(SortedDictionary<char, int> symbols)
        {
            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }

        }

        static SortedDictionary<char, int> FillDictionary(SortedDictionary<char, int> symbols, string input)
        {
            foreach (char character in input)
            {
                if (!symbols.ContainsKey(character))
                {
                    symbols.Add(character, 0);
                }
                symbols[character]++;
            }
            return symbols;
        }
    }
}
