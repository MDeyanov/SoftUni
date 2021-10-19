using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            double b = 1.50;
            double c = 1.00;
            double d = 1.40;
            double e = 2.00;

            switch (command)
            {
                case "coffee":
                    Coffee(a, b);
                    break;
                case "water":
                    Water(a, c);
                    break;
                case "coke":
                    Coke(a, d);
                    break;
                case "snacks":
                    Snacks(a, e);
                    break;

                default:
                    break;
            }


        }
        static void Coffee(int a, double b = 1.50)
        {

            Console.WriteLine($"{a * b:f2}");

        }
        static void Water(int a, double c = 1.00)
        {
            Console.WriteLine($"{a * c:f2}");
        }
        static void Coke(int a, double d = 1.40)
        {
            Console.WriteLine($"{a * d:f2}");
        }
        static void Snacks(int a, double e = 2.00)
        {
            Console.WriteLine($"{a * e:f2}");
        }
    }
}
