using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] bombData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bombNumber = bombData[0];
            int bombPower = bombData[1];

            while (true)
            {
                int index = numbers.IndexOf(bombNumber);
                if (index == -1)
                {
                    break;
                }
                int startIndex = index - bombPower;
                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int count = 2 * bombPower + 1;

                if (count > numbers.Count - startIndex)
                {
                    count = numbers.Count - startIndex;
                }
                numbers.RemoveRange(startIndex, count);
            }
            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
