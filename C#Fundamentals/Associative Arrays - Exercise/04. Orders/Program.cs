using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> priceByProduct = new Dictionary<string, decimal>();
            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "buy")
                {
                    break;
                }
                string[] parts = command.Split();

                string product = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (priceByProduct.ContainsKey(product))
                {
                    quantityByProduct[product] += quantity;
                    priceByProduct[product] = price;
                }
                else
                {
                    priceByProduct.Add(product, price);
                    quantityByProduct.Add(product, quantity);
                }
            }
            foreach (var kvp in priceByProduct)
            {
                string product = kvp.Key;
                decimal price = kvp.Value;
                int quantity = quantityByProduct[product];

                decimal totalPrice = quantity * price;
                Console.WriteLine($"{product} -> {totalPrice:f2}");
            }
        }
    }
}
