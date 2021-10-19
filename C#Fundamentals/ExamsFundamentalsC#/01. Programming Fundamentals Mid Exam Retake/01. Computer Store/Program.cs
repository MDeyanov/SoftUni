using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double price = 0;
            double taxes = 0;
            while (true)
            {
                if (command == "special" || command == "regular")
                {
                    break;
                }
                double priceOf = double.Parse(command);
                if (priceOf >= 0)
                {

                    price += priceOf;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }
                command = Console.ReadLine();
            }
            if (price == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            taxes = price * 0.20;
            double total = taxes + price;
            if (command == "special")
            {
                total *= 0.90;
            }
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {price:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:f2}$");
        }
    }
}
