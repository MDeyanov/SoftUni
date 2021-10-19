using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targetPoints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;
            string input = Console.ReadLine();
            int[] array = targetPoints;
            while (input != "End")
            {

                for (int i = 0; i < targetPoints.Length; i++)
                {
                    int index = int.Parse(input);
                    if (index == i)
                    {
                        int value = targetPoints[i];

                        for (int j = 0; j < targetPoints.Length; j++)
                        {
                            if (value < targetPoints[j])
                            {
                                targetPoints[j] -= value;
                            }
                            else if (targetPoints[j] > 0)
                            {
                                targetPoints[j] += value;
                            }
                        }


                        targetPoints[i] = -1;
                        counter++;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", targetPoints)}");
        }
    }
}
