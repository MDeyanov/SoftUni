using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex keyRegex = new Regex(@"[STARstar]");

            Regex regex = new Regex(@"^[^@\-!:>]*@(?<name>[A-Za-z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-!:>]*!(?<type>[AD])![^@\-!:>]*->(?<soldiers>\d+)[^@\-!:>]*$");

            List<string> attacked = new List<string>();

            List<string> destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int key = keyRegex.Matches(text).Count;

                string decryptedText = Decrypt(text, key);

                Match match = regex.Match(decryptedText);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                string type = match.Groups["type"].Value;
                if (type == "A")
                {
                    attacked.Add(name);
                }
                else
                {
                    destroyed.Add(name);
                }
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");

            PrintSortedPlanets(attacked);

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");

            PrintSortedPlanets(destroyed);
        }

        private static void PrintSortedPlanets(List<string> planets)
        {
            List<string> sorted = planets.OrderBy(x => x).ToList();

            foreach (var planet in sorted)
            {
                Console.WriteLine($"-> {planet}");
            }
        }

        private static string Decrypt(string text, int key)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var letter in text)
            {
                sb.Append((char)(letter - key));
            }

            return sb.ToString();
        }
    }
}
