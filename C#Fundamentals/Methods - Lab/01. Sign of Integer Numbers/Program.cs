using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            PrintSigh(inputNumber);
        }
        static void PrintSigh(int inputNumber)
        {
            if (inputNumber < 0)
            {
                Console.WriteLine($"The number {inputNumber} is negative.");
            }
            else if (inputNumber > 0)
            {
                Console.WriteLine($"The number {inputNumber} is positive.");
            }
            else
            {
                Console.WriteLine($"The number {inputNumber} is zero.");
            }
        }
    }
}
