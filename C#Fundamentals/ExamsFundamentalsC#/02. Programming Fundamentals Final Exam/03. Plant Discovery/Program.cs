using System;
using System.Linq;
using System.Collections.Generic;


namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> plants = new Dictionary<string, int>();
            Dictionary<string, List<double>> ratingList = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = parts[0];
                int rarity = int.Parse(parts[1]);

                if (!plants.ContainsKey(plant))
                {
                    plants.Add(plant, rarity);
                    ratingList.Add(plant, new List<double>());
                }
                else
                {
                    plants[plant] = rarity;
                }
            }
            while (true)
            {
                string[] line = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (line[0] == "Exhibition")
                {
                    break;
                }
                string[] parts = line[1].Trim().Split("-", StringSplitOptions.RemoveEmptyEntries);
                string plant = parts[0].Trim();
                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    continue;
                }
                if (line[0] == "Rate")
                {
                    double rating = double.Parse(parts[1].Trim());
                    ratingList[plant].Add(rating);

                }
                else if (line[0] == "Update")
                {
                    int rarity = int.Parse(parts[1].Trim());
                    plants[plant] = rarity;
                }
                else if (line[0] == "Reset")
                {
                    ratingList[plant].Clear();
                }
            }
            Console.WriteLine("Plants for the exhibition:");

            var sorted = plants.OrderByDescending(x => x.Value).ThenByDescending(x => ratingList[x.Key].Count > 0
              ? ratingList[x.Key].Sum() / ratingList[x.Key].Count : 0.0);
            foreach (var (plant, rarity) in sorted)
            {
                var avarageRait = ratingList[plant].Count > 0 ? ratingList[plant].Sum() / ratingList[plant].Count : 0.00;
                Console.WriteLine($"- {plant}; Rarity: {rarity}; Rating: {avarageRait:f2}");
            }
        }
    }
}
