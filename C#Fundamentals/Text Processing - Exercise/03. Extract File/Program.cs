using System;
using System.Linq;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\').ToArray();
            string[] word = input[input.Length - 1].Split('.').ToArray();
            Console.WriteLine($"File name: {word[0]}");
            Console.WriteLine($"File extension: {word[1]}");
        }
    }
}
