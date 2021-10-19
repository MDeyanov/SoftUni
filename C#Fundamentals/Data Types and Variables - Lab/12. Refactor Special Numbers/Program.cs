using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int sumOfDigits = 0;
                while (number > 0)
                {
                    sumOfDigits += number % 10;
                    number /= 10;
                }
                bool isSpecial = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;

                Console.WriteLine($"{i} -> {isSpecial}");
            }
    }
}
