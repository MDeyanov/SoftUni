using System;

namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal paunds = decimal.Parse(Console.ReadLine());

            decimal usd = paunds * (decimal)1.31;
            Console.WriteLine($"{usd:f3}");
        }
    }
}
