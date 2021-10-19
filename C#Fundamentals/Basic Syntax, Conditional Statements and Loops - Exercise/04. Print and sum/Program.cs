using System;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = start; i <= finish; i++)
            {
                sum += i;
                Console.Write($"{i} ");

            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
