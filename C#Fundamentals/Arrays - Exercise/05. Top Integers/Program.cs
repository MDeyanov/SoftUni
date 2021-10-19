using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNumber = nums[i];
                bool isTopNumber = true;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int rightNumber = nums[j];
                    if (currentNumber <= rightNumber)
                    {
                        isTopNumber = false;
                        break;
                    }
                }
                if (isTopNumber)
                {
                    Console.Write($"{currentNumber} ");
                }
            }
            Console.WriteLine();
        }
    }
}
