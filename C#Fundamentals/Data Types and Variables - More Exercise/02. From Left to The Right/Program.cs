using System;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            for (int i = 0; i < x; i++)
            {
                string inputNumbers = Console.ReadLine();
                char delimiter = ' ';
                string[] splitnumbers = inputNumbers.Split(delimiter);
                long left = long.Parse(splitnumbers[0]);
                long right = long.Parse(splitnumbers[1]);
                long highestNumber = right;
                if (left > right)
                {
                    highestNumber = left;
                }
                long sumOfDiggits = 0;
                while (highestNumber != 0)
                {
                    sumOfDiggits += highestNumber % 10;
                    highestNumber /= 10;
                }
                Console.WriteLine($"{Math.Abs(sumOfDiggits)}");
            }
        }
    }
}
