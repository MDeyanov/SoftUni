using System;
using System.Collections.Generic;
namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> quantityByResourse = new Dictionary<string, int>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (quantityByResourse.ContainsKey(input))
                {
                    quantityByResourse[input] += quantity;
                }
                else
                {
                    quantityByResourse.Add(input, quantity);
                }
            }
            foreach (var kvp in quantityByResourse)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
