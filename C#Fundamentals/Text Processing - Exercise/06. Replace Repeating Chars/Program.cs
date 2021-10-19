using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> array = input.ToCharArray().ToList();
            List<char> result = new List<char>();
            for (int i = 1; i < array.Count; i++)
            {

                if (array[i] != array[i - 1])
                {
                    result.Add(array[i]);
                }
            }
            result.Insert(0, array[0]);
            Console.WriteLine(string.Join("", result));
        }
    }
}
