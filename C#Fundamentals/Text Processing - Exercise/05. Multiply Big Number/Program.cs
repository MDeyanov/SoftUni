using System;
using System.Collections.Generic;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiply = int.Parse(Console.ReadLine());
            if (multiply == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int remainder = 0;

            List<string> result = new List<string>();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';

                remainder += digit * multiply;

                if (remainder > 9)
                {
                    int remainderLastdigit = remainder % 10;
                    remainder /= 10;

                    result.Add(remainderLastdigit.ToString());
                }
                else
                {
                    result.Add(remainder.ToString());
                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                result.Add(remainder.ToString());
            }

            result.Reverse();

            Console.WriteLine(string.Concat(result));
        }
    }
}
