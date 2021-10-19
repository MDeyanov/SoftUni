using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstNum = input[0];
                int secNum = input[1];

                if (i % 2 == 0)
                {
                    firstArray[i] = firstNum;
                    secondArray[i] = secNum;
                }
                else
                {
                    firstArray[i] = secNum;
                    secondArray[i] = firstNum;
                }
            }
            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}
