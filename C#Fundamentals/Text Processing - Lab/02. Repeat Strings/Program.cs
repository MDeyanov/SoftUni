﻿using System;
using System.Linq;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            string output = String.Empty; ;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    result.Append(input[i]);
                }
            }
            output = result.ToString();
            result.Clear();
            Console.WriteLine(output);
        }
    }
}
