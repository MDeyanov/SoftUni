using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestBook = new Dictionary<string, string>();
            var dictionary = new Dictionary<string, Dictionary<string, int>>();
            string input = String.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(':').ToArray();
                if (!contestBook.ContainsKey(tokens[0]))
                {
                    contestBook.Add(tokens[0], tokens[1]);
                }
            }
            string line = String.Empty;
            while ((line = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = line.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);
                if (contestBook.ContainsKey(contest))
                {
                    if (contestBook[contest].Equals(password))
                    {
                        if (!dictionary.ContainsKey(username))  
                        {
                            dictionary.Add(username, new Dictionary<string, int>());
                            dictionary[username].Add(contest, points);

                        }
                        else if (dictionary.ContainsKey(username))  
                        {
                            if (dictionary[username].ContainsKey(contest))  
                            {
                                if (dictionary[username][contest] > points)
                                {
                                    continue;  
                                }
                            }
                            else if (!dictionary[username].ContainsKey(contest)) 
                            {
                                dictionary[username].Add(contest, points); 
                            }
                            dictionary[username][contest] = points; 


                        }


                    }
                }
            }

            var scoreBook = new Dictionary<string, int>();
            foreach (var idx in dictionary)
            {
                scoreBook[idx.Key] = idx.Value.Values.Sum();
            }

            int maxPoint = scoreBook.Values.Max();
            foreach (var pair in scoreBook)
            {
                if (pair.Value == maxPoint)
                {
                    Console.WriteLine($"Best candidate is {pair.Key} with total {pair.Value} points.");

                }
            }
            Console.WriteLine($"Ranking: ");
            foreach (var kvp in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var index in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {index.Key} -> {index.Value}");

                }
            }

        }
    }
}
