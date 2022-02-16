using System;
using System.Linq;
using System.Collections.Generic;


namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var querry = Console.ReadLine();

            Predicate<int> predicate = querry == "odd"
                ? new Predicate<int>((number) => number % 2 != 0) 
                : new Predicate<int>((number) => number % 2 == 0);

            var result = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
