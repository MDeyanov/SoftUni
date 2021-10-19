using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int j = 0; j < rotations; j++)
            {
                int firstNum = nums[0];
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    nums[i] = nums[i + 1];
                }
                nums[nums.Length - 1] = firstNum;
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
