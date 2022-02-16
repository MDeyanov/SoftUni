using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(nums);
            List<int> rack = new List<int>();
            int sum = 0;
            int counter = 0;
            while (stack.Count != 0)
            {
                if (sum + stack.Peek() <= rackCapacity)
                {
                    sum += stack.Pop();
                    if (stack.Count == 0)
                    {
                        counter += 1;
                    }
                }
                else
                {
                    rack.Add(sum);
                    sum = 0;
                }

            }
            counter += rack.Count;
            Console.WriteLine(counter);
        }
    }
}
