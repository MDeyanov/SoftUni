using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();


            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "Add":
                        int numToAdd = int.Parse(tokens[1]);
                        nums.Add(numToAdd);
                        break;
                    case "Remove":
                        int numToRemove = int.Parse(tokens[1]);
                        nums.Remove(numToRemove);
                        break;
                    case "RemoveAt":
                        int numRemoveAt = int.Parse(tokens[1]);
                        nums.RemoveAt(numRemoveAt);
                        break;
                    case "Insert":
                        int numToInsertIndex = int.Parse(tokens[1]);
                        int numToInsert = int.Parse(tokens[2]);
                        nums.Insert(numToInsert, numToInsertIndex);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
