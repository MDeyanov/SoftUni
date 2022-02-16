using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int line = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();
            FillSet(elements, line);

            Console.WriteLine(string.Join(" ", elements));
        }

        private static SortedSet<string> FillSet(SortedSet<string> elements, int line)
        {
            for (int i = 0; i < line; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    elements.Add(input[j]);
                }
            }
            return elements;
        }
    }
}
