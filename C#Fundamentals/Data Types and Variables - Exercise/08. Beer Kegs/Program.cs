﻿using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string largestKeg = "";
            double largestVolume = 0;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (volume > largestVolume)
                {
                    largestVolume = volume;
                    largestKeg = model;

                }
            }
            Console.WriteLine(largestKeg);
        }
    }
}
