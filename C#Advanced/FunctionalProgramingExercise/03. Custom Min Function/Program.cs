using System;
using System.Linq;
using System.Collections.Generic;


namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //Console.WriteLine(input.Min());
            Func<int[], int> minNumber = n => n.Min();
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(minNumber(numbers));
        }
    }
}
