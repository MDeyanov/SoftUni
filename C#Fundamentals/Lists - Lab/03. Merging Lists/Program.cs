using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> secList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> result = new List<int>(firstList.Count + secList.Count);
            int limit = Math.Min(firstList.Count, secList.Count);

            for (int i = 0; i < limit; i++)
            {

                result.Add(firstList[i]);
                result.Add(secList[i]);

            }
            int biggest = Math.Max(firstList.Count, secList.Count);
            for (int i = limit; i < biggest; i++)
            {
                if (biggest == firstList.Count)
                {
                    result.Add(firstList[i]);
                }
                else
                {
                    result.Add(secList[i]);
                }

            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
