using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> top5 = new List<int>();
            double average = integers.Average();
            top5 = integers.Where(i => i > average).OrderByDescending(i => i).Take(5).ToList();

            Console.WriteLine(top5.Count > 0 ? string.Join(" ", top5) : "No");
            //SameSolution
            //List<int> sequenceIntegers = Console
            //          .ReadLine()
            //          .Split()
            //          .Select(int.Parse)
            //          .ToList();

            //List<int> nums = new List<int>();

            //double averageSum = sequenceIntegers.Average();


            //nums = sequenceIntegers
            //  .OrderByDescending(x => x)
            //  .Where(num => num > averageSum)
            //  .Take(5)
            //  .ToList();

            //if (nums.Count <= 0)
            //{
            //    Console.WriteLine("No");
            //    return;
            //}

            //Console.WriteLine(string.Join(" ", nums));

        }
    }
}
