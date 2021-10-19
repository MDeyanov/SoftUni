using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "3:1")
                {
                    break;
                }

                string[] parts = line.Split();
                string command = parts[0];
                if (command == "merge")
                {
                    int startIndex = int.Parse(parts[1]);
                    int endIndex = int.Parse(parts[2]);
                    if (startIndex >= elements.Count || endIndex < 0)
                    {
                        continue;
                    }

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex >= elements.Count)
                    {
                        endIndex = elements.Count - 1;
                    }
                    string merged = string.Empty;
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        string element = elements[i];
                        merged += element;
                    }
                    elements.RemoveRange(startIndex, endIndex - startIndex + 1);
                    elements.Insert(startIndex, merged);
                }
                else
                {
                    int idx = int.Parse(parts[1]);
                    int partitions = int.Parse(parts[2]);

                    string element = elements[idx];
                    elements.RemoveAt(idx);

                    int partitionSize = element.Length / partitions;

                    List<string> substrings = new List<string>();
                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string substring = element.Substring(i * partitionSize, partitionSize);
                        substrings.Add(substring);
                    }
                    string lastSubstring = element.Substring((partitions - 1) * partitionSize);
                    substrings.Add(lastSubstring);
                    elements.InsertRange(idx, substrings);
                }
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
