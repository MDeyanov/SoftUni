using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(first);
            Stack<int> secondBox = new Stack<int>(second);
            int sum = 0;
            while (true)
            {
                if (firstBox.Count==0)
                {
                    break;
                }
                if (secondBox.Count==0)
                {
                    break;
                }
                int firstNum = firstBox.Peek();
                int secNum = secondBox.Peek();
                if ((firstNum+secNum) % 2 == 0)
                {
                    sum += firstBox.Dequeue() + secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
