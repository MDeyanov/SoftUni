﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split().Where(word => word.Length % 2 == 0).ToList().ForEach(word => Console.WriteLine(word));
        }
    }
}
