using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Action<int[]> printer = x => Console.WriteLine(string.Join(" ",x));
            string command = Console.ReadLine();
            while (command!="end")
            {
                if (command=="add")
                {
                    numbers = ForEach(numbers, number => ++number);
                }
                else if (command=="multiply")
                {
                    numbers = ForEach(numbers, number => number * 2);
                }
                else if(command=="subtract")
                {
                    numbers = ForEach(numbers, number => --number);
                }
                else if (command=="print")
                {
                    printer(numbers);
                }
                command = Console.ReadLine();
            }
        }
        public static int[] ForEach(int[] numbers,Func<int,int> func)
        {
           return numbers.Select(number => func(number)).ToArray();
        }
    }
}
