using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> doubles = new Dictionary<double, int>();
            double[] valuesForDict = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            foreach (var value in valuesForDict)
            {
                if (!doubles.ContainsKey(value))
                {
                    doubles.Add(value, 0);
                }

                doubles[value]++;
            }

            foreach (var @double in doubles)
            {
                Console.WriteLine($"{@double.Key} - {@double.Value} times");
            }
        }
    }
}
