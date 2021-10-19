using System;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            decimal plunger = decimal.Parse(Console.ReadLine());
            decimal expected = decimal.Parse(Console.ReadLine());
            decimal total = 0;

            for (int i = 1; i <= days; i++)
            {
                total += plunger;
                if (i % 3 == 0)
                {
                    total += plunger / 2;
                }
                if (i % 5 == 0)
                {
                    total *= 0.70m;
                }
            }
            if (total >= expected)
            {
                Console.WriteLine($"Ahoy! {total:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {(total / expected) * 100:f2}% of the plunder.");
            }
        }
    }
}
