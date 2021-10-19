using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int sec = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int result = SumOfFirstTwo(first, sec);
            int finalResult = SubtractThird(result, third);
            Console.WriteLine(finalResult);
        }

        private static int SubtractThird(int result, int third)
        {
            int final = result - third;
            return final;
        }

        private static int SumOfFirstTwo(int first, int sec)
        {
            int result = first + sec;
            return result;
        }
    }
}
