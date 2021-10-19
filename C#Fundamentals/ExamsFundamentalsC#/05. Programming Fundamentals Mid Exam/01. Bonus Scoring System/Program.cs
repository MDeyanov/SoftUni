using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            int[] points = new int[students];
            double biggestPoints = int.MinValue;
            if (students == 0 || lectures == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }
            for (int i = 0; i < students; i++)
            {
                points[i] = int.Parse(Console.ReadLine());

            }
            for (int j = 0; j < points.Length; j++)
            {
                int biggestPoint = points[j];
                if (biggestPoint > biggestPoints)
                {
                    biggestPoints = biggestPoint;
                }
            }

            double maxPoints = (biggestPoints / lectures) * (5 + bonus);
            Console.WriteLine($"Max Bonus: {Math.Round(maxPoints, MidpointRounding.AwayFromZero)}.");
            Console.WriteLine($"The student has attended {biggestPoints} lectures.");
        }
    }
}
