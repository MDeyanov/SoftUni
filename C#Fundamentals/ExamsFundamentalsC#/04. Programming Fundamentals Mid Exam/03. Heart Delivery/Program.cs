using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int index = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Love!")
                {
                    break;
                }
                string[] commands = input.Split();

                int lenght = int.Parse(commands[1]);
                index += lenght;
                if (index >= hood.Count)
                {
                    index = 0;
                }
                if (hood[index] != 0)
                {
                    hood[index] -= 2;
                    if (hood[index] == 0)
                    {
                        Console.WriteLine($"Place {index} has Valentine's day.");
                    }
                }
                else
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                }


            }
            Console.WriteLine($"Cupid's last position was {index}.");
            bool isSuccessful = true;
            foreach (var house in hood)
            {
                if (house != 0)
                {
                    isSuccessful = false;
                    break;
                }
            }
            int counter = 0;
            foreach (var house in hood)
            {
                if (house != 0)
                {
                    counter++;
                }
            }
            if (isSuccessful)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
        }
    }
    }
}
