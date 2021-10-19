using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split("|").ToArray();
            List<string> result = new List<string>();
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                string[] elements = numbers[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(elements);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
