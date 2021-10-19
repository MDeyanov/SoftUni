using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int limit = nums.Count / 2;

            for (int i = 0; i < limit; i++)
            {
                nums[i] += nums[nums.Count - 1];
                nums.RemoveAt(nums.Count - 1);
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
