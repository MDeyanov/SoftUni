using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            int counter = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] parts = command.Split();
                counter++;
                int index1 = int.Parse(parts[0]);
                int index2 = int.Parse(parts[1]);
                int middle = numbers.Count / 2;
                if (index1 < 0 || index1 >= numbers.Count || index2 < 0 || index2 >= numbers.Count || index1 == index2)
                {
                    string adding = "-" + counter + "a";
                    numbers.Insert(middle, adding);
                    numbers.Insert(middle, adding);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (numbers[index1] == numbers[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {numbers[index1]}!");
                    if (index1 < index2)
                    {
                        numbers.RemoveAt(index2);
                        numbers.RemoveAt(index1);
                    }
                    else
                    {
                        numbers.RemoveAt(index1);
                        numbers.RemoveAt(index2);
                    }

                }
                else
                {
                    Console.WriteLine("Try again!");
                }
                if (numbers.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    return;
                }

            }
            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
