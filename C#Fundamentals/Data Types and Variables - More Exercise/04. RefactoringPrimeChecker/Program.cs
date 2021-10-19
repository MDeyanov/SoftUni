using System;

namespace _04._RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            for (int i = 2; i <= x; i++)
            {
                bool valid = true;
                for (int k = 2; k < i; k++)
                {
                    if (i % k == 0)
                    {
                        valid = false;
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", i, valid.ToString().ToLower());
            }
        }
    }
}
