using System;
using System.Linq;
using System.Collections.Generic;


namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> names = (name) =>
            {
                Console.WriteLine(name);
            };
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(names);
        }
    }
}
