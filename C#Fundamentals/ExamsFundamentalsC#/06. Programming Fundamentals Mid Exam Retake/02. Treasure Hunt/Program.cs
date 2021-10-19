using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split("|").ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Yohoho!")
                {
                    break;
                }
                string[] commands = command.Split();
                string input = commands[0];
                if (input == "Drop")
                {
                    int inx = int.Parse(commands[1]);
                    if (inx >= 0 && inx < treasure.Count)
                    {
                        treasure.Add(treasure[inx]);
                        treasure.RemoveAt(inx);
                    }
                }
                else if (input == "Steal")
                {
                    int count = int.Parse(commands[1]);
                    if (count > treasure.Count)
                    {
                        count = treasure.Count;
                    }
                    List<string> stolen = new List<string>();
                    for (int i = treasure.Count - count; i < treasure.Count; i++)
                    {
                        stolen.Add(treasure[i]);
                    }
                    Console.WriteLine(string.Join(", ", stolen));
                    treasure.RemoveRange(treasure.Count - count, count);
                }
                else if (input == "Loot")
                {
                    for (int i = 1; i <= commands.Length - 1; i++)
                    {
                        string items = commands[i];
                        if (treasure.Contains(items))
                        {
                            continue;
                        }
                        else
                        {
                            treasure.Insert(0, items); ;
                        }
                    }

                }
            }
            double total = 0;
            for (int i = 0; i < treasure.Count; i++)
            {
                int sum = treasure[i].Length;
                total += sum;
            }
            if (total == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                return;
            }
            Console.WriteLine($"Average treasure gain: {total / treasure.Count:f2} pirate credits.");
        }
    }
}
