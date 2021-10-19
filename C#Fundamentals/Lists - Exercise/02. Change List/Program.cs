using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();


            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] parts = command.Split();

                if (parts[0] == "Delete")
                {
                    nums.RemoveAll(x => x == int.Parse(parts[1]));
                }
                else if (parts[0] == "Insert")
                {
                    nums.Insert(int.Parse(parts[2]), int.Parse(parts[1]));
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
