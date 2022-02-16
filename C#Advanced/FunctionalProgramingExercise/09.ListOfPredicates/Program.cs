using System;
using System.Linq;
using System.Collections.Generic;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            Func<int[], int, bool> filter = (allDeviders, number) =>
            {
                return allDeviders.All(t => number % t == 0);
            };
            int[] divisibleNumbers = Enumerable.Range(1, range).Where(number => filter(dividers, number)).ToArray();

            Console.WriteLine(string.Join(" ",divisibleNumbers));
        }
    }
}
