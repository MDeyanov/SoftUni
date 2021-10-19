using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Generate")
                {
                    break;
                }

                string[] parts = line.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Contains")
                {
                    if (input.Contains(parts[1]))
                    {
                        Console.WriteLine($"{input} contains {parts[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (parts[0] == "Flip")
                {
                    int start = int.Parse(parts[2]);
                    int end = int.Parse(parts[3]);
                    if (parts[1] == "Upper")
                    {
                        if (start <= end)
                        {
                            string subStringToReplace = input.Substring(start, end - start);
                            string newString = subStringToReplace.ToUpper();
                            input = input.Replace(subStringToReplace, newString);
                            Console.WriteLine(input);
                        }
                    }
                    else
                    {
                        if (start <= end)
                        {
                            string subStringToReplace = input.Substring(start, end - start);
                            string newString = subStringToReplace.ToLower();
                            input = input.Replace(subStringToReplace, newString);
                            Console.WriteLine(input);
                        }
                    }

                }
                else if (parts[0] == "Slice")
                {
                    int start = int.Parse(parts[1]);
                    int end = int.Parse(parts[2]);
                    input = input.Remove(start, end - start);
                    Console.WriteLine(input);
                }
            }
            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
