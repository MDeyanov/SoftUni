using System;
using System.Linq;
using System.Collections.Generic;


namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(name => Console.WriteLine("Sir "+name));
        }
    }
}
