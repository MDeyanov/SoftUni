using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Travel")
                {
                    break;
                }
                string[] parts = line.Split(":");

                string command = parts[0];
                if (command == "Add Stop")
                {
                    int index = int.Parse(parts[1]);
                    if (index >= 0 && index <= input.Length)
                    {
                        input = input.Insert(index, parts[2]);

                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(parts[1]);
                    int endIndex = int.Parse(parts[2]);
                    if (startIndex >= 0 && startIndex < input.Length && startIndex <= endIndex)
                    {
                        if (endIndex >= 0 && endIndex < input.Length)
                        {
                            input = input.Remove(startIndex, endIndex - startIndex + 1);

                        }
                    }
                }
                else if (command == "Switch")
                {
                    string oldString = parts[1];
                    string newString = parts[2];
                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);

                    }
                }
                Console.WriteLine(input);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
