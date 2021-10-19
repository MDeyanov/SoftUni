using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;

            for (int i = 0; i < wagons.Length; i++)
            {
                bool full = true;
                int freeSpace = 4 - wagons[i];
                wagons[i] += people;
                if (wagons[i] > 4)
                {
                    wagons[i] = 4;
                }
                people -= freeSpace;
                for (int j = 0; j < wagons.Length; j++)
                {
                    if (wagons[j] < 4)
                    {
                        full = false;
                    }
                }
                if (people <= 0 && full == true)
                {
                    Console.WriteLine(string.Join(" ", wagons));
                    return;
                }
                if (people <= 0 && full == false)
                {
                    Console.WriteLine("The lift has empty spots!");
                    Console.WriteLine(string.Join(" ", wagons));
                    return;
                }
            }
            if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", wagons));
            }
        }
    }
}
