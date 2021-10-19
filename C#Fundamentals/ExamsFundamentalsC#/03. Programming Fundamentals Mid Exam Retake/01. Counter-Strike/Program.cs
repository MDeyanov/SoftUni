using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int counter = 0;
            while (input != "End of battle")
            {

                int cost = int.Parse(input);
                if (cost > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {counter} won battles and {Math.Abs(energy)} energy");
                    return;
                }
                counter++;
                energy -= cost;
                if (counter % 3 == 0)
                {
                    energy += counter;
                }
                input = Console.ReadLine();

            }            
            Console.WriteLine($"Won battles: {counter}. Energy left: {energy}");
        }
    }
}
