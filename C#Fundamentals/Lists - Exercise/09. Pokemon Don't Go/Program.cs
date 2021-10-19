using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            while (numbers.Count != 0)
            {
                int num = int.Parse(Console.ReadLine());
                int value = 0;
                if (num < 0)
                {
                    value = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    sum += value;
                }
                else if (num >= numbers.Count)
                {
                    value = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(numbers[0]);

                    sum += value;
                }
                else
                {
                    value = numbers[num];
                    sum += value;
                    numbers.RemoveAt(num);
                }



                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= value)
                    {

                        numbers[i] += value;
                    }
                    else
                    {
                        numbers[i] -= value;
                    }
                }


            }
            Console.WriteLine(sum);
        }
    }
}
