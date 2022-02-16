using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> lastStrings = new Stack<string>();
            string currentString = "";
            lastStrings.Push(currentString);
            for (int i = 0; i < n; i++)
            {
                string[] currentCommand =
                    Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (currentCommand[0])
                {
                    case "1":
                        {
                            currentString += currentCommand[1];
                            lastStrings.Push(currentString);
                        }
                        break;
                    case "2":
                        {
                            int countOfLastEl = int.Parse(currentCommand[1]);
                            StringBuilder str = new StringBuilder();
                            currentString = currentString.Substring(0, currentString.Length - countOfLastEl);

                            lastStrings.Push(currentString);

                        }
                        break;
                    case "3":
                        {

                            int indexForPrint = int.Parse(currentCommand[1]);
                            Console.WriteLine(currentString[indexForPrint - 1]);

                        }
                        break;
                    case "4":
                        {
                            lastStrings.Pop();
                            currentString = lastStrings.Peek();

                        }
                        break;

                }
            }
        }
    }
}
