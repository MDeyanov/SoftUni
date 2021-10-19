using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^>>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");

            List<string> furniture = new List<string>();
            double totalMoney = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(line);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                double price = double.Parse(match.Groups["price"].Value);
                double quantity = double.Parse(match.Groups["quantity"].Value);

                furniture.Add(name);
                totalMoney += quantity * price;
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in furniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}
