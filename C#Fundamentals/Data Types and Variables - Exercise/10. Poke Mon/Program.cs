using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int target = 0;
            int halfOfN = n / 2;

            while (n >= m)
            {
                target++;
                n -= m;
                if (halfOfN == n && y > 0 && n > y)
                {
                    n /= y;

                }
            }
            Console.WriteLine(n);
            Console.WriteLine(target);
        }
    }
}
