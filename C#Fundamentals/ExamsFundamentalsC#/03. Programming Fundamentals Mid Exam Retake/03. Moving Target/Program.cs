using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string input = command[0];
                if (input == "End")
                {
                    break;
                }
                int index = int.Parse(command[1]);

                int valuePowerRadius = int.Parse(command[2]);

                if (input == "Shoot")
                {
                    if (index >= 0 && index < elements.Count)
                    {
                        elements[index] -= valuePowerRadius;

                        if (elements[index] <= 0)
                        {
                            elements.RemoveAt(index);
                        }
                    }
                }
                else if (input == "Add")
                {
                    if (index >= 0 && index < elements.Count)
                    {
                        elements.Insert(index, valuePowerRadius);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (input == "Strike")
                {
                    if (index - valuePowerRadius >= 0 && index + valuePowerRadius < elements[elements.Count - 1])
                    {
                        elements.RemoveRange(index - valuePowerRadius, valuePowerRadius * 2 + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
                if (index < 0 || index >= elements.Count)
                {
                    continue;
                }
            }
            Console.WriteLine(string.Join("|", elements));
        }
    }
}
