using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] lenght = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nLenght = lenght[0];
            int mLenght = lenght[1];
            HashSet<int> n = InputHashSets(nLenght, new HashSet<int>());
            HashSet<int> m = InputHashSets(mLenght, new HashSet<int>());
            CkeckSets(n, m);

        }

        private static void CkeckSets(HashSet<int> n, HashSet<int> m)
        {
            List<int> nums = new List<int>();
            foreach (int number in n)
            {
                if (m.Contains(number))
                {
                    nums.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }

        private static HashSet<int> InputHashSets(int nLenght, HashSet<int> hashSet)
        {
            for (int i = 0; i < nLenght; i++)
            {
                hashSet.Add(int.Parse(Console.ReadLine()));
            }
            return hashSet;
        }
    }
}
