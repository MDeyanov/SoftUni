using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int first = number;
            int sum = 0;
            while (number > 0)
            {
                int currentNum = number % 10;
                int factorial = 1;
                for (int i = 1; i <= currentNum; i++)
                {
                    factorial *= i;
                }
                sum += factorial;
                number /= 10;
            }
            if (first == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
