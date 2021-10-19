using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = GetSum(input[0], input[1]);
            Console.WriteLine(sum);
        }
        private static int GetSum(string aFirst, string aSecond)
        {
            int index = Math.Min(aFirst.Length, aSecond.Length);
            int sum = 0;
            for (int i = 0; i < index; i++)
            {
                sum += aFirst[i] * aSecond[i];
            }

            if (aFirst.Length > aSecond.Length)
            {
                sum += Exeptions(index, aFirst);

            }
            else if (aSecond.Length > aFirst.Length)
            {
                sum += Exeptions(index, aSecond);
            }
            return sum;
        }

        private static int Exeptions(int index, string word)
        {
            int sum = 0;
            for (int i = index; i < word.Length; i++)
            {
                sum += word[i];
            }
            return sum;
        }
    }
}
