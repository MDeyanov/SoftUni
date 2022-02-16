using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(children);
            int tosses = 0;
            while (queue.Count > 1)
            {
                tosses++;
                string kid = queue.Dequeue();
                if (tosses == n)
                {
                    tosses = 0;
                    Console.WriteLine("Removed " + kid);
                }
                else
                {
                    queue.Enqueue(kid);
                }
            }
            Console.WriteLine("Last is " + queue.Dequeue());
        }
    }
}
