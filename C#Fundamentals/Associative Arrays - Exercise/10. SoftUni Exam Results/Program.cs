using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> nameAndPoints = new Dictionary<string, decimal>();

            Dictionary<string, int> programAndCount = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "exam finished")
                {
                    break;
                }
                string[] parts = command.Split("-");
                string name = parts[0];
                string language = parts[1];

                if (language == "banned")
                {
                    nameAndPoints.Remove(name);
                    continue;
                }
                if (!nameAndPoints.ContainsKey(name))
                {
                    decimal points = decimal.Parse(parts[2]);
                    nameAndPoints.Add(name, points);
                    if (!programAndCount.ContainsKey(language))
                    {
                        programAndCount.Add(language, 1);
                    }
                    else
                    {
                        programAndCount[language] += 1;
                    }
                }
                else
                {
                    decimal points = decimal.Parse(parts[2]);
                    if (nameAndPoints[name] <= points)
                    {
                        nameAndPoints[name] = points;
                    }
                    programAndCount[language] += 1;
                }
            }
            Dictionary<string, decimal> sorted = nameAndPoints
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");
            foreach (var kvp in sorted)
            {

                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Dictionary<string, int> result = programAndCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Submissions:");
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

        }
    }
}
