using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var devisibleNumber = int.Parse(Console.ReadLine());
            Predicate<int> filter = numbers => numbers % devisibleNumber != 0;
            Console.WriteLine(string.Join(" ",numbers.Reverse().Where(x=>filter(x))));
        }
    }
}
