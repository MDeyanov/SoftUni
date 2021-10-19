using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();
            while (true)
            {
                string[] commands = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Sail")
                {
                    break;
                }
                string command = commands[0];
                int population = int.Parse(commands[1]);
                int gold = int.Parse(commands[2]);
                if (!cities.ContainsKey(command))
                {
                    cities.Add(commands[0], new List<int>());
                    cities[command].Add(population);
                    cities[command].Add(gold);
                }
                else
                {
                    cities[command][0] += population;
                    cities[command][1] += gold;
                }

            }
            while (true)
            {
                string[] commands = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "End")
                {
                    break;
                }
                string command = commands[0];
                if (command == "Plunder")
                {
                    string town = commands[1];
                    int people = int.Parse(commands[2]);
                    int gold = int.Parse(commands[3]);

                    cities[town][0] -= people;
                    cities[town][1] -= gold;
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (cities[town][0] <= 0 || cities[town][1] <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        cities.Remove(town);

                    }
                }
                else if (command == "Prosper")
                {
                    string town = commands[1];
                    int gold = int.Parse(commands[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        cities[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                    }
                }
            }
            Dictionary<string, List<int>> sorted = cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Ahoy, Captain! There are {sorted.Count} wealthy settlements to go to:");
            foreach (var towns in sorted)
            {
                Console.WriteLine($"{towns.Key} -> Population: {towns.Value[0]} citizens, Gold: {towns.Value[1]} kg");
            }
        }
    }
}
