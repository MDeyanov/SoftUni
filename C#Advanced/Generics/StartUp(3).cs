using System;
using System.Collections.Generic;

namespace GenericCountMethod
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }
            var box = new Box<string>(list);
            var elementToCompare = Console.ReadLine();
            var count = box.CountOfGreaterElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
