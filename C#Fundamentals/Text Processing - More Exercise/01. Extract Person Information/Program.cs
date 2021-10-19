using System;
using System.Text.RegularExpressions;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                string namePattern = @"(?<=@)(\w)+";
                string agePattern = @"(?<=#)(\d)+";
                Regex one = new Regex(namePattern);
                Regex two = new Regex(agePattern);
                if (one.IsMatch(input) && two.IsMatch(input))
                {
                    var Name = one.Match(input);
                    var Age = two.Match(input);
                    string output = $"{Name} is {Age} years old.";
                    Console.WriteLine(output);
                }
            }
        }
    }
}
