using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int sec = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int min = SmallestNumber(first, sec, third);
            Console.WriteLine(min);
        }
        static int SmallestNumber(int first, int sec, int third)
        {
            int min = Math.Min(Math.Min(first, sec), third);
            return min;

        }
    }
}
