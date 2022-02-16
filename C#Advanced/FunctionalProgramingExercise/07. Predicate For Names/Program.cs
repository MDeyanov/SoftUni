using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().Where(x => x.Length <= len).ToArray();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            //Action<string[]> printNames = name =>
            //{
            //    Predicate<string> filter = name => name.Length <= len;
            //    foreach (string currentName in names.Where(name => filter(name))) i taka stava
            //    {
            //        Console.WriteLine(currentName);
            //    }
            //};
            //printNames(names);
        }
    }
}
