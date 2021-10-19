using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"([|#])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1");
            int totalCal = 0;
            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                totalCal += int.Parse(groups["calories"].Value);

            }
            int days = totalCal / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["name"]}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
