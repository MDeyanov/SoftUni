using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("!").ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Go Shopping!")
                {
                    break;
                }
                string[] input = command.Split();

                if (input[0] == "Urgent")
                {
                    if (!items.Contains(input[1]))
                    {
                        items.Insert(0, input[1]);
                    }

                }
                else if (input[0] == "Unnecessary")
                {
                    if (items.Contains(input[1]))
                    {
                        items.Remove(input[1]);
                    }

                }
                else if (input[0] == "Correct" && items.Contains(input[1]))
                {
                    if (items.Contains(input[1]))
                    {
                        int inx = items.IndexOf(input[1]);
                        items.Insert(inx, input[2]);
                        items.Remove(input[1]);
                    }
                }
                else if (input[0] == "Rearrange")
                {
                    if (items.Contains(input[1]))
                    {
                        items.Remove(input[1]);
                        items.Add(input[1]);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", items));
        }
    }
}
