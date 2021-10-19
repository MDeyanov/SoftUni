using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int[] reverseNumbers = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                reverseNumbers[i] = numbers[numbers.Length - 1 - i];
            }

            for (int i = 0; i < reverseNumbers.Length; i++)
            {
                Console.Write(reverseNumbers[i] + " ");
            }
        }
    }
}
