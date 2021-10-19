using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int d2 = 0;
            int d1 = 0;
            while (input != "END")
            {

                int number = int.Parse(input);
                d2 = number % 10;
                d1 = number;
                while (d1 >= 10)
                {
                    d1 /= 10;
                }
                if (d2 == d1)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            }

        }
    }
}
