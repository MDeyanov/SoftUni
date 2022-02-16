using System;
using System.Linq;
using System.Collections.Generic;

namespace CountAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);


            PrintSumAndCount(int.Parse, a => a.Length, numbers => numbers.Sum());
             
            
        }

        static void PrintSumAndCount(Func<string, int> parser,
            Func<int[], int> countGetter,
            Func<int[], int> sumCalculator)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Console.WriteLine(countGetter(numbers));
            Console.WriteLine(sumCalculator(numbers));
        }
    }
}
