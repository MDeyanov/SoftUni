using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            while (true)
            {
                string command = Console.ReadLine().ToLower();
                if (command.Contains("end"))
                {
                    break;
                }
                else if (command.Contains("add"))
                {
                    var splitted = command.Split();
                    stack.Push(int.Parse(splitted[1]));
                    stack.Push(int.Parse(splitted[2]));
                }
                else if (command.Contains("remove"))
                {
                    var splitted = command.Split();
                    var count = int.Parse(splitted[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
