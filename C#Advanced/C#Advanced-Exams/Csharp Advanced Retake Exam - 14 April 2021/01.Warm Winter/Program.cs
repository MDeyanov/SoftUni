using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputHats = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputScarfs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> sets = new List<int>();
            Stack<int> hats = new Stack<int>(inputHats);
            Queue<int> scarfs = new Queue<int>(inputScarfs);

            while (true)
            {
                if (hats.Count==0)
                {
                    break;
                }
                if (scarfs.Count==0)
                {
                    break;
                }
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                if (hat > scarf)
                {
                    int value = hat + scarf;
                    sets.Add(value);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else if (scarf==hat)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(hat + 1);
                }  
            }
            var mostExpensive = sets.Max();
            Console.WriteLine($"The most expensive set is: {mostExpensive}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
