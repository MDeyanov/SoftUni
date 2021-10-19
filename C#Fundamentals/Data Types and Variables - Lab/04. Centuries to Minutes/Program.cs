using System;

namespace _04._Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            long hours = days * 24;
            long minutes = hours * 60;
            Console.WriteLine($"{centuries:f0} centuries = {years:f0} years = {days:f0} days = {hours:f0} hours = {minutes:f0} minutes");
        }
    }
}
