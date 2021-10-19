using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] condensedNums = new int[nums.Length - 1];

            if (nums.Length == 1)
            {
                Console.WriteLine(nums[0]);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < condensedNums.Length - i; j++)
                {
                    condensedNums[j] = nums[j] + nums[j + 1];
                }
                nums = condensedNums;
            }
            Console.WriteLine(condensedNums[0]);
        }
    }
}
