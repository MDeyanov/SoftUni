using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false;

            if (input.Length == 1)
            {

                Console.WriteLine($"{0}");
                return;

            }
            for (int i = 0; i < input.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;


                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += input[j];
                }
                for (int j = i + 1; j < input.Length; j++)
                {
                    rightSum += input[j];
                }
                if (leftSum == rightSum && input.Length > 1)
                {
                    isFound = true;
                    Console.WriteLine(i);
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
