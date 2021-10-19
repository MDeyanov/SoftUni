using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int oddNUms = 0;
            int evenNums = 0;
            int currentNum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentNum = nums[i];
                if (currentNum % 2 == 0)
                {
                    evenNums += currentNum;
                }
                else
                {
                    oddNUms += currentNum;
                }
            }
            Console.WriteLine($"{evenNums - oddNUms}");
        }
    }
}
