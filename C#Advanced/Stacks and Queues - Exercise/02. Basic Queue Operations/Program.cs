using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = data[0];
            int s = data[1];
            int x = data[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            PushElements(queue, numbers, n);
            PopElements(queue, s);
            Checks(queue, x);

        }
        static Queue<int> PushElements(Queue<int> queue, int[] numbers, int comand)
        {
            for (int i = 0; i < comand; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            return queue;
        }
        static Queue<int> PopElements(Queue<int> queue, int comand)
        {
            for (int i = 0; i < comand; i++)
            {
                queue.Dequeue();
            }
            return queue;
        }
        static void Checks(Queue<int> queue, int comand)
        {
            if (queue.Any())
            {
                if (queue.Contains(comand))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
