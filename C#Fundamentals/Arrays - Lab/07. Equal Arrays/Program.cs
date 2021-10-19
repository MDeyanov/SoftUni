using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] nums1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            int sum1 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != nums1[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
                else
                {
                    sum += nums[i];


                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");

        }
    }
}
