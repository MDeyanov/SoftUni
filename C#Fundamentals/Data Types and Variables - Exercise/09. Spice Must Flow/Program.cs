using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            int days = 0;
            while (yield >= 100)
            {
                totalAmount += yield - 26;
                days++;
                yield -= 10;
            }
            if (days > 0)
            {
                totalAmount -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalAmount);
        }
    }
}
