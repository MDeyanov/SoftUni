using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(=|\/)([A-Z])([A-z]+){2,}\1");
            int counter = 0;
            string location = Console.ReadLine();
            List<string> locations = new List<string>();

            MatchCollection matches = regex.Matches(location);

            foreach (Match match in matches)
            {
                string loc = match.ToString();
                if (loc.Contains("/"))
                {
                    string trimmed = loc.Replace("/", "");
                    locations.Add(trimmed);
                    counter += trimmed.Length;
                }
                else
                {
                    string trimmed = loc.Replace("=", "");
                    locations.Add(trimmed);
                    counter += trimmed.Length;
                }
            }
            if (locations.Count == 0)
            {
                Console.WriteLine($"Destinations:");
                Console.WriteLine($"Travel Points: 0");
            }
            else
            {
                Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
                Console.WriteLine($"Travel Points: {counter}");
            }
        }
    }
}
