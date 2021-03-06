using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
             
            int bombPower = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    bombPower += input[i + 1] - '0';
                    result.Append(input[i]);
                }
                else if (bombPower > 0)
                {
                    bombPower--;
                }
                else
                {
                    result.Append(input[i]);
                }
            }

            Console.WriteLine(result);
        }
    }
}
