using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] parts = line.Split();
                string command = parts[0];

                if (command == "Add")
                {
                    int number = int.Parse(parts[1]);
                    nums.Add(number);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(parts[1]);
                    int index = int.Parse(parts[2]);
                    if (index < 0 || index >= nums.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    nums.Insert(index, number);
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(parts[1]);
                    if (index < 0 || index >= nums.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    nums.RemoveAt(index);
                }
                else if (command == "Shift")
                {
                    string direction = parts[1];
                    int count = int.Parse(parts[2]);
                    if (direction == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstElement = nums[0];
                            nums.RemoveAt(0);
                            nums.Add(firstElement);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {

                            int lastElement = nums[nums.Count - 1];
                            nums.RemoveAt(nums.Count - 1);
                            nums.Insert(0, lastElement);

                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
