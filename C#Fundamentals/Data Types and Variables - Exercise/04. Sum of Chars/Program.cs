using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                string charInput = Console.ReadLine();
                sum += charInput[0];
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
