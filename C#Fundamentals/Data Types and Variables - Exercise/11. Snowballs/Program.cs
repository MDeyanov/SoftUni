using System;
using System.Linq;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger biggestValue = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;

            for (int i = 0; i < n; i++)
            {
                int snowBallSnow = int.Parse(Console.ReadLine());
                int snowBallTime = int.Parse(Console.ReadLine());
                int snowBallQuality = int.Parse(Console.ReadLine());

                BigInteger currentValue = BigInteger.Pow(snowBallSnow / snowBallTime, snowBallQuality);
                if (currentValue > biggestValue)
                {
                    snow = snowBallSnow;
                    time = snowBallTime;
                    quality = snowBallQuality;
                    biggestValue = currentValue;
                }

            }
            Console.WriteLine($"{snow} : {time} = {biggestValue} ({ quality})");
        }
    }
}
