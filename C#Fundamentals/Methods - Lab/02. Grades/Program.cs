using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputNumber = double.Parse(Console.ReadLine());

            PrintSigh(inputNumber);
        }

        static void PrintSigh(double inputNumber)
        {
            if (inputNumber >= 2.00 && inputNumber < 3.00)
            {
                Console.WriteLine($"Fail");
            }
            else if (inputNumber >= 3.00 && inputNumber < 3.50)
            {
                Console.WriteLine($"Poor");
            }
            else if (inputNumber >= 3.50 && inputNumber < 4.50)
            {
                Console.WriteLine($"Good");
            }
            else if (inputNumber >= 4.50 && inputNumber < 5.50)
            {
                Console.WriteLine($"Very good");
            }
            else if (inputNumber >= 5.50 && inputNumber <= 6.00)
            {
                Console.WriteLine($"Excellent");
            }

        }
    }
}
