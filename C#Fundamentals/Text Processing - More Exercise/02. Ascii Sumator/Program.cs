using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int min = Math.Min(one, two);
            int max = Math.Max(one, two);
            int sum = 0;
            char[] letters = input.ToCharArray();
            foreach (var idx in letters)
            {
                if (idx > min && idx < max)
                {
                    sum += idx;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
