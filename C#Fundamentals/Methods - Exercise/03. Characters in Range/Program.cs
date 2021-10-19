using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char sec = char.Parse(Console.ReadLine());

            char start = first;
            char end = sec;
            if (sec < first)
            {
                start = sec;
                end = first;
            }
            PrintCharInRange(start, end);
        }

        private static void PrintCharInRange(char start, char end)
        {
            for (char i = (char)(start + 1); i < end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
