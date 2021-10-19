using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Craft!")
                {
                    break;
                }
                string[] parts = command.Split(" - ");


                if (parts[0] == "Collect")
                {
                    string item = parts[1];
                    if (inventory.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        inventory.Add(item);
                    }
                }
                else if (parts[0] == "Drop")
                {
                    string item = parts[1];
                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                    }
                }
                else if (parts[0] == "Combine Items")
                {
                    string[] items = parts[1].Split(':');
                    string oldItem = items[0];
                    string newItem = items[1];
                    int index = inventory.IndexOf(oldItem);
                    if (inventory.Contains(oldItem))
                    {
                        inventory.Insert(index + 1, newItem);
                    }
                }
                else if (parts[0] == "Renew")
                {
                    string item = parts[1];
                    if (inventory.Contains(item))
                    {
                        inventory.Remove(item);
                        inventory.Add(item);
                    }

                }
            }
            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
