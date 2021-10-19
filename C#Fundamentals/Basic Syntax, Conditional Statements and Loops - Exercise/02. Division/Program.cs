using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int dev = 0;
            if (num % 10 == 0)
            {
                dev = 10;
            }
            else if (num % 7 == 0)
            {
                dev = 7;
            }
            else if (num % 6 == 0)
            {
                dev = 6;
            }
            else if (num % 3 == 0)
            {
                dev = 3;
            }
            else if (num % 2 == 0)
            {
                dev = 2;
            }
            if (dev == 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {dev}");
            }
        }
    }
}
